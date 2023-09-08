using TestUp.Domain.Commons;

public class Exam : Auditable
{
    public string Title { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime StartTime { get; set; }
}