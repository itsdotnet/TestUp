using TestUp.Domain.Commons;
using TestUp.Domain.Enums;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public long AttachmentId { get; set; }
    public long PermissionId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
}