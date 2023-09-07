using TestUp.Service.DTOs.Answer;
using TestUp.Service.DTOs.Exam;
using TestUp.Service.DTOs.Question;
using TestUp.Service.DTOs.User;

namespace TestUp.Service.DTOs.UserAnswer;

public class UserAnswerResultDto
{
    public UserResultDto User { get; set; }
    public ExamResultDto Exam { get; set; }
    public QuestionResultDto Question { get; set; }
    public AnswerResultDto Answer { get; set; }
}