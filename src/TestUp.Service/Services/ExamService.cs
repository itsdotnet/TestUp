using AutoMapper;
using TestUp.DataAccess.IRepositories; // Replace with your repository namespace
using TestUp.Domain.Constans;
using TestUp.Service.DTOs.Exam;
using TestUp.Service.Exceptions;
using TestUp.Service.Interfaces;

namespace TestUp.Service.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        #pragma warning disable CS1998
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
            var endedExams = await _unitOfWork.ExamRepository.SelectAsync(e => e.EndTime < now);

            return _mapper.Map<IEnumerable<ExamResultDto>>(endedExams);
        }

        public async Task<IEnumerable<ExamResultDto>> FutureExams()
        {
            var now = Time.GetCurrentTime();
            var futureExams = await _unitOfWork.ExamRepository.SelectAsync(e => e.StartTime > now);

            return _mapper.Map<IEnumerable<ExamResultDto>>(futureExams);
        }

        public async Task<IEnumerable<ExamResultDto>> CurrentExams()
        {
            var now = Time.GetCurrentTime();
            var currentExams = await _unitOfWork.ExamRepository.SelectAsync(e => e.StartTime <= now && e.EndTime >= now);

            return _mapper.Map<IEnumerable<ExamResultDto>>(currentExams);
        }

        public async Task<ExamResultDto> ModifyAsync(ExamUpdateDto examUpdate)
        {
            var existingExam = await _unitOfWork.ExamRepository.SelectAsync(e => e.Id == examUpdate.Id);

            if (existingExam is null)
                throw new NotFoundException("Exam not found");

            _mapper.Map(examUpdate, existingExam);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<ExamResultDto>(existingExam);
        }

        public async Task<IEnumerable<ExamResultDto>> GetByTitleAsync(string title)
        {
            var examsWithTitle = await _unitOfWork.ExamRepository.SelectAsync(e => e.Title.Contains(title));

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
            var nearbyExams = await _unitOfWork.ExamRepository.SelectAsync(e => e.StartTime > dateTime.AddDays(-1) && e.StartTime < dateTime.AddDays(1));

            return _mapper.Map<IEnumerable<ExamResultDto>>(nearbyExams);
        }
    }
}
