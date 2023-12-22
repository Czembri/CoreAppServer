using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUsersService
    {
        public Task<bool> UpdateUserAsync(AdminFormDto adminFormDto);
        public Task<bool> AddUser(AdminFormDto adminFormDto);
        public Task<bool> UserExists(string userName);
        public Task<bool> DeleteUserAsync(int id);
        public Task<AppUser> GetUserByUserName(string username);
    }
}
