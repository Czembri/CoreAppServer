using System.Net;

namespace API.DTOs
{
    public class HttpErrorDto
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Error { get; set; }
    }
}
