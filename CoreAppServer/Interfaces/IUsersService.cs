﻿using API.DTOs;

namespace API.Interfaces
{
    public interface IUsersService
    {
        public Task<bool> UpdateUserAsync(AdminFormDto adminFormDto);
        public Task<bool> AddUser(AdminFormDto adminFormDto);
        public Task<bool> UserExists(string userName);
    }
}
