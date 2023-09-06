using TestUp.Domain.Commons;

public class Answer : Auditable
{
    public long QuestionId { get; set; }
    public long AttachmentId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}