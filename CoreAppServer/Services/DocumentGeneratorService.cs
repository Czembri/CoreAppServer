using API.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using PdfParagraph = iTextSharp.text.Paragraph;

namespace API.Services
{
    public class DocumentGeneratorService : IDocumentGeneratorService
    {
        public FileContentResult CreatePdf(ControllerBase controller, string textContent)
        {
            using MemoryStream memoryStream = new();
            iTextSharp.text.Document pdfDoc = new(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            pdfDoc.Open();
            pdfDoc.Add(new PdfParagraph(textContent));
            pdfDoc.Close();

            byte[] bytes = memoryStream.ToArray();
            return controller.File(bytes, "application/pdf; charset=utf-8", "filename.pdf");
        }

        public FileContentResult CreateDocx(ControllerBase controller, string textContent)
        {
            using MemoryStream memoryStream = new();
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(memoryStream, WordprocessingDocumentType.Document, true))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                string[] lines = textContent.Split('\n');
                foreach (string line in lines)
                {
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    run.AppendChild(new Text(line));
                }
            }

            byte[] bytes = memoryStream.ToArray();
            return controller.File(bytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "filename.docx");
        }

    }
}
