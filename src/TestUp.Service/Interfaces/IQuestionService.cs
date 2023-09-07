using Microsoft.AspNetCore.Http;
using TestUp.Domain.Enums;
using TestUp.Service.DTOs.Question;

namespace TestUp.Service.Interfaces;

public interface IQuestionService
{
    Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto);

    Task<QuestionResultDto> UpdateAsync(QuestionUpdateDto dto);

    Task<bool> DeleteAsync(long id);

    Task<QuestionResultDto> GetByIdAsync(long id);

    Task<IEnumerable<QuestionResultDto>> GetAllAsync();

    Task<IEnumerable<QuestionResultDto>> GetByUserIdAsync(long userId);

    Task<IEnumerable<QuestionResultDto>> GetByLevelAsync(long userId, Level level);

    Task<IEnumerable<QuestionResultDto>> SearchAsync(string searchTerm);

    Task<bool> UpdateImageAsync(long id, IFormFile image);
}