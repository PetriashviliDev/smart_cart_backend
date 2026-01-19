using Pgvector;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Domain.Repositories;

public interface IDishRepository : IRepository<Dish, int>
{
    Task<List<Dish>> SearchSimilarAsync(
        Vector queryEmbedding,
        int take = 50,
        double similarityThreshold = 0.7,
        CancellationToken ct = default);
}