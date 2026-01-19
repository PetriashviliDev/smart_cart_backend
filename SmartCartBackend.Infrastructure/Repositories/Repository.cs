using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities.SeedWork;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public abstract class Repository<TEntity, TIdentifier>(
    DatabaseContext context) 
    : IRepository<TEntity, TIdentifier> 
    where TEntity : class, IHasId<TIdentifier>
{
    protected DatabaseContext Context => context;
    
    protected virtual DbSet<TEntity> Set => Context.Set<TEntity>();
    
    public async Task<List<TEntity>> FindManyAsync(
        Expression<Func<TEntity, bool>> expression, 
        bool trackingEnabled = true, 
        CancellationToken ct = default)
    {
        var query = Set.AsQueryable();
        
        if (expression != null)
            query = query.Where(expression);
        
        if (!trackingEnabled)
            query = query.AsNoTracking();
        
        var entities = await query.ToListAsync(ct);
        return entities;
    }

    public async Task<TEntity> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> expression, 
        bool trackingEnabled = true, 
        CancellationToken ct = default)
    {
        var query = Set.AsQueryable();
        
        if (!trackingEnabled)
            query = query.AsNoTracking();
        
        var entity = await query.SingleOrDefaultAsync(expression, ct);
        return entity;
    }

    public void Add(TEntity entity) => Set.Add(entity);
}