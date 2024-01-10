using API.Interfaces;
using API.Utils.Constants;
using IronOcr;
using System.Text;
using System.Text.Json;

namespace API.Services
{
    public class DocumentAnalyzerService(IConfiguration config) : IDocumentAnalyzerService
    {
        private readonly string _openAIUrl = config["LawAiApiUrl"];
        private const string ContentType = "application/json";

        public async Task<string> AnalyzeDocument(IFormFile file)
        {
            string uploadsFolder = Path.Combine("UploadedFiles");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            IronTesseract ocr = new();
            ocr.Language = OcrLanguage.PolishBest;

            string text;
            using (var input = new OcrInput(filePath))
            {
                var result = ocr.Read(input);
                text = result.Text;
            }

            File.Delete(filePath);

            var apiResult = await CallOpenAI(text);
            return apiResult;
        }

        private async Task <string> CallOpenAI(string text)
        {
            var client = new HttpClient();

            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(new
            {
                query = text
            }), Encoding.UTF8, ContentType);


            httpContent.Headers.Add("X-App-Key", Headers.SecretHeader);

            var response = await client.PostAsync(_openAIUrl + OpenAI.AnalyzeDocumentEndpoint, httpContent);
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}
