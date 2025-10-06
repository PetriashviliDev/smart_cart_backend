using System.Collections;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities.SeedWork;
using SmartCartBackend.Infrastructure.Seeds;

namespace SmartCartBackend.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static void AddSeeds(this ModelBuilder modelBuilder)
    {
        var seedProviderTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => !x.IsAbstract && x.GetInterfaces().Any(i => 
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISeedProvider<>)));
        
        foreach (var seedProviderType in seedProviderTypes)
        {
            var method = seedProviderType.GetMethod(nameof(ISeedProvider<Enumeration>.GetSeeds));
            
            var seeds = (method!.Invoke(Activator.CreateInstance(
                seedProviderType), null) as IEnumerable)!.OfType<object>();
            
            var interfaceType = seedProviderType.GetInterfaces().Single();
            var entityType = interfaceType.GenericTypeArguments.Single();

            modelBuilder.Entity(entityType).HasData(seeds);
        }
    }
}