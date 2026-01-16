using Microsoft.EntityFrameworkCore;
using Pgvector;
using Pgvector.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class DishRepository(
    DatabaseContext context) 
    : Repository<Dish>(context), IDishRepository
{
    public async Task<List<Dish>> SearchSimilarAsync(
        Vector queryEmbedding, 
        int take = 50,
        double similarityThreshold = 0.7,
        CancellationToken ct = default)
    {
        var chunkSimilar = await Context.Dishes
            .Select(d => new
            {
               Dish = d,
               Similarity = 1 - d.DishEmbedding.Embedding.CosineDistance(queryEmbedding)
            })
            .Where(d => d.Similarity >= similarityThreshold)
            .OrderByDescending(d => d.Similarity)
            .Take(take)
            .ToListAsync(ct);
            
        return chunkSimilar.Select(item => item.Dish).ToList();
    }
}