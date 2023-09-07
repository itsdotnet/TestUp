using TestUp.Service.DTOs.UserAnswer;

namespace TestUp.Service.Interfaces;

public interface IUserAnswerInterface
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserAnswer>> GetAllAsync();
    Task<UserAnswerResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserAnswer>> GetByExamIdAsync(long examId);
    Task<IEnumerable<UserAnswer>> GetByUserIdAsync(long userId);
    Task<IEnumerable<UserAnswer>> GetByAnswerIdAsync(long answerId);
    Task<UserAnswerResultDto> ModifyAsync(UserAnswerUpdateDto userAnswerUpdate);
    Task<UserAnswerResultDto> CreateAsync(UserAnswerCreationDto userAnswerCreation);
}