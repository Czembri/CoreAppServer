using API.Data;
using API.DTOs;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Services
{
    public class UsersService : IUsersService
    {
        private readonly DataContext _dataContext;
        public UsersService(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public async Task<bool> UpdateUserAsync(AdminFormDto adminFormDto)
        {
            var entity = await _dataContext.Users
                .Include(x => x.UserInfo)
                .Where(x => x.Id == adminFormDto.Id)
                .FirstOrDefaultAsync();

            if (entity == null) return false;

            entity.UserInfo.FirstName = adminFormDto.FirstName;
            entity.UserInfo.LastName = adminFormDto.LastName;
            entity.UserInfo.Address = adminFormDto.Address;
            entity.UserInfo.PostalCode = adminFormDto.PostalCode;
            entity.UserName = adminFormDto.Login;

            using var hmac = new HMACSHA512();
            entity.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminFormDto.Password));
            entity.PasswordSalt = hmac.Key;

            await _dataContext.SaveChangesAsync();

            return true;
        }
    }
}
