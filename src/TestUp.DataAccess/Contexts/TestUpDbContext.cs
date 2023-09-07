using Microsoft.EntityFrameworkCore;
using TestUp.Domain.Constans;

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
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<QuestionPack> QuestionPacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region SeedData

        modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = 1, Get = true, Create = true, Update = true, Delete = true, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 2, Get = true, Create = true, Update = true, Delete = false, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 3, Get = true, Create = true, Update = false, Delete = true, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 4, Get = true, Create = true, Update = false, Delete = false, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 5, Get = true, Create = false, Update = true, Delete = true, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 6, Get = true, Create = false, Update = true, Delete = false, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 7, Get = true, Create = false, Update = false, Delete = true, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 8, Get = true, Create = false, Update = false, Delete = false, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 9, Get = false, Create = true, Update = true, Delete = true, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 10, Get = false, Create = true, Update = true, Delete = false, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 11, Get = false, Create = true, Update = false, Delete = true, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 12, Get = false, Create = true, Update = false, Delete = false, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 13, Get = false, Create = false, Update = true, Delete = true, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 14, Get = false, Create = false, Update = true, Delete = false, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 15, Get = false, Create = false, Update = false, Delete = true, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false },
            new Permission { Id = 16, Get = false, Create = false, Update = false, Delete = false, CreatedAt = Time.GetCurrentTime(), UpdatedAt = Time.GetCurrentTime(), IsDeleted = false });

        #endregion
    }
}