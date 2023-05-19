using API.Enums;

namespace API.DTOs
{
    public class RolesDto
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
    }
}
