using TestUp.Service.DTOs.Exam;
using TestUp.Service.DTOs.Answer;

namespace TestUp.Service.Interfaces;

public interface IExamService
{
    Task<bool> DeleteAsync(long id);
    Task<bool> SearchExamAsync(long id);
    Task<IEnumerable<Exam>> GetAllAsync();
    Task<ExamResultDto> GetByIdAsync(long id);
    Task<IEnumerable<ExamResultDto>> EndedExams();
    Task<IEnumerable<ExamResultDto>> FutureExams();
    Task<IEnumerable<ExamResultDto>> CurrentExams();
    Task<ExamResultDto> ModifyAsync(ExamUpdateDto examUpdate);
    Task<IEnumerable<ExamResultDto>> GetByTitleAsync(string title);
    Task<ExamResultDto> CreateAsync(ExamCreationDto examCreation);
    Task<IEnumerable<ExamResultDto>> GetByNearExamAsync(DateTime dateTime);
}