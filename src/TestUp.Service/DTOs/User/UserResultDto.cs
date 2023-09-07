using TestUp.Domain.Enums;
using TestUp.Service.DTOs.Attachment;
using TestUp.Service.DTOs.Permission;

namespace TestUp.Service.DTOs.User;

public class UserResultDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    public AttachmentResultDto Attachment { get; set; }
    public PermissionResultDto Permission { get; set; }
}