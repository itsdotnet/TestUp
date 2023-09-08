using AutoMapper;
using TestUp.Domain.Constans;
using TestUp.Service.DTOs.Exam;
using TestUp.Service.Exceptions;
using TestUp.Service.Interfaces;
using TestUp.DataAccess.IRepositories;

namespace TestUp.Service.Services; 
#pragma warning disable CS1998

public class ExamService : IExamService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var exam = await _unitOfWork.ExamRepository.SelectAsync(e => e.Id == id);

        if (exam is null)
            throw new NotFoundException("Exam not found");

        await _unitOfWork.ExamRepository.DeleteAsync(x => x == exam);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> SearchExamAsync(long id)
    {
        var exam = _unitOfWork.ExamRepository.SelectAll().FirstOrDefault(i => i.Id.Equals(id));

        if (exam is null)
            return false;

        return true;
    }

    public async Task<IEnumerable<Exam>> GetAllAsync()
    {
        return _unitOfWork.ExamRepository.SelectAll();
    }

    public async Task<ExamResultDto> GetByIdAsync(long id)
    {
        var exam = await _unitOfWork.ExamRepository.SelectAsync(e => e.Id == id);

        if (exam is null)
            throw new NotFoundException("Exam not found");

        return _mapper.Map<ExamResultDto>(exam);
    }

    public async Task<IEnumerable<ExamResultDto>> EndedExams()
    {
        var now = Time.GetCurrentTime();
        var endedExams = _unitOfWork.ExamRepository.SelectAll(e => e.EndTime < now);

        return _mapper.Map<IEnumerable<ExamResultDto>>(endedExams);
    }

    public async Task<IEnumerable<ExamResultDto>> FutureExams()
    {
        var now = Time.GetCurrentTime();
        var futureExams = _unitOfWork.ExamRepository.SelectAll(e => e.StartTime > now);

        return _mapper.Map<IEnumerable<ExamResultDto>>(futureExams);
    }

    public async Task<IEnumerable<ExamResultDto>> CurrentExams()
    {
        var now = Time.GetCurrentTime();
        var currentExams = _unitOfWork.ExamRepository.SelectAll(e => e.StartTime <= now && e.EndTime >= now);

        return _mapper.Map<IEnumerable<ExamResultDto>>(currentExams);
    }

    public async Task<ExamResultDto> ModifyAsync(ExamUpdateDto examUpdate)
    {
        var existingExam = await _unitOfWork.ExamRepository.SelectAsync(e => e.Id == examUpdate.Id);

        if (existingExam is null)
            throw new NotFoundException("Exam not found");

        _mapper.Map(examUpdate, existingExam);
        await _unitOfWork.ExamRepository.UpdateAsync(existingExam);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ExamResultDto>(existingExam);
    }

    public async Task<IEnumerable<ExamResultDto>> GetByTitleAsync(string title)
    {
        var examsWithTitle = _unitOfWork.ExamRepository.SelectAll(e => e.Title.Contains(title));

        return _mapper.Map<IEnumerable<ExamResultDto>>(examsWithTitle);
    }

    public async Task<ExamResultDto> CreateAsync(ExamCreationDto examCreation)
    {
        var newExam = _mapper.Map<Exam>(examCreation);

        await _unitOfWork.ExamRepository.AddAsync(newExam);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ExamResultDto>(newExam);
    }

    public async Task<IEnumerable<ExamResultDto>> GetByNearExamAsync(DateTime dateTime)
    {
        var nearbyExams = _unitOfWork.ExamRepository.SelectAll(e => e.StartTime > dateTime.AddDays(-1) && e.StartTime < dateTime.AddDays(1)).ToList();

        return _mapper.Map<IEnumerable<ExamResultDto>>(nearbyExams);
    }
}
