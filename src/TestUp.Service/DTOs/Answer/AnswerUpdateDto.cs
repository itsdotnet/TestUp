namespace TestUp.Service.DTOs.Answer;

public class AnswerUpdateDto
{
    public long Id { get; set; }
    public bool isCorrect { get; set; }
    public string Text { get; set; }

    public long QuestionId { get; set; }
    public long? AttachmentId { get; set; }
}