using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace API.Controllers
{
    public class DocumentGeneratorController : BaseApiController
    {
        private readonly IDocumentGeneratorService _documentGeneratorService;
        private const string ContentType = "application/json";
        public DocumentGeneratorController(IDocumentGeneratorService documentGeneratorService)
        {
            _documentGeneratorService = documentGeneratorService;

        }

        [HttpPost]
        public async Task<IActionResult> GenerateDocument(DocumentInfoDto dto)
        {
            // TODO: MOCK
            var city = "Poznań";
            var n = "Maksio zoo";
            var a = "Adam zoo";

            var query = @$"Tytuł dokumentu: {dto.Title}\n
            Zawartość dokumentu: {dto.Content}\n
            Miejscowość (gdzie podpisano dokument): {city}\n
            Nadawca: {n}\n
            Adresat: {a}";
            using HttpClient client = new();
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(new
            {
                query = query
            }), Encoding.UTF8, ContentType);
            HttpResponseMessage response = await client.PostAsync("http://localhost:8001/api/v1/document-generator", httpContent);

            var stringResponse  = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                response = stringResponse
            });
        }
    }
}
