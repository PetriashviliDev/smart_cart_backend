using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.Services.Queries;

public interface IDictionaryQuery
{
    Task<EntityListResponse> GetDictionaryTypesAsync(
        CancellationToken ct = default);
    
    Task<EntityListResponse> GetDictionaryAsync(
        string dictionaryName,
        CancellationToken ct = default);
}