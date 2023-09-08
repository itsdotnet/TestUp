using TestUp.Domain.Commons;
using System.Linq.Expressions;
using TestUp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using TestUp.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TestUp.DataAccess.Repository;
#pragma warning disable CS1998

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly DbSet<T> table;
    private readonly TestUpDbContext dbContext;

    public Repository(TestUpDbContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await table.AddAsync(entity);

        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        EntityEntry<T> entry = this.dbContext.Update(entity);

        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await this.SelectAsync(expression);

        if (entity is not null)
        {
            entity.IsDeleted = true;
            return true;
        }

        return false;
    }

    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null)
            => await this.SelectAll(expression, includes).FirstOrDefaultAsync(t => !t.IsDeleted);

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracking = true)
    {
        var query = expression is null ? isTracking ? table : table.AsNoTracking()
            : isTracking ? table.Where(expression) : table.Where(expression).AsNoTracking();

        query = query.Where(t => !t.IsDeleted);

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }
    
    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}