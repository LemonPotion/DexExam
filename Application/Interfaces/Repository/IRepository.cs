using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IRepository<TEntity>
{
    public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<List<TEntity>> GetAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>>? filter,
        CancellationToken cancellationToken);

    public TEntity Update(TEntity entity);

    public Task RemoveAsync(Guid id, CancellationToken cancellationToken);

    public Task SaveChangesAsync(CancellationToken cancellationToken);
}