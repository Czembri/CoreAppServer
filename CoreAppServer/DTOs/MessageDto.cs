using Newtonsoft.Json;

namespace API.DTOs
{
    public class MessageDto
    {
        [JsonProperty("content")]
        public string ContentText { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
