using TestUp.Service.DTOs.Attachment;
using TestUp.Service.DTOs.Question;

namespace TestUp.Service.DTOs.Answer;

public class AnswerResultDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public bool isCorrect { get; set; }

    public QuestionResultDto Question { get; set; }
    public AttachmentResultDto Attachment { get; set; }
}