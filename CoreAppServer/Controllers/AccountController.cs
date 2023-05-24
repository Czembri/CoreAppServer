using System.Net;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Enums;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto) 
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username already exists!");

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                UserRole = new List<UserRole>
                {
                    new()
                    {
                        Role = Role.Basic,
                    }
                }
            };

            _context.Users.Add(user);

            var userInfo = new UserInfo 
            {
                AppUser = user,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Address = registerDto.Address,
                PostalCode = registerDto.PostalCode,
                City = registerDto.City,
            };

            _context.UserInfo.Add(userInfo);
            await _context.SaveChangesAsync();
            var token = _tokenService.CreateToken(user);
            return Ok(new UserDto
            {
                UserName = user.UserName,
                Token = token.Token,
                Role = user.UserRole.Select(role => role.Role.ToString()).ToList()
            });
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto) 
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(x => x.UserRole)
                .SingleOrDefaultAsync(user => user.UserName == loginDto.UserName);
            if (user == null) return NotFound(new HttpErrorDto
            {
                HttpStatusCode = HttpStatusCode.Unauthorized,
                Error = "User not found"
            });

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            if (computedHash.Where((t, i) => t != user.PasswordHash[i]).Any())
            {
                return Unauthorized(new HttpErrorDto
                {
                    HttpStatusCode = HttpStatusCode.Unauthorized,
                    Error = "Invalid username or password"
                });
            }
            
            var token = _tokenService.CreateToken(user);

            return Ok(new UserDto
            {
                UserName = user.UserName,
                Token = token.Token,
                Role = user.UserRole.Select(role => role.Role.ToString()).ToList()
            });
        }
        
        private async Task<bool> UserExists(string username) 
        {
            return await _context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }
    }
}