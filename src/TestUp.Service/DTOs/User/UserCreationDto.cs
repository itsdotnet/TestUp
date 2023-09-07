using TestUp.Domain.Enums;

namespace TestUp.Service.DTOs.User;

public class UserCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }

    public long? AttachmentId { get; set; }

    public long PermissionId { get; set; }
}
