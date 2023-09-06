using TestUp.Domain.Commons;

public class UserAnswer : Auditable
{
    public long UserId { get; set; }
    public long ExamId { get; set; }
    public long QuestionId { get; set; }
    public long AnswerId { get; set; }
}