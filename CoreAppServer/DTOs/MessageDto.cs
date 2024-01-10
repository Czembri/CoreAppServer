using Newtonsoft.Json;

namespace API.DTOs
{
    public class MessageDto
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
