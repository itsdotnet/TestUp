using TestUp.Domain.Enums;
using TestUp.Service.DTOs.User;
using TestUp.Service.DTOs.Attachment;

namespace TestUp.Service.DTOs.Question;

public class QuestionResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public Level Level { get; set; }
    public string Description { get; set; }

    public UserResultDto User { get; set; }
    public AttachmentResultDto Attachment { get; set; }
}