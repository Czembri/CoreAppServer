using API.DTOs;

namespace API.Interfaces
{
    public interface IUsersService
    {
        public Task<bool> UpdateUserAsync(AdminFormDto adminFormDto);
    }
}
