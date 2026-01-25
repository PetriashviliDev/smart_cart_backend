using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class NutritionPlanDraftRepository(
    IDatabaseContextFactory contextFactory)
    : Repository<NutritionPlanDraft, Guid>(contextFactory),
        INutritionPlanDraftRepository;