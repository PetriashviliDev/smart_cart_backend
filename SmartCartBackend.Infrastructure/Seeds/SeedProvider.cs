using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCartBackend.Infrastructure.Seeds;

public abstract class SeedProvider<TEntity> : ISeedProvider<TEntity>
    where TEntity : Enumeration
{
    public virtual IEnumerable<TEntity> GetSeeds() =>
        Enumeration.GetValues<TEntity>();
}