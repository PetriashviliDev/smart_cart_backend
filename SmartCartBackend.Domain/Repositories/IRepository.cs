using System.Linq.Expressions;

namespace SmartCardBackend.Domain.Repositories;

public interface IRepository<TEntity> 
    where TEntity : class
{
    Task<List<TEntity>> FindManyAsync(
        Expression<Func<TEntity, bool>> expression,
        bool trackingEnabled = true,
        CancellationToken ct = default);

    Task<TEntity> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> expression, 
        bool trackingEnabled = true,
        CancellationToken ct = default);
    
    void Add(TEntity entity);
}