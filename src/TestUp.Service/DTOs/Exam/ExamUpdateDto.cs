namespace TestUp.Service.DTOs.Exam;

public class ExamUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Password { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}