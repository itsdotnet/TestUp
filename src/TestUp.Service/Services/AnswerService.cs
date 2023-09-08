using AutoMapper;
using TestUp.Service.Exceptions;
using TestUp.Service.Interfaces;
using TestUp.Service.DTOs.Answer;
using TestUp.DataAccess.IRepositories;

namespace TestUp.Service.Services;
#pragma warning disable CS1998

public class AnswerService : IAnswerService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var answer = await _unitOfWork.AnswerRepository.SelectAsync(x => x.Id == id);

        if (answer is null)
            throw new NotFoundException("Answer not found");

        await _unitOfWork.AnswerRepository.DeleteAsync(x => x == answer);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<Answer>> GetAllAsync()
    {
        return _unitOfWork.AnswerRepository.SelectAll(null, new string[] { "Question", "Attachment" });
    }

    public async Task<AnswerResultDto> GetByIdAsync(long id)
    {
        var answer = await _unitOfWork.AnswerRepository.SelectAsync(x => x.Id == id, new string[] { "Question", "Attachment" });

        if (answer is null)
            throw new NotFoundException("Answer not found");

        return _mapper.Map<AnswerResultDto>(answer);
    }

    public async Task<AnswerResultDto> ModifyAsync(AnswerUpdateDto answerUpdate)
    {
        var existingAnswer = await _unitOfWork.AnswerRepository.SelectAsync(x => x.Id == answerUpdate.Id);
        var existingQuestion = await _unitOfWork.QuestionRepository.SelectAsync(x => x.Id == answerUpdate.QuestionId);

        if (answerUpdate.AttachmentId is not null)
        {
            var existingAttachment = await _unitOfWork.AttachmentRepository.SelectAsync(x => x.Id == answerUpdate.AttachmentId);
            if (existingAttachment is null)
                throw new NotFoundException("Image not found");
        }

        if (existingAnswer is null)
            throw new NotFoundException("Answer not found");

        if (existingQuestion is null)
            throw new NotFoundException("Question not found");

        _mapper.Map(answerUpdate, existingAnswer);

        await _unitOfWork.AnswerRepository.UpdateAsync(existingAnswer);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<AnswerResultDto>(existingAnswer);
    }

    public async Task<AnswerResultDto> CreateAsync(AnswerCreationDto answerCreation)
    {
        var existingQuestion = await _unitOfWork.QuestionRepository.SelectAsync(x => x.Id == answerCreation.QuestionId);

        if (answerCreation.AttachmentId is not null)
        {
            var existingAttachment = await _unitOfWork.AttachmentRepository.SelectAsync(x => x.Id == answerCreation.AttachmentId);
            if (existingAttachment is null)
                throw new NotFoundException("Image not found");
        }

        if (existingQuestion is null)
            throw new NotFoundException("Question not found");

        var newAnswer = _mapper.Map<Answer>(answerCreation);

        await _unitOfWork.AnswerRepository.AddAsync(newAnswer);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<AnswerResultDto>(newAnswer);
    }

    public async Task<IEnumerable<AnswerResultDto>> GetByQuestionIdAsync(long questionId)
    {
        var existingQuestion = await _unitOfWork.QuestionRepository.SelectAsync(x => x.Id == questionId);

        if (existingQuestion is null)
            throw new NotFoundException("Question not found");

        var answers = await _unitOfWork.AnswerRepository
            .SelectAsync(x => x.QuestionId == questionId, new string[] { "Question", "Attachment" });
        return _mapper.Map<IEnumerable<AnswerResultDto>>(answers);
    }
}