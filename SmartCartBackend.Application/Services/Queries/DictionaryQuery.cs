using SmartCardBackend.Application.Extensions;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Attributes;
using SmartCardBackend.Domain.Entities.SeedWork;
using SmartCardBackend.Domain.Repositories;
using SmartCartBackend.Common.Extensions;

namespace SmartCardBackend.Application.Services.Queries;

public class DictionaryQuery(
    IEnumerationRepository repository) 
    : IDictionaryQuery
{
    public PageResponse<string> GetDictionaryTypes(int page, int size)
    {
        var all = typeof(DomainAssemblyReference)
            .Assembly
            .GetTypes()
            .Where(t => t.CustomAttributes.Any(a =>
                a.AttributeType == typeof(DictionaryAttribute)))
            .Select(t => t.Name)
            .ToList();
        
        var total = all.Count;

        var chunk = all
            .OrderBy(type => type)
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();

        return new PageResponse<string>(chunk, page, size, total);
    }

    public async Task<PageResponse<Pair<int>>> GetDictionaryAsync(
        string dictionaryName,
        int page, 
        int size,
        CancellationToken ct = default)
    {
        var type = typeof(DomainAssemblyReference)
            .Assembly
            .GetTypes()
            .SingleOrDefault(t => 
                t.CustomAttributes.Any(a => a.AttributeType == typeof(DictionaryAttribute)) 
                && t.Name.EqualsIgnoreCase(dictionaryName));

        if (type == null)
            return PageResponse<Pair<int>>.Default;
        
        var getter = repository
            .GetType()
            .GetMethod(nameof(IEnumerationRepository.GetEnumerationItemsAsync))?
            .MakeGenericMethod(type);

        var all = (await getter.InvokeAsync(repository, ct) as IEnumerable<Enumeration>)?.ToList() ?? [];

        var total = all.Count;

        var chunk = all
            .OrderBy(item => item.Order ?? int.MaxValue)
            .ThenBy(item => item.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .Select(i => new Pair<int> { Id = i.Id, Title = i.Title })
            .ToList();

        return new PageResponse<Pair<int>>(chunk, page, size, total);
    }
}