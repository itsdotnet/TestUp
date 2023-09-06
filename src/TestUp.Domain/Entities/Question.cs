using TestUp.Domain.Commons;
using TestUp.Domain.Enums;

public class Question : Auditable
{
    public string Title { get; set; }
    public Level Level { get; set; }
    public string Description { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public ICollection<Answer> Answers { get; set;}
}