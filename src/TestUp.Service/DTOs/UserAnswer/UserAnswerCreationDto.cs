namespace TestUp.Service.DTOs.UserAnswer;

public class UserAnswerCreationDto
{
    public long UserId { get; set; }
    public long ExamId { get; set; }
    public long QuestionId { get; set; }
    public long AnswerId { get; set; }
}