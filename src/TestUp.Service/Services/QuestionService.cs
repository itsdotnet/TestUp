using TestUp.Service.Interfaces;
using TestUp.DataAccess.IRepositories;
using AutoMapper;
using TestUp.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using TestUp.Domain.Enums;
using TestUp.Service.DTOs.Question;

namespace TestUp.Service.Services;

public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);

            if (question is null)
                throw new NotFoundException("Question not found");

            _unitOfWork.QuestionRepository.Delete(question);
            await _unitOfWork.SaveChangesAsync();

            return true; // Deletion successful
        }

        public async Task<QuestionResultDto> GetByIdAsync(long id)
        {
            var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);

            if (question is null)
                throw new NotFoundException("Question not found");

            return _mapper.Map<QuestionResultDto>(question);
        }

        public async Task<IEnumerable<QuestionResultDto>> GetAllAsync()
        {
            var questions = await _unitOfWork.QuestionRepository.SelectAll(null, includes: new[] { "User", "Attachment" });

            return _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
        }

        public async Task<bool> ModifyImageAsync(long id, IFormFile image)
        {
            var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == id);

            if (question is null)
                throw new NotFoundException("Question not found");

            // Handle image modification here (e.g., save the new image)

            // Example: Save the new image to the file system
            // var imagePath = await _imageService.SaveImageAsync(image);

            // Update the question's image path
            // question.ImagePath = imagePath;

            await _unitOfWork.SaveChangesAsync();

            return true; // Modification successful
        }

        public async Task<QuestionResultDto> ModifyAsync(QuestionUpdateDto dto)
        {
            var question = await _unitOfWork.QuestionRepository.SelectAsync(q => q.Id == dto.Id);

            if (question is null)
                throw new NotFoundException("Question not found");

            // Update the question's properties based on the DTO
            _mapper.Map(dto, question);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuestionResultDto>(question);
        }

        public async Task<QuestionResultDto> CreateAsync(QuestionCreationDto dto)
        {
            // Create a new question entity based on the DTO
            var question = _mapper.Map<Question>(dto);

            // Add the question to the repository
            await _unitOfWork.QuestionRepository.AddAsync(question);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuestionResultDto>(question);
        }

        public async Task<IEnumerable<QuestionResultDto>> GetByUserIdAsync(long userId)
        {
            var questions = await _unitOfWork.QuestionRepository.SelectAsync(q => q.UserId == userId, includes: new[] { "User", "Attachment" });

            return _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
        }

        public async Task<IEnumerable<QuestionResultDto>> SearchAsync(string searchTerm)
        {
            var questions = await _unitOfWork.QuestionRepository.SearchAsync(searchTerm);

            return _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
        }

        public async Task<IEnumerable<QuestionResultDto>> GetByLevelAsync(long userId, Level level)
        {
            var questions = await _unitOfWork.QuestionRepository.SelectAsync(q => q.UserId == userId && q.Level == level, includes: new[] { "User", "Attachment" });

            return _mapper.Map<IEnumerable<QuestionResultDto>>(questions);
        }
    }

