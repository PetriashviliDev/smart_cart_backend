using Pgvector;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Domain;

namespace SmartCardBackend.Application.Services.Searchers;

public class DishSearcher(
    IUnitOfWork uow) 
    : IDishSearcher
{
    public async Task<List<Pair<int>>> SearchSimilarAsync(
        Vector queryEmbedding, 
        int take = 100, 
        double similarityThreshold = 0.7,
        CancellationToken ct = default)
    {
        var chunkSimilarDishes = (await uow.DishRepository
            .SearchSimilarAsync(queryEmbedding, take, similarityThreshold, ct))
            .Select(i => new Pair<int> { Id = i.Id, Title = i.Title })
            .ToList();

        return chunkSimilarDishes;
    }
}