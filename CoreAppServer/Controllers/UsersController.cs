using System.Net;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Exceptions;
using API.Interfaces;
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
        private readonly IUsersService _usersService;
        public UsersController(DataContext context, IUsersService usersService)
        {
            _context = context;
            _usersService = usersService;
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

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] AdminFormDto form)
        {
            var result = await _usersService.UpdateUserAsync(form);
            if (!result)
                return NotFound(new HttpErrorDto
                {
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Error = "User not found"
                });
            return Ok(new
            {
                message = "User updated successfully"
            });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await _usersService.DeleteUserAsync(id);
            if (!result)
                return NotFound(new HttpErrorDto
                {
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Error = "User not found"
                });
            return Ok(new
            {
                message = "User deleted successfully"
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] AdminFormDto form)
        {
            try
            {
                var result = await _usersService.AddUser(form);

                return Ok(new
                {
                    message = "User updated successfully"
                });
            }
            catch (UserAlreadyExistsException)
            {
                return BadRequest(new HttpErrorDto
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Error = "User already exists"
                });
            }
            catch (NoRoleAddedToUserException)
            {
                return BadRequest(new HttpErrorDto
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Error = "No role added to user"
                });
            }
            catch (RoleNotExistsException)
            {
                return BadRequest(new HttpErrorDto
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Error = "Role not exist"
                });
            }
        }

        private static List<UserRoleDto> MapUserRole(IEnumerable<UserRole> userRole)
        {
            return userRole.Select(role => new UserRoleDto
            {
                Id = role.Id,
                Role = role.Role.ToString()
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