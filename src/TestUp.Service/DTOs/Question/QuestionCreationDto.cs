using TestUp.Domain.Enums;

namespace TestUp.Service.DTOs.Question;

public class QuestionCreationDto
{
    public string Title { get; set; }
    public Level Level { get; set; }
    public string Description { get; set; }
    public long? AttachmentId { get; set; }
}