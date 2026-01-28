using SmartCardBackend.Application.Responses;
using SmartCardBackend.Domain;

namespace SmartCardBackend.Application.Services.Queries;

public interface IDictionaryQuery
{
    PageResponse<string> GetDictionaryTypes(
        int page, 
        int size);
    
    Task<PageResponse<Pair<int>>> GetDictionaryAsync(
        string dictionaryName,
        int page, 
        int size,
        CancellationToken ct = default);
}