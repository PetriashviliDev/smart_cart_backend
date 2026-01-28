using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class NutritionPlanChoiceRepository(
    IDatabaseContextFactory contextFactory)
    : Repository<NutritionPlanChoice, Guid>(contextFactory),
        INutritionPlanChoiceRepository
{
    protected override IQueryable<NutritionPlanChoice> Set => base.Set
        .Include(x => x.Dish)
        .Include(x => x.MealType)
        .Include(x => x.Plan);
}