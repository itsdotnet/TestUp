using TestUp.Service.DTOs.QuestionPack;

namespace TestUp.Service.Interfaces;

public interface IQuestionPackService
{
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<QuestionPack>> GetAllAsync();
    Task<QuestionPackResultDto> GetByIdAsync(long id);
    Task<IEnumerable<QuestionPack>> GetByExamIdAsync(long examId);
    Task<QuestionPackResultDto> ModifyAsync(QuestionPackUpdateDto questionPack);
    Task<QuestionPackResultDto> CreateAsync(QuestionPackCreationDto questionPack);
    Task<IEnumerable<QuestionPackResultDto>> CollectAsync(QuestionPackCollectDto dto);
}