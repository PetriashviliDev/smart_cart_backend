using Pgvector;
using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.Services.Searchers;

public interface IDishSearcher
{
    Task<List<Pair<int>>> SearchSimilarAsync(
        Vector queryEmbedding,
        int take = 100,
        double similarityThreshold = 0.7,
        CancellationToken ct = default);
}