using TestUp.Service.DTOs.Answer;
using TestUp.Service.DTOs.Result;

namespace TestUp.Service.Interfaces;

public interface IResultService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<ResultResultDto>> GetAllAsync();
    Task<ResultResultDto> GetByIdAsync(long id);
    Task<IEnumerable<ResultResultDto>> GetByExamId(long examId);
    Task<IEnumerable<ResultResultDto>> GetByUserId(long userId);
    Task<float> MyScore(long userId, long examId);
    Task<ResultResultDto> UpdateAsync(ResultUpdateDto resultUpdate);
    Task<ResultResultDto> CreateAsync(ResultCrestionDto resultCreation);
}
