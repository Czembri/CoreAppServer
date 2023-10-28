using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    public class ConstitutionAiController : BaseApiController
    {
        private readonly IConstitutionAIService _constitutionAIService;
        public ConstitutionAiController(IConstitutionAIService constitutionAIService)
        {
           _constitutionAIService = constitutionAIService;
        }

        [HttpPost("save-chat")]
        public async Task<IActionResult> SaveChat(ConstitutionChatDTO dto)
        {
            try
            {
                var userId = User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;
                if (userId == null)
                    return NotFound("User not found");
                await _constitutionAIService.SaveChat(dto, int.Parse(userId));
                return Ok(new
                {
                    Response = "Chat saved successfully"
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
