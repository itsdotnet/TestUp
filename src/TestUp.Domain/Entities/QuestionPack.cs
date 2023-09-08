using TestUp.Domain.Commons;

public class QuestionPack : Auditable
{
    public long QuestionId { get; set; }
    public Question Question { get; set; }

    public long ExamId { get; set; }
    public Exam Exam { get; set; }
}