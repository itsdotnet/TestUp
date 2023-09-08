using Microsoft.EntityFrameworkCore;

namespace TestUp.DataAccess.Contexts;

public class TestUpDbContext : DbContext
{
    public TestUpDbContext(DbContextOptions<TestUpDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<QuestionPack> QuestionPacks { get; set; }
}