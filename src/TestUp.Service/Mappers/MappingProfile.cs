using AutoMapper;
using TestUp.Service.DTOs.User;
using TestUp.Service.DTOs.Exam;
using TestUp.Service.DTOs.Answer;
using TestUp.Service.DTOs.Result;
using TestUp.Service.DTOs.Question;
using TestUp.Service.DTOs.Attachment;
using TestUp.Service.DTOs.UserAnswer;
using TestUp.Service.DTOs.QuestionPack;

namespace TestUp.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Exam
        CreateMap<Exam, ExamResultDto>().ReverseMap();
        CreateMap<ExamUpdateDto, Exam>().ReverseMap();
        CreateMap<ExamCreationDto, Exam>().ReverseMap();

        //User
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserCreationDto, User>().ReverseMap();

        //Answer
        CreateMap<Answer, AnswerResultDto>().ReverseMap();
        CreateMap<AnswerUpdateDto, Answer>().ReverseMap();
        CreateMap<AnswerCreationDto, Answer>().ReverseMap();

        //Result
        CreateMap<Result, ResultResultDto>().ReverseMap();
        CreateMap<ResultUpdateDto, Result>().ReverseMap();
        CreateMap<ResultCrestionDto, Result>().ReverseMap();

        //Question
        CreateMap<Question, QuestionResultDto>().ReverseMap();
        CreateMap<QuestionUpdateDto, Question>().ReverseMap();
        CreateMap<QuestionCreationDto, Question>().ReverseMap();

        //Attachment
        CreateMap<Attachment, AttachmentResultDto>().ReverseMap();

        //UserAnswer
        CreateMap<UserAnswer, UserAnswerResultDto>().ReverseMap();
        CreateMap<UserAnswerUpdateDto, UserAnswer>().ReverseMap();
        CreateMap<UserAnswerCreationDto, UserAnswer>().ReverseMap();

        //QuestionPack
        CreateMap<QuestionPack, QuestionPackResultDto>().ReverseMap();
        CreateMap<QuestionPackUpdateDto, QuestionPack>().ReverseMap();
        CreateMap<QuestionPackCreationDto, QuestionPack>().ReverseMap();
    }
}