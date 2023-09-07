namespace TestUp.Service.DTOs.QuestionPack;

public class QuestionPackResultDto
{
    public long Id { get; set; }
    public Question Question { get; set; }
    public Exam Exam { get; set; }
}