using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using API.Utils.DocumentGenerator;
using Microsoft.AspNetCore.Authorization;
using API.Utils.Constants;

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

        [Authorize]
        [HttpPost("{type}")]
        public async Task<IActionResult> GenerateDocument(string type, [FromBody] DocumentInfoDto dto)
        {
            var query = DocumentContentBuilder.BuildDocumentContent(dto);

            using HttpClient client = new();
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(new
            {
                query
            }), Encoding.UTF8, ContentType);

            // commented for DEV purposes
            // TODO : uncomment for PROD
            httpContent.Headers.Add("X-App-Key", Headers.SecretHeader);
            HttpResponseMessage response = await client.PostAsync("http://localhost:8001/api/v1/document-generator", httpContent);
            var stringResponse = await response.Content.ReadAsStringAsync();

            //TODO : comment for PROD
            //var stringResponse = @"{
            //  ""response"": {
            //    ""content"": ""```\nWarszawa, dnia [data sporz\u0105dzenia dokumentu]\n\nS\u0105d Okr\u0119gowy w Warszawie\nWydzia\u0142 [podaj w\u0142a\u015bciwy wydzia\u0142]\nul. Marsza\u0142kowska 82\n00-001 Warszawa\n\nJan Kowalski\nul. Kowalskiego 1\n00-001 Warszawa\n\nDotyczy: Usprawiedliwienie nieobecno\u015bci na rozprawie w sprawie o sygn. 1x/23\n\nSzanowni Pa\u0144stwo,\n\nW zwi\u0105zku z moj\u0105 nieobecno\u015bci\u0105 podczas rozprawy w sprawie o sygn. 1x/23, kt\u00f3ra mia\u0142a miejsce dnia 15 listopada 2023 roku, pragn\u0119 przedstawi\u0107 usprawiedliwienie owej nieobecno\u015bci.\n\nZ powodu nag\u0142ego zaistnienia stanu zdrowia uniemo\u017cliwiaj\u0105cego mi stawienie si\u0119 w ww. terminie, jestem zmuszony przed\u0142o\u017cy\u0107 niniejszym wyja\u015bnienie, oraz do\u0142\u0105czam stosown\u0105 dokumentacj\u0119 medyczn\u0105 potwierdzaj\u0105c\u0105 moj\u0105 niemo\u017cno\u015b\u0107 stawiennictwa w powy\u017cszym terminie (za\u0142\u0105cznik nr 1).\n\nBior\u0105c pod uwag\u0119 powy\u017csze okoliczno\u015bci, prosz\u0119 o wyrozumia\u0142o\u015b\u0107 i wzi\u0119cie pod uwag\u0119 mojej sytuacji zdrowotnej, a tak\u017ce o ustalenie nowego terminu rozprawy, kt\u00f3ry pozwoli mi w pe\u0142ni zrealizowa\u0107 obowi\u0105zki procesowe.\n\nZ powa\u017caniem,\n[Podpis]\n\nZa\u0142\u0105czniki:\n1. Dokumentacja medyczna potwierdzaj\u0105ca niemo\u017cno\u015b\u0107 stawiennictwa w dniu 15.11.2023\n```\n\n[System wype\u0142ni dat\u0119 sporz\u0105dzenia dokumentu, zaznaczaj\u0105c j\u0105 w miejscu oznaczonym wy\u017cej jako \""[data sporz\u0105dzenia dokumentu]\"".]"",
            //    ""role"": ""assistant""
            //  }
            //}";
            var decoded = Regex.Unescape(stringResponse);
            var document = JsonSerializer.Deserialize<RootObject>(stringResponse);
            string textContent = document.Response.Content;

            return type switch
            {
                "pdf" => _documentGeneratorService.CreatePdf(this, textContent),
                "docx" => _documentGeneratorService.CreateDocx(this, textContent),
                _ => BadRequest("Invalid document type"),
            };
        }
    }
}
