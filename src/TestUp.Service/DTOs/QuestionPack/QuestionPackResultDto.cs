using TestUp.Service.DTOs.Exam;
using TestUp.Service.DTOs.Question;

namespace TestUp.Service.DTOs.QuestionPack;

public class QuestionPackResultDto
{
    public long Id { get; set; }
    public QuestionResultDto Question { get; set; }
    public ExamResultDto Exam { get; set; }
}