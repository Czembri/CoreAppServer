namespace API.DTOs;

public class AppUserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime ModificationDate { get; set; }
    public DateTime CreationDate { get; set; }
    public UserInfoDto UserInfo { get; set; }
    public List<UserRoleDto> UserRole{ get; set; }
}