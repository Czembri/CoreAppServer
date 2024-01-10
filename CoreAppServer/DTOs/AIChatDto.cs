using Newtonsoft.Json;

namespace API.DTOs
{
    public class AIChatDto
    {
        [JsonProperty("response")]
        public MessageDto Response { get; set; }
    }
}
