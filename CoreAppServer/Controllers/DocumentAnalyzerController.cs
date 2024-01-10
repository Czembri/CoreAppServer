using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.DTOs;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class DocumentAnalyzerController : BaseApiController
    {
        private readonly IDocumentAnalyzerService _documentAnalyzerService;
        public DocumentAnalyzerController(IDocumentAnalyzerService documentAnalyzerService)
        {
            _documentAnalyzerService = documentAnalyzerService;

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AnalyzeDocument([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file provided");

            var result = await _documentAnalyzerService.AnalyzeDocument(file);

            var deserialized = JsonConvert.DeserializeObject<AIChatDto>(result);

            return Ok(new
            {
                response= deserialized.Response.Content
            });
        }

    }
}
