using Microsoft.Extensions.DependencyInjection;
using TestUp.DataAccess.IRepositories;
using TestUp.DataAccess.Repositories;
using TestUp.DataAccess.Repository;
using TestUp.Service.Interfaces;
using TestUp.Service.Mappers;
using TestUp.Service.Services;

namespace TestUp.WebApi.Extensions;

public static class ServiceCollections
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<IUserService/*, UserService*/>();
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IResultService/*, ResultService*/>();
        services.AddScoped<IUserAnswerService, UserAnswerService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IAttachmentService, AttachmentService>();
        services.AddScoped<IQuestionPackService, QuestionPackService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MappingProfile));
    }
}
