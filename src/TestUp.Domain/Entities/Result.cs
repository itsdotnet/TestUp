using TestUp.Domain.Commons;

public class Result : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long ExamId { get; set; }
    public Exam Exam { get; set; }

    public float Score { get; set; }
}