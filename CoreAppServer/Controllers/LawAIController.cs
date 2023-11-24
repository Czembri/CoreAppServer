using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("get-chats")]
        public async Task<IActionResult> GetChats()
        {
            var userId = User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;
            if (userId == null) return Unauthorized();

            var chats = await _lawAIService.GetChats(int.Parse(userId));

            return Ok(chats);

        }


        [Authorize]
        [HttpGet("get-chat/{chatId}")]
        public async Task<IActionResult> GetChat(int chatId)
        {
            var userId = User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;
            if (userId == null) return Unauthorized();

            var chat = await _lawAIService.GetChat(chatId);

            return Ok(chat);

        }

        [Authorize]
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
