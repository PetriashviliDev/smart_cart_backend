using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities.SeedWork;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public abstract class Repository<TEntity, TIdentifier>(
    IDatabaseContextFactory contextFactory) 
    : IRepository<TEntity, TIdentifier> 
    where TEntity : class, IHasId<TIdentifier>
{
    protected DatabaseContext Context => 
        contextFactory.GetOrCreateDbContext();
    
    protected virtual IQueryable<TEntity> Set => 
        Context.Set<TEntity>();
    
    public async Task<List<TEntity>> FindManyAsync(
        Expression<Func<TEntity, bool>> filter,
        Sort<TEntity> sort,
        int page = 1,
        int size = 30,
        bool trackingEnabled = true, 
        CancellationToken ct = default)
    {
        var query = Set.AsQueryable();
        
        if (filter != null)
            query = query.Where(filter);
        
        if (!trackingEnabled)
            query = query.AsNoTracking();
        
        sort ??= new Sort<TEntity>(e => e.Id);
        
        query = sort.Direction == SortDirection.Asc
            ? query
                .OrderBy(sort.KeySelector)
                .ThenBy(e => e.Id)
            : query
                .OrderByDescending(sort.KeySelector)
                .ThenByDescending(e => e.Id);
        
        query = query
            .Skip((page - 1) * size)
            .Take(size);
        
        var entities = await query.ToListAsync(ct);
        return entities;
    }

    public async Task<int> CountAsync(
        Expression<Func<TEntity, bool>> filter = null, 
        CancellationToken ct = default)
    {
        var query = Set.AsQueryable();
        
        if (filter != null)
            query = query.Where(filter);
        
        var count = await query.CountAsync(ct);
        return count;
    }

    public async Task<TEntity> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> filter, 
        bool trackingEnabled = true, 
        CancellationToken ct = default)
    {
        var query = Set.AsQueryable();
        
        if (!trackingEnabled)
            query = query.AsNoTracking();
        
        var entity = await query
            .SingleOrDefaultAsync(filter, ct);
        
        return entity;
    }

    public void Add(TEntity entity) => 
        Context.Set<TEntity>().Add(entity);

    public void AddRange(IEnumerable<TEntity> entities) =>
        Context.Set<TEntity>().AddRange(entities);
}