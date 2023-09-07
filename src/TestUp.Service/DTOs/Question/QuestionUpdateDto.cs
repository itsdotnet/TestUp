using TestUp.Domain.Enums;

namespace TestUp.Service.DTOs.Question;

public class QuestionUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public Level Level { get; set; }
    public string Description { get; set; }
    public long? AttachmentId { get; set; }
}
