using API.Controllers;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CoreAppServer.Tests.Controllers
{
    public class DocumentGeneratorControllerTests
    {
        private readonly Mock<IDocumentGeneratorService> _mockDocumentGeneratorService;
        private readonly DocumentGeneratorController _controller;
        private readonly DocumentInfoDto _dto = new()
            {
                Title = "Test Document",
                Content = "This is a test document content.",
                Date = new DateTime(2023, 1, 1),
                Scale = 1,
                Footer = "Test Footer",
                Header = "Test Header",
                Type = "Letter",
                Recipient = "John Doe",
                RecipientAddress = "1234 Test Street, Test City, TC 12345",
                RecipientPhone = "123-456-7890",
                SenderPhone = "098-765-4321",
                Sender = "Jane Smith",
                City = "Test City"
            };
    public DocumentGeneratorControllerTests()
        {
            _mockDocumentGeneratorService = new Mock<IDocumentGeneratorService>();
            _controller = new DocumentGeneratorController(_mockDocumentGeneratorService.Object);
        }

        [Fact]
        public async Task GenerateDocument_ReturnsPdf_ForPdfType()
        {
            var expectedContent = new byte[] { };
            _mockDocumentGeneratorService.Setup(s => s.CreatePdf(It.IsAny<ControllerBase>(), It.IsAny<string>()))
                                         .Returns(new FileContentResult(expectedContent, "application/pdf"));

            var result = await _controller.GenerateDocument("pdf", _dto);

            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal("application/pdf", fileResult.ContentType);
        }

        [Fact]
        public async Task GenerateDocument_ReturnsDocx_ForDocxType()
        {
            var expectedContent = new byte[] { };
            _mockDocumentGeneratorService.Setup(s => s.CreateDocx(It.IsAny<ControllerBase>(), It.IsAny<string>()))
                                         .Returns(new FileContentResult(expectedContent, "application/vnd.openxmlformats-officedocument.wordprocessingml.document"));

            // Act
            var result = await _controller.GenerateDocument("docx", _dto);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal("application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileResult.ContentType);
            // Additional assertions as needed
        }

        [Fact]
        public async Task GenerateDocument_ReturnsBadRequest_ForInvalidType()
        {
            var result = await _controller.GenerateDocument("invalidType", _dto);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
