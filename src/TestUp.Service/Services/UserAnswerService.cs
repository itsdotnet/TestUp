using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestUp.DataAccess.IRepositories;
using TestUp.Service.DTOs.UserAnswer;
using TestUp.Service.Exceptions;
using TestUp.Service.Interfaces;

namespace TestUp.Service.Services;

public class UserAnswerService:IUserAnswerInterface
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserAnswerService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        await _unitOfWork.UserAnswerRepository.DeleteAsync(userAnswer => userAnswer.Id == id);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<UserAnswerResultDto>> GetAllAsync()
    {
        var userAnswers =await _unitOfWork.UserAnswerRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<UserAnswerResultDto>>(userAnswers);
    }

    public async Task<UserAnswerResultDto> GetByIdAsync(long id)
    {
        var existUserAnswer = await _unitOfWork.UserAnswerRepository
                                  .SelectAsync(userAnswer => userAnswer.Id == id)
                              ?? throw new NotFoundException(message: "UserAnswer is not found!");

        return _mapper.Map<UserAnswerResultDto>(existUserAnswer);
    }

    public async Task<IEnumerable<UserAnswerResultDto>> GetByExamIdAsync(long examId)
    {
        var existUserAnswer = await _unitOfWork.UserAnswerRepository
            .SelectAll(userAnswer => userAnswer.AnswerId == examId).ToListAsync();
        
        return _mapper.Map<IEnumerable<UserAnswerResultDto>>(existUserAnswer);
    }

    public async Task<IEnumerable<UserAnswerResultDto>> GetByUserIdAsync(long userId)
    {
        var existUserAnswer = await _unitOfWork.UserAnswerRepository
            .SelectAll(userAnswer => userAnswer.AnswerId == userId).ToListAsync();
        
        return _mapper.Map<IEnumerable<UserAnswerResultDto>>(existUserAnswer);
    }

    public async Task<IEnumerable<UserAnswerResultDto>> GetByAnswerIdAsync(long answerId)
    {
        var existUserAnswer = await _unitOfWork.UserAnswerRepository
            .SelectAll(userAnswer => userAnswer.AnswerId == answerId).ToListAsync();
        
        return _mapper.Map<IEnumerable<UserAnswerResultDto>>(existUserAnswer);
    }

    public async Task<UserAnswerResultDto> ModifyAsync(UserAnswerUpdateDto userAnswerUpdate)
    {
        var existUserAnswer = await _unitOfWork.UserAnswerRepository
                                  .SelectAsync(userAnswer => userAnswer.Id == userAnswerUpdate.Id)
                              ?? throw new NotFoundException(message: "UserAnswer is not found!");

        _mapper.Map(source: userAnswerUpdate, destination: existUserAnswer);
        await _unitOfWork.UserAnswerRepository.UpdateAsync(existUserAnswer);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserAnswerResultDto>(existUserAnswer);
    }

    #pragma warning disable 
    public async Task<UserAnswerResultDto> CreateAsync(UserAnswerCreationDto userAnswerCreation)
    {
        var existUser = await _unitOfWork.UserRepository
                            .SelectAsync(user => user.Id == userAnswerCreation.UserId)
                                ?? throw new NotFoundException(message: "User is not found!");

        var existExam = await _unitOfWork.ExamRepository
                            .SelectAsync(exam => exam.Id == userAnswerCreation.ExamId)
                                ?? throw new NotFoundException(message: "Exam is not found!");

        var existQuestion = await _unitOfWork.QuestionRepository
                                .SelectAsync(question => question.Id == userAnswerCreation.QuestionId)
                                    ?? throw new NotFoundException(message: "Question is not found!");

        var existAnswer = await _unitOfWork.AnswerRepository
                              .SelectAsync(answer => answer.Id == userAnswerCreation.AnswerId)
                                 ?? throw new NotFoundException(message: "Answer is not found!");

        var mappedUserAnswer = _mapper.Map<UserAnswer>(userAnswerCreation);
        await _unitOfWork.UserAnswerRepository.AddAsync(mappedUserAnswer);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserAnswerResultDto>(mappedUserAnswer);
    }
}