using System.Linq.Expressions;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Repositories;

public interface IRepository<TEntity, TIdentifier> 
    where TEntity : class, IHasId<TIdentifier>
{
    Task<List<TEntity>> FindManyAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Sort<TEntity> sort = null,
        int page = 1,
        int size = 30,
        bool trackingEnabled = true,
        CancellationToken ct = default);

    Task<int> CountAsync(
        Expression<Func<TEntity, bool>> filter = null,
        CancellationToken ct = default);

    Task<TEntity> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> filter, 
        bool trackingEnabled = true,
        CancellationToken ct = default);
    
    void Add(TEntity entity);
    
    void AddRange(IEnumerable<TEntity> entities);
}