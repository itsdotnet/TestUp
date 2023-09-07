using TestUp.Domain.Enums;

namespace TestUp.Service.DTOs.User;

public class UserResultDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    public Attachment Attachment { get; set; }
    public Permission Permission { get; set; }
}
