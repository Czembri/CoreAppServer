using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class ConstitutionChat
    {
        public int Id { get; set; }
        public string ResponsesAndQuestions { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserIds")]
        public AppUser AppUser { get; set; }
    }
}
