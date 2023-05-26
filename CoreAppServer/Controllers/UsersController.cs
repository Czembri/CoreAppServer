using System.Net;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var result = await _context.Users
                .AsNoTracking()
                .Include(x => x.UserRole)
                .Include(x => x.UserInfo)
                .Select(user => new AppUserDto
                {
                    CreationDate = user.CreationDate,
                    ModificationDate = user.ModificationDate,
                    UserRole = MapUserRole(user.UserRole),
                    UserInfo = MapUserInfo(user.UserInfo),
                    Id = user.Id,
                    UserName = user.UserName
                })
                .ToListAsync();
            if (!result.Any())
                return BadRequest(new HttpErrorDto
                {
                    Error = "Users not found...",
                    HttpStatusCode = HttpStatusCode.BadRequest,
                });
            return Ok(result);
        }

        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) 
        {
            var result =  await _context.Users
                .AsNoTracking()
                .Include(x => x.UserInfo)
                .Include(x => x.UserRole)
                .Where(x => x.Id == id)
                .Select(user => new AppUserDto
                {
                    CreationDate = user.CreationDate,
                    ModificationDate = user.ModificationDate,
                    UserRole = MapUserRole(user.UserRole),
                    UserInfo = MapUserInfo(user.UserInfo),
                    Id = user.Id,
                    UserName = user.UserName
                })
                .FirstOrDefaultAsync();
            return Ok(result);
        }

        private static List<UserRoleDto> MapUserRole(IEnumerable<UserRole> userRole)
        {
            return userRole.Select(role => new UserRoleDto
            {
                Id = role.Id,
                Role = role.Role
            }).ToList();
        }

        private static UserInfoDto MapUserInfo(UserInfo userInfo)
        {
            return new UserInfoDto
            {
                Address = userInfo.Address,
                City = userInfo.City,
                Id = userInfo.Id,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                PostalCode = userInfo.PostalCode
            };
        }
    }
}