using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public abstract class Repository<TEntity>(
    DatabaseContext context) : IRepository<TEntity> 
    where TEntity : class
{
    protected DatabaseContext Context => context;
    
    public async Task<List<TEntity>> GetAllAsync(
        bool trackingEnabled = true, 
        CancellationToken ct = default)
    {
        var query = Context.Set<TEntity>().AsQueryable();
        
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
        var query = Context.Set<TEntity>().AsQueryable();
        
        if (!trackingEnabled)
            query = query.AsNoTracking();
        
        var entity = await query.SingleOrDefaultAsync(expression, ct);
        return entity;
    }

    public void Add(TEntity entity) =>
        context.Set<TEntity>().Add(entity);
}