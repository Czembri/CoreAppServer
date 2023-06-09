using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserInfo UserInfo { get; set; }
        public ICollection<UserRole> UserRole{ get; set; }
    }
}