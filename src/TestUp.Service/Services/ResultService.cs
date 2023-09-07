using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestUp.DataAccess.IRepositories;
using TestUp.Service.DTOs.Result;
using TestUp.Service.Exceptions;
using TestUp.Service.Interfaces;

namespace TestUp.Service.Services;

public class ResultService:IResultService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ResultService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        await _unitOfWork.ResultRepository.DeleteAsync(result => result.Id == id);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<ResultResultDto>> GetAllAsync()
    {
        var results = await _unitOfWork.ResultRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<ResultResultDto>>(results);
    }

    public async Task<ResultResultDto> GetByIdAsync(long id)
    {
        var existResult = await _unitOfWork.ResultRepository
                              .SelectAsync(result => result.Id == id)
                          ?? throw new NotFoundException(message: "Result is not found!");

        return _mapper.Map<ResultResultDto>(existResult);
    }

    public async Task<IEnumerable<ResultResultDto>> GetByExamId(long examId)
    {
        var existResults = await _unitOfWork.ResultRepository
            .SelectAll(result => result.ExamId == examId).ToListAsync();

        return _mapper.Map<IEnumerable<ResultResultDto>>(existResults);
    }

    public async Task<IEnumerable<ResultResultDto>> GetByUserId(long userId)
    {
        var existResults = await _unitOfWork.ResultRepository
            .SelectAll(result => result.UserId == userId).ToListAsync();

        return _mapper.Map<IEnumerable<ResultResultDto>>(existResults);
    }

    #pragma warning disable
    public async Task<float> MyScore(long userId, long examId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultResultDto> UpdateAsync(ResultUpdateDto resultUpdate)
    {
        var existResult = await _unitOfWork.ResultRepository
                              .SelectAsync(result => result.Id == resultUpdate.Id)
                          ?? throw new NotFoundException(message: "Result is not found!");

        _mapper.Map(source: resultUpdate, destination: existResult);
        await _unitOfWork.ResultRepository.UpdateAsync(existResult);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ResultResultDto>(existResult);
    }

    public async Task<ResultResultDto> CreateAsync(ResultCrestionDto resultCreation)
    {
        var mappedResult = _mapper.Map<Result>(resultCreation);
        await _unitOfWork.ResultRepository.AddAsync(mappedResult);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ResultResultDto>(mappedResult);
    }
}