using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class IngredientRepository(
    IDatabaseContextFactory contextFactory)
    : Repository<Ingredient, int>(contextFactory),
        IIngredientRepository
{
    protected override IQueryable<Ingredient> Set => 
        Context.Ingredients
            .Include(i => i.IngredientAllergies)
                .ThenInclude(ia => ia.Allergy);
}