using Microsoft.Extensions.Logging;
using SmartCardBackend.Application.Extensions;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities.SeedWork;
using SmartCardBackend.Domain.Repositories;
using SmartCartBackend.Common.Extensions;

namespace SmartCardBackend.Application.Services.Actualizers;

public class EnumerationActualizer(
    ILogger<EnumerationActualizer> logger,
    IEnumerationRepository repository) 
    : IEnumerationActualizer
{
    public async Task ActualizeAsync(CancellationToken ct = default)
    {
        var actualizeType = typeof(IActualizable<>);

        var enumerationTypes = typeof(DomainAssemblyReference)
            .Assembly
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => 
                    i.IsGenericType && i.GetGenericTypeDefinition() == actualizeType))
            .ToList();
        
        Enumeration.Flush();

        foreach (var enumerationType in enumerationTypes)
        {
            try
            {
                var getter = repository
                    .GetType()
                    .GetMethod(nameof(IEnumerationRepository.GetEnumerationItemsAsync))?
                    .MakeGenericMethod(enumerationType);

                if (getter == null || await getter.InvokeAsync(repository, ct)
                        is not IEnumerable<dynamic> providedItems)
                    continue;

                var cachedItems = Enumeration.GetCached(enumerationType).ToList();

                foreach (var providedItem in providedItems)
                {
                    dynamic cachedItem = cachedItems.FirstOrDefault(i => i.Id == providedItem.Id);

                    if (cachedItem == null)
                    {
                        Enumeration.Add(providedItem);
                        continue;
                    }

                    cachedItem.Actualize(providedItem);
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, $"Ошибка при актуализации справочника {enumerationType.Name}");
            }
        }
    }
}