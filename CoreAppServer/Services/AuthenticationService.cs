using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

namespace API.Services
{
    public interface IAuthenticationService
    {
        Task<List<RolesDto>> UserRoles(ControllerBase controller, int userId);
        Task<List<RolesDto>> Roles(ControllerBase controller);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly DataContext _dataContext;

        public AuthenticationService(ILogger<AuthenticationService> logger,
            DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext; 
        }

        public async Task<List<RolesDto>> UserRoles(ControllerBase controller, int userId)
        {
            var roles = await _dataContext.UserRole
                .AsNoTracking()
                .Where(role => role.UserId == userId)
                .Select(role => new RolesDto
                {
                    RoleId = role.Id,
                    Role = role.Role,
                    UserId = role.UserId
                })
                .ToListAsync();
            return roles;
        }

        public async Task<List<RolesDto>> Roles(ControllerBase controller)
        {
            var roles = await _dataContext.UserRole
                .AsNoTracking()
                .Select(role => new RolesDto
                {
                    RoleId = role.Id,
                    Role = role.Role,
                    UserId = role.UserId
                })
                .ToListAsync();
            return roles;
        }
    }
}
