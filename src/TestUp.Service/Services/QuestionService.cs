using TestUp.Service.Interfaces;
using TestUp.DataAccess.IRepositories;
using AutoMapper;
using TestUp.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using TestUp.Domain.Enums;
using TestUp.Service.DTOs.Question;
using TestUp.Service.DTOs.Attachment;

namespace TestUp.Service.Services;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAttachmentService _attachmentService;

    public QuestionService(IUnitOfWork unitOfWork, IAttachmentService attachmentService, IMapper mapper)
    {
        _attachmentService = attachmentService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);

        if (question is null)
            throw new NotFoundException("Question not found");

        await _unitOfWork.QuestionRepository.DeleteAsync(x =>x == question);
        await _unitOfWork.SaveAsync();

        return await _unitOfWork.SaveAsync();
    }

    public async Task<QuestionResultDto> GetByIdAsync(long id)
    {
        var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);

        if (question is null)
            throw new NotFoundException("Question not found");

        return _mapper.Map<QuestionResultDto>(question);
    }

    #pragma warning disable CS1998
    public async Task<IEnumerable<QuestionResultDto>> GetAllAsync()
    {
        var questions = _unitOfWork.QuestionRepository.SelectAll(includes: new[] { "User", "Attachment", "Answers" });

        return _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
    }

    public async Task<bool> ModifyImageAsync(long id, IFormFile image)
    {
        var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);

        if (question is null)
            throw new NotFoundException("Question not found");

        var attachment = await _attachmentService.UploadAsync(new AttachmentCreationDto { File = image });

        question.AttachmentId = attachment.Id;
        question.Attachment = attachment;
        
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<QuestionResultDto> ModifyAsync(QuestionUpdateDto dto)
    {
        var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == dto.Id);

        if (question is null)
            throw new NotFoundException("Question not found");

        _mapper.Map(dto, question);

        await _unitOfWork.SaveAsync();

        return _mapper.Map<QuestionResultDto>(question);
    }

    public async Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto)
    {
        var question = _mapper.Map<Question>(dto);

        await _unitOfWork.QuestionRepository.AddAsync(question);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<QuestionResultDto>(question);
    }

    public async Task<IEnumerable<QuestionResultDto>> GetByUserIdAsync(long userId)
    {
        var questions = await _unitOfWork.QuestionRepository.SelectAsync(q => q.UserId == userId,
            includes: new[] { "User", "Attachment", "Answers" });

        return _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
    }

    public async Task<IEnumerable<QuestionResultDto>> SearchAsync(string searchTerm)
    {
        var questions = _unitOfWork.QuestionRepository.SelectAll(q => q.Title.ToLower().Trim().Contains(searchTerm.ToLower()) ||
            q.Description.ToLower().Trim().Contains(searchTerm.ToLower()));

        return _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
    }

    public async Task<IEnumerable<QuestionResultDto>> GetByLevelAsync(long userId, Level level)
    {
        var questions = _unitOfWork.QuestionRepository.SelectAll(q => q.UserId == userId && q.Level == level,
            includes: new[] { "User", "Attachment", "Answers" });

        return _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
    }
}

