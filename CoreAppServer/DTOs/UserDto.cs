using API.Enums;

namespace API.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public IList<string> Role { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}