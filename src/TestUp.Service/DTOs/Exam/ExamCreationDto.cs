namespace TestUp.Service.DTOs.Exam;

public class ExamCreationDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Password { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}