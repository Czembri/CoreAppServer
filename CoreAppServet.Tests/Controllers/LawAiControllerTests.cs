using API.Controllers;
using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CoreAppServer.Tests.Controllers
{
    public class LawAiControllerTests
    {
        private readonly Mock<ILawAIService> _mockLawAIService;
        private readonly LawAiController _controller;

        public LawAiControllerTests()
        {
            _mockLawAIService = new Mock<ILawAIService>();
            _controller = new LawAiController(_mockLawAIService.Object);
            SetupControllerHttpContext();
        }

        private void SetupControllerHttpContext()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, "1"),
            }));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [Fact]
        public async Task GetChats_ReturnsChatList_ForAuthenticatedUser()
        {
            var expectedChats = new List<AIChatsDto>
            {
                new AIChatsDto
                {
                    Response = new List<MessageDto>
                    {
                        new MessageDto { Role = "user", ContentText = "Hello, how can I help you today?" },
                        new MessageDto { Role = "assistant", ContentText = "I am looking for legal advice regarding a contract." }
                    }
                },
                new AIChatsDto
                {
                    Response = new List<MessageDto>
                    {
                        new MessageDto { Role = "user", ContentText = "What are the key points to consider in a lease agreement?" },
                        new MessageDto { Role = "assistant", ContentText = "Key points include lease duration, payment terms, and termination clauses." }
                    }
                }
            };


            _mockLawAIService.Setup(service => service.GetChats(It.IsAny<int>()))
                             .ReturnsAsync(expectedChats);

            var result = await _controller.GetChats();
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var actualChats = okObjectResult.Value as List<AIChatsDto>;
            Assert.Equal(expectedChats, actualChats);
        }

        [Fact]
        public async Task SaveChat_ReturnsOk_WhenChatIsSaved()
        {
            _mockLawAIService.Setup(service => service.SaveChat(It.IsAny<int>(), null))
                             .ReturnsAsync(true);

            var result = await _controller.SaveChat(null);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);

            var expectedJson = "{\"Response\":\"Chat saved successfully\"}";
            var actualJson = JsonConvert.SerializeObject(okResult.Value);
            Assert.Equal(expectedJson, actualJson);
        }

        [Fact]
        public async Task SaveChat_ReturnsBadRequest_WhenExceptionOccurs()
        {
            _mockLawAIService.Setup(service => service.SaveChat(It.IsAny<int>(), null))
                             .ThrowsAsync(new Exception());
            var result = await _controller.SaveChat(null);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
