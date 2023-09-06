using TestUp.Domain.Commons;

public class Result : Auditable
{
    public long UserId { get; set; }
    public long ExamId { get; set; }
    public float Score { get; set; }
}