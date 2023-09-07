using TestUp.Service.DTOs.Answer;

namespace TestUp.Service.Interfaces;

public interface IAnswerService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<Answer>> GetAllAsync();
    Task<AnswerResultDto> GetByIdAsync(long id);
    Task<AnswerResultDto> ModifuAsync(AnswerUpdateDto answerUpdate);
    Task<AnswerResultDto> CreateAsync(AnswerCreationDto answerCreation);
}