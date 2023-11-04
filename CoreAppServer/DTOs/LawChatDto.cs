namespace API.DTOs
{
    public class LawChatDto
    {
        public int UserId { get; set; }
        public MessageDto[] Messages { get; set; }
    }
}
