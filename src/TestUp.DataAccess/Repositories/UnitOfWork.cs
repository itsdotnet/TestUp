using TestUp.DataAccess.Contexts;
using TestUp.DataAccess.Repository;
using TestUp.DataAccess.IRepositories;

namespace TestUp.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TestUpDbContext dbContext;

    public UnitOfWork(TestUpDbContext dbContext)
    {
        this.dbContext = dbContext;
        UserRepository = new Repository<User>(dbContext);
        ExamRepository = new Repository<Exam>(dbContext);
        AnswerRepository = new Repository<Answer>(dbContext);
        ResultRepository = new Repository<Result>(dbContext);
        QuestionRepository = new Repository<Question>(dbContext);
        PermissionRepository = new Repository<Permission>(dbContext);
        UserAnswerRepository = new Repository<UserAnswer>(dbContext);
        AttachmentRepository = new Repository<Attachment>(dbContext);
        QuestionPackRepository = new Repository<QuestionPack>(dbContext);
    }

    public IRepository<User> UserRepository { get; set; }
    public IRepository<Exam> ExamRepository { get; set; }
    public IRepository<Answer> AnswerRepository { get; set; }
    public IRepository<Result> ResultRepository { get; set; }
    public IRepository<Attachment> AttachmentRepository { get; set; }
    public IRepository<Question> QuestionRepository { get; set; }
    public IRepository<Permission> PermissionRepository { get; set; }
    public IRepository<UserAnswer> UserAnswerRepository { get; set; }
    public IRepository<QuestionPack> QuestionPackRepository { get; set; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task<bool> SaveAsync()
    {
        var saved = await this.dbContext.SaveChangesAsync();
        return saved > 0;
    }
}