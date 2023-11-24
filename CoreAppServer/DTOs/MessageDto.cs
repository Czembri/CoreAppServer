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

    //public class LawAIResponse
    //{
    //    [JsonProperty("response")]
    //    public List<MessageDto> Contents { get; set; }
    //}
}
