using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class NutritionPlanRepository(
    IDatabaseContextFactory contextFactory)
    : Repository<NutritionPlan, Guid>(contextFactory),
        INutritionPlanRepository
{
    protected override IQueryable<NutritionPlan> Set => base.Set
        .Include(x => x.User)
        .Include(x => x.Draft);
}