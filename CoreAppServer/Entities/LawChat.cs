using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class LawChat
    {
        public int Id { get; set; }
        public string Messages { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("LawChatUserIds")]
        public AppUser AppUser { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
