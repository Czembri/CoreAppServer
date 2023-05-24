using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using API.Enums;

namespace API.Controllers
{
    public class RolesController : BaseApiController
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public RolesController(ILogger<RolesController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IList<RolesDto>>> GetRoles()
        {
            var userId = User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;
            if (userId == null)
                return NotFound("User not found");
            
            if (int.TryParse(userId, out var id))
            {
                var userRoles = await _authenticationService.UserRoles(this, id);
                if (userRoles.All(role => role.Role != Role.Admin))
                    return Unauthorized();
                return Ok(userRoles);
            } else
            {
                _logger.LogError($"Error while trying retrieve user roles: Invalid user id.");
            }

            return NoContent();
        }


        [Authorize]
        [HttpGet("HasRole")]
        public async Task<ActionResult<bool>> HasRole([FromQuery] string role)
        {
            var userId = User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;
            if (userId == null)
                return NotFound("User not found");

            if (int.TryParse(userId, out var id))
            {
                var userRoles = await _authenticationService.UserRoles(this, id);
                if (userRoles.All(x => x.Role.ToString() != role))
                    return Unauthorized(false);
                return Ok(true);
            }
            
            _logger.LogError($"Error while trying retrieve user roles: Invalid user id.");

            return Unauthorized(false);
        }
    }
}
