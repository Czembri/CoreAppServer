using API.Data;
using API.DTOs;
using API.Entities;
using API.Enums;
using API.Exceptions;
using API.Interfaces;
using DocumentFormat.OpenXml.InkML;
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

        public async Task<bool> AddUser(AdminFormDto adminFormDto)
        {
            var contextRoles = adminFormDto.Roles.Split(",");

            if (contextRoles.Length == 0 || string.IsNullOrEmpty(adminFormDto.Roles)) throw new NoRoleAddedToUserException();

            if (Enum.TryParse(contextRoles[0], out Role role) == false) throw new RoleNotExistsException();

            var roles = await _dataContext.UserRole
                .AsNoTracking()
                .Where(x => x.Role == role)
                .ToListAsync();

            if (roles.Count == 0) throw new NoRoleAddedToUserException();

            if (await UserExists(adminFormDto.Login)) throw new UserAlreadyExistsException();

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = adminFormDto.Login.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminFormDto.Password)),
                PasswordSalt = hmac.Key,
                ModificationDate = DateTime.UtcNow,
                CreationDate = DateTime.UtcNow
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            var userRole = new UserRole
            {
                AppUser = user,
                Role = role,
                UserId = user.Id
            };

            _dataContext.UserRole.Add(userRole);
            await _dataContext.SaveChangesAsync();

            var userInfo = new UserInfo
            {
                AppUser = user,
                FirstName = adminFormDto.FirstName,
                LastName = adminFormDto.LastName,
                Address = adminFormDto.Address,
                PostalCode = adminFormDto.PostalCode,
                City = adminFormDto.City,
                UserId = user.Id
            };

            _dataContext.UserInfo.Add(userInfo);
            await _dataContext.SaveChangesAsync();

            return true;
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
         
        public async Task<bool> UserExists(string userName)
        {
            return await _dataContext.Users.AnyAsync(user => user.UserName == userName.ToLower());
        }
    }
}
