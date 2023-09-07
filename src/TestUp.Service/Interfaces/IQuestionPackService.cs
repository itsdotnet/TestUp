using TestUp.Service.DTOs.QuestionPack;

namespace TestUp.Service.Interfaces;

public interface IQuestionPackService
{
    Task DeleteAsync(long id);
    Task<IEnumerable<QuestionPack>> GetAllAsync();
    Task<QuestionPackResultDto> GetByIdAsync(long id);
    Task<IEnumerable<QuestionPack>> GetByExamIdAsync(long examId);
    Task<QuestionPackResultDto> UpdateAsync(QuestionPackUpdateDto questionPack);
    Task<QuestionPackResultDto> CreateAsync(QuestionPackCreationDto questionPack);
    Task<IEnumerable<QuestionPackResultDto>> ColloctAsync(QuestionPackCollectDto dto);
}