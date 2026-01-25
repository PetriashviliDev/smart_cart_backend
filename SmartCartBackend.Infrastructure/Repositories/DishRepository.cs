using Microsoft.EntityFrameworkCore;
using Pgvector;
using Pgvector.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class DishRepository(
    IDatabaseContextFactory contextFactory) 
    : Repository<Dish, int>(contextFactory), 
        IDishRepository
{
    protected override IQueryable<Dish> Set => 
        Context.Dishes
            .Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                    .ThenInclude(i => i.IngredientAllergies)
                        .ThenInclude(i => i.Allergy)
            .Include(d => d.DishEmbedding)
            .Include(d => d.Difficulty)
            .Include(d => d.MealType)
            .Include(d => d.DishTags)
                .ThenInclude(dt => dt.Tag)
            .Include(d => d.DishCategory);

    public async Task<List<Dish>> SearchSimilarAsync(
        Vector queryEmbedding, 
        int batch,
        double similarityThreshold,
        CancellationToken ct = default)
    {
        var chunkSimilar = await Set
            .Select(d => new
            {
               Dish = d,
               Similarity = 1 - d.DishEmbedding.Embedding.CosineDistance(queryEmbedding)
            })
            .Where(d => d.Similarity >= similarityThreshold)
            .OrderByDescending(d => d.Similarity)
            .Take(batch)
            .ToListAsync(ct);
            
        return chunkSimilar.Select(item => item.Dish).ToList();
    }
}