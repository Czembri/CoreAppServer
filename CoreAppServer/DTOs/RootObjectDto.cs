using System.Text.Json.Serialization;

namespace API.DTOs
{
    public class RootObject
    {
        [JsonPropertyName("response")]
        public ResponseContent Response { get; set; }
    }

    public class ResponseContent
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
