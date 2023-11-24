using Newtonsoft.Json;

namespace API.DTOs
{
    public class AIChatsDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("response")]
        public List<MessageDto> Response { get; set; }

    }
}
