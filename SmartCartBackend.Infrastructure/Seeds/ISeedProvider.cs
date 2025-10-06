using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCartBackend.Infrastructure.Seeds;

public interface ISeedProvider<out TEntity> 
    where TEntity : Enumeration
{
    IEnumerable<TEntity> GetSeeds();
}