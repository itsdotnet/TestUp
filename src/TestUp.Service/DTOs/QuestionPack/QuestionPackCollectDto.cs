namespace TestUp.Service.DTOs.QuestionPack;

public class QuestionPackCollectDto
{
    public long UserId { get; set; }
    public long ExamId { get; set; }
    public int EasyCount { get; set; }
    public int MediumCount { get; set; }
    public int HardCount { get; set; }
}