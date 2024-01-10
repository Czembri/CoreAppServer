namespace API.Interfaces
{
    public interface IDocumentAnalyzerService
    {
        Task<string> AnalyzeDocument(IFormFile file);
    }
}
