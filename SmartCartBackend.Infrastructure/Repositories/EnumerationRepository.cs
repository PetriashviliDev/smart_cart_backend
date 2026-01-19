using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities.SeedWork;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

/// <inheritdoc />
public class EnumerationRepository(
    IUnitOfWork uow) 
    : IEnumerationRepository
{
    /// <inheritdoc />
    public async Task<List<TEnumeration>> GetEnumerationItemsAsync<TEnumeration>(
        CancellationToken ct = default) 
        where TEnumeration : ActualizedEnumeration<TEnumeration>
    {
        var context = ((UnitOfWork)uow).Context;
        
        var items = await context
            .Set<TEnumeration>()
            .ToListAsync(ct);
        
        return items;
    }

    /// <inheritdoc />
    public async Task CreateOrUpdateEnumerationItem<TEnumeration>(
        TEnumeration enumeration, 
        CancellationToken ct = default) 
        where TEnumeration : ActualizedEnumeration<TEnumeration>
    {
        var context = ((UnitOfWork)uow).Context;
        
        var entity = await context
            .Set<TEnumeration>()
            .FindAsync([enumeration.Id], ct);
        
        if (entity == null)
            context.Set<TEnumeration>()
                .Add(enumeration);
        else
            entity.Actualize(enumeration);
        
        await context.SaveChangesAsync(ct);
    }

    /// <inheritdoc />
    public async Task DeleteEnumerationItem<TEnumeration>(
        int id, 
        CancellationToken ct = default) 
        where TEnumeration : ActualizedEnumeration<TEnumeration>
    {
        var context = ((UnitOfWork)uow).Context;
        
        var entity = await context
            .Set<TEnumeration>()
            .FindAsync([id], ct);
        
        if (entity == null)
            return;
        
        context
            .Set<TEnumeration>()
            .Remove(entity);
        
        await context.SaveChangesAsync(ct);
    }
}