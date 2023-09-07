using TestUp.Service.DTOs.Answer;
using TestUp.Service.DTOs.UserAnswer;

namespace TestUp.Service.Interfaces;

public interface IUserAnswerInterface
{
    Task DeleteAsync(long id);
    Task<IEnumerable<UserAnswer>> GetAllAsync();
    Task<UserAnswerResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserAnswer>> GetByExamIdAsync(long examId);
    Task<IEnumerable<UserAnswer>> GetByUserIdAsync(long userId);
    Task<IEnumerable<UserAnswer>> GetByAnswerIdAsync(long answerId);
    Task<UserAnswerResultDto> UpdateAsync(UserAnswerUpdateDto userAnswerUpdate);
    Task<UserAnswerResultDto> CreateAsync(UserAnswerCreationDto userAnswerCreation);
}
