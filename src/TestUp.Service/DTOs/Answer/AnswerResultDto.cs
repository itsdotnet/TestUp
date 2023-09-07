namespace TestUp.Service.DTOs.Answer;

public class AnswerResultDto
{
    public long Id { get; set; }
    public long QuestionId { get; set; }
    public long? AttachmentId { get; set; }
    public string Text { get; set; }
}