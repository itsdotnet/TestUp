using TestUp.Service.DTOs.Result;

namespace TestUp.Service.Interfaces;

public interface IResultService
{
    Task<bool> DeleteAsync(long id);
    Task<ResultResultDto> GetByIdAsync(long id);
    Task<float> MyScore(long userId, long examId);
    Task<IEnumerable<ResultResultDto>> GetAllAsync();
    Task<IEnumerable<ResultResultDto>> GetByExamId(long examId);
    Task<IEnumerable<ResultResultDto>> GetByUserId(long userId);
    Task<ResultResultDto> UpdateAsync(ResultUpdateDto resultUpdate);
    Task<ResultResultDto> CreateAsync(ResultCrestionDto resultCreation);
}