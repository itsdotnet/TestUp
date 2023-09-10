using TestUp.Domain.Enums;
using TestUp.Service.DTOs.Attachment;

namespace TestUp.Service.DTOs.User;

public class UserResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public UserRole UserRole { get; set; }
    public AttachmentResultDto Attachment { get; set; }
}