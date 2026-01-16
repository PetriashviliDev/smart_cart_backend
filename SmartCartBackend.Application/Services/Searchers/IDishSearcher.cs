using Pgvector;
using SmartCardBackend.Application.Dto;

namespace SmartCardBackend.Application.Services.Searchers;

public interface IDishSearcher
{
    Task<List<DishDto>> SearchSimilarAsync(
        Vector queryEmbedding,
        int take = 50,
        double similarityThreshold = 0.7,
        CancellationToken ct = default);
}