using System.Linq.Expressions;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Repositories;

public interface IRepository<TEntity, TIdentifier> 
    where TEntity : class, IHasId<TIdentifier>
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
    
    void AddRange(IEnumerable<TEntity> entities);
}