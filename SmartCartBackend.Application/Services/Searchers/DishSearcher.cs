using Pgvector;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Services.Searchers;

public class DishSearcher(
    IUnitOfWork uow) 
    : IDishSearcher
{
    public async Task<List<Dish>> SearchSimilarAsync(
        Vector queryEmbedding, 
        int batch, 
        double similarityThreshold,
        CancellationToken ct = default)
    {
        var chunkSimilarDishes = await uow.DishRepository
            .SearchSimilarAsync(queryEmbedding, batch, similarityThreshold, ct);

        return chunkSimilarDishes;
    }
}