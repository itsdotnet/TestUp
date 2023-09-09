5using AutoMapper;
using TestUp.Domain.Enums;
using TestUp.Service.Exceptions;
using TestUp.Service.Interfaces;
using TestUp.DataAccess.IRepositories;
using TestUp.Service.DTOs.QuestionPack;

namespace TestUp.Service.Services;
#pragma warning disable CS1998

public class QuestionPackService : IQuestionPackService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionService _questionService;

    public QuestionPackService(IUnitOfWork unitOfWork, IQuestionService questionService, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _questionService = questionService;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var questionPack = await _unitOfWork.QuestionPackRepository.SelectAsync(q => q.Id == id);

        if (questionPack is null)
            throw new NotFoundException("Question pack not found");

        await _unitOfWork.QuestionPackRepository.DeleteAsync(x => x == questionPack);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<QuestionPack>> GetAllAsync()
    {
        return _unitOfWork.QuestionPackRepository.SelectAll();
    }

    public async Task<QuestionPackResultDto> GetByIdAsync(long id)
    {
        var questionPack = await _unitOfWork.QuestionPackRepository.SelectAsync(q => q.Id == id);

        if (questionPack is null)
            throw new NotFoundException("Question pack not found");

        return _mapper.Map<QuestionPackResultDto>(questionPack);
    }

    public async Task<IEnumerable<QuestionPack>> GetByExamIdAsync(long examId)
    {
        return _unitOfWork.QuestionPackRepository.SelectAll(q => q.ExamId == examId);
    }

    public async Task<QuestionPackResultDto> ModifyAsync(QuestionPackUpdateDto questionPackUpdate)
    {
        var existingQuestionPack = await _unitOfWork.QuestionPackRepository.SelectAsync(q => q.Id == questionPackUpdate.Id);

        if (existingQuestionPack is null)
            throw new NotFoundException("Question pack not found");

        _mapper.Map(questionPackUpdate, existingQuestionPack);

        await _unitOfWork.SaveAsync();

        return _mapper.Map<QuestionPackResultDto>(existingQuestionPack);
    }

    public async Task<QuestionPackResultDto> CreateAsync(QuestionPackCreationDto questionPackCreation)
    {
        var newQuestionPack = _mapper.Map<QuestionPack>(questionPackCreation);

        await _unitOfWork.QuestionPackRepository.AddAsync(newQuestionPack);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<QuestionPackResultDto>(newQuestionPack);
    }

    public async Task<IEnumerable<QuestionPackResultDto>> CollectAsync(QuestionPackCollectDto dto)
    {
        Random random = new Random();
        var easyQuestions = (await _questionService.GetByLevelAsync(dto.UserId, Level.Easy)).OrderBy(x => random.Next()).ToList();
        var mediumQuestions = (await _questionService.GetByLevelAsync(dto.UserId, Level.Medium)).OrderBy(x => random.Next()).ToList();
        var hardQuestions = (await _questionService.GetByLevelAsync(dto.UserId, Level.Hard)).OrderBy(x => random.Next()).ToList();

        if (easyQuestions.Count() < dto.EasyCount)
            throw new CustomException(400, "Easy questions is not enough");

        if (mediumQuestions.Count() < dto.MediumCount)
            throw new CustomException(400, "Medium questions is not enough");

        if (hardQuestions.Count() < dto.HardCount)
            throw new CustomException(400, "Hard questions is not enough");

        easyQuestions = easyQuestions.Take(dto.EasyCount).ToList();
        easyQuestions.AddRange(mediumQuestions.Take(dto.MediumCount).ToList());
        easyQuestions.AddRange(hardQuestions.Take(dto.HardCount).ToList());

        foreach (var item in easyQuestions)
        {
            await CreateAsync(new QuestionPackCreationDto { ExamId = dto.ExamId, QuestionId = item.Id });
        }

        return _mapper.Map<IEnumerable<QuestionPackResultDto>>((await GetByExamIdAsync(dto.ExamId)));
    }
}