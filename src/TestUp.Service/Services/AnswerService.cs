using TestUp.Service.Interfaces;
using TestUp.DataAccess.IRepositories;
using TestUp.Service.DTOs.Answer;
using AutoMapper;
using TestUp.Service.Exceptions;
using System;
using TestUp.DataAccess.Repository;

namespace TestUp.Service.Services;

public class AnswerService : IAnswerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var answer = await _unitOfWork.AnswerRepository.SelectAsync(x => x.Id == id);

        if (answer is null)
            throw new NotFoundException("Answer not found");

        await _unitOfWork.AnswerRepository.DeleteAsync(x => x == answer);
        return await _unitOfWork.SaveAsync();
    }

    #pragma warning disable CS1998
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
            if(existingAttachment is null)
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
}