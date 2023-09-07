using TestUp.Service.DTOs.Answer;
using TestUp.Service.DTOs.Result;

namespace TestUp.Service.Interfaces;

public interface IResultService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<Result>> GetAllAsync();
    Task<ResultResultDto> GetByIdAsync(long id);
    Task<IEnumerable<Result>> GetByExamId(long examId);
    Task<IEnumerable<Result>> GetByUserId(long userId);
    Task<float> MyScore(long UserId, long ExamId);
    Task<ResultResultDto> UpdateAsync(ResultUpdateDto resultUpdate);
    Task<ResultResultDto> CreateAsync(ResultCrestionDto resultCreation);
}
