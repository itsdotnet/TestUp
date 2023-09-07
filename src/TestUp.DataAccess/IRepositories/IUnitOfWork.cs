namespace TestUp.DataAccess.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> UserRepository { get; }
    IRepository<Exam> ExamRepository { get; }
    IRepository<Answer> AnswerRepository { get; }
    IRepository<Result> ResultRepository { get; }
    IRepository<Question> QuestionRepository { get; }
    IRepository<Attachment> AttachmentRepository { get; }
    IRepository<UserAnswer> UserAnswerRepository { get; }
    IRepository<QuestionPack> QuestionPackRepository { get; }
    Task<bool> SaveAsync();
}