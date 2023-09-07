using TestUp.Domain.Commons;
using TestUp.Domain.Enums;

public class User : Auditable
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public ICollection<Result> Results { get; set; }
    public ICollection<UserAnswer> Answers { get; set; }
    public ICollection<Question> Questions { get; set; }
}