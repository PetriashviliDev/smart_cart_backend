using Mapster;
using Pgvector;
using SmartCardBackend.Application.Dto;
using SmartCardBackend.Domain;

namespace SmartCardBackend.Application.Services.Searchers;

public class DishSearcher(
    IUnitOfWork uow) : IDishSearcher
{
    public async Task<List<DishDto>> SearchSimilarAsync(
        Vector queryEmbedding, 
        int take = 50, 
        double similarityThreshold = 0.7,
        CancellationToken ct = default)
    {
        var chunkSimilarDishes = await uow.DishRepository
            .SearchSimilarAsync(queryEmbedding, take, similarityThreshold, ct);

        return chunkSimilarDishes.Adapt<List<DishDto>>();
    }
}