using TestUp.Service.DTOs.Answer;
using TestUp.Service.DTOs.Exam;

namespace TestUp.Service.Interfaces;

public interface IExamService
{
    Task DeleteAsync(long id);
    Task<IEnumerable<Exam>> GetAllAsync();
    Task<ExamResultDto> GetByIdAsync(long id);
    Task<IEnumerable<ExamResultDto>> EndedExams();
    Task<IEnumerable<ExamResultDto>> FutureExams();
    Task<IEnumerable<ExamResultDto>> CurrentExams();
    Task<IEnumerable<ExamResultDto>> GetByTitleAsync(string title);
    Task<ExamResultDto> UpdateAsync(ExamUpdateDto examUpdate);
    Task<ExamResultDto> CreateAsync(AnswerCreationDto answerCreation);
    Task<IEnumerable<ExamResultDto>> GetByNearExamAsync(DateTime dateTime);
}