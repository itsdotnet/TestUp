namespace TestUp.Service.DTOs.Answer;

public class AnswerCreationDto
{
    public long QuestionId { get; set; }
    public long? AttachmentId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}