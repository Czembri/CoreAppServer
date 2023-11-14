using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    public class LawAiController : BaseApiController
    {
        private readonly ILawAIService _lawAIService;
        public LawAiController(ILawAIService lawAIService)
        {
            _lawAIService = lawAIService;
        }
        [HttpGet("get-chats")]
        public async Task<List<AIChatsDto>> GetChats()
        {
            var userId = User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;
            if (userId == null) return null;

            return await _lawAIService.GetChats(int.Parse(userId));

        }

        [HttpPost("save-chat")]
        public async Task<IActionResult> SaveChat()
        {
            try
            {
                var userId = User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;
                if (userId == null)
                    return NotFound("User not found");
                await _lawAIService.SaveChat(int.Parse(userId));
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
