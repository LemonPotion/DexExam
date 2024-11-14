using System.Linq.Expressions;
using Application.Interfaces;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ExamContext _dbContext;
    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    protected BaseRepository(ExamContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    public virtual async Task<List<TEntity>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<TEntity, bool>>? filter, CancellationToken cancellationToken)
    {
        var query = DbSet.AsNoTracking().AsQueryable();
        if (filter is not null)
        {
            query = query.Where(filter);
        }

        return await query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public virtual TEntity Update(TEntity entity)
    {
        DbSet.Update(entity);
        return entity;
    }

    public virtual async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity is not null)
        {
            DbSet.Remove(entity);
        }
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}