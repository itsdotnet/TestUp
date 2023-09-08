using TestUp.Domain.Commons;

public class UserAnswer : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long ExamId { get; set; }
    public Exam Exam { get; set; }

    public long QuestionId { get; set; }
    public Question Question { get; set; }  

    public long AnswerId { get; set; }
    public Answer Answer { get; set; }
}