using Pgvector;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Domain.Repositories;

public interface IDishRepository : IRepository<Dish, int>
{
    Task<List<Dish>> SearchSimilarAsync(
        Vector queryEmbedding,
        int batch,
        double similarityThreshold,
        CancellationToken ct = default);
}