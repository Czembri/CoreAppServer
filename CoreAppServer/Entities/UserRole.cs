using API.Enums;

namespace API.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
