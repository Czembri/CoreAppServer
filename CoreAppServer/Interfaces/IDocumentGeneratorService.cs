using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IDocumentGeneratorService
    {
        FileContentResult CreatePdf(ControllerBase controller, string textContent);
        FileContentResult CreateDocx(ControllerBase controller, string textContent);
    }
}
