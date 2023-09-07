using TestUp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using TestUp.Service.DTOs.Question;

namespace TestUp.Service.Interfaces;

public interface IQuestionService
{
    Task<bool> DeleteAsync(long id);
    Task<QuestionResultDto> GetByIdAsync(long id);
    Task<IEnumerable<QuestionResultDto>> GetAllAsync();
    Task<bool> ModifyImageAsync(long id, IFormFile image);
    Task<QuestionResultDto> ModifyAsync(QuestionUpdateDto dto);
    Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto);
    Task<IEnumerable<QuestionResultDto>> GetByUserIdAsync(long userId);
    Task<IEnumerable<QuestionResultDto>> SearchAsync(string searchTerm);
    Task<IEnumerable<QuestionResultDto>> GetByLevelAsync(long userId, Level level);
}