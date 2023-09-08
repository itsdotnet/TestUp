using TestUp.Service.DTOs.Exam;
using TestUp.Service.DTOs.User;

namespace TestUp.Service.DTOs.Result;

public class ResultResultDto
{
	public long Id { get; set; }
    public UserResultDto User { get; set; }

    public ExamResultDto Exam { get; set; }

    public float Score { get; set; }
}