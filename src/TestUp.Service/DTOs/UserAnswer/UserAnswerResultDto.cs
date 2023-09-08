using TestUp.Service.DTOs.User;
using TestUp.Service.DTOs.Exam;
using TestUp.Service.DTOs.Answer;
using TestUp.Service.DTOs.Question;

namespace TestUp.Service.DTOs.UserAnswer;

public class UserAnswerResultDto
{
    public long Id { get; set; }
    public UserResultDto User { get; set; }
    public ExamResultDto Exam { get; set; }
    public QuestionResultDto Question { get; set; }
    public AnswerResultDto Answer { get; set; }
}