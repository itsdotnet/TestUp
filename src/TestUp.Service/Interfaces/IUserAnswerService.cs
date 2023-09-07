using TestUp.Service.DTOs.UserAnswer;

namespace TestUp.Service.Interfaces;

public interface IUserAnswerService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserAnswerResultDto>> GetAllAsync();
    Task<UserAnswerResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserAnswerResultDto>> GetByExamIdAsync(long examId);
    Task<IEnumerable<UserAnswerResultDto>> GetByUserIdAsync(long userId);
    Task<IEnumerable<UserAnswerResultDto>> GetByAnswerIdAsync(long answerId);
    Task<UserAnswerResultDto> ModifyAsync(UserAnswerUpdateDto userAnswerUpdate);
    Task<UserAnswerResultDto> CreateAsync(UserAnswerCreationDto userAnswerCreation);
}