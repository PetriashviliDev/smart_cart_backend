using Newtonsoft.Json;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Generators;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class GeneratedPlanSavingPipelineStep(
    JsonSerializerSettings serializerSettings,
    ISystemClock clock,
    IGuidGenerator guidGenerator,
    IUnitOfWork uow) 
    : INutritionPlanGenerationPipelineStep
{
    public async Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        var draft = NutritionPlanDraft.Create(
            guidGenerator.NewGuid,
            context.User.Id,
            JsonConvert.SerializeObject(context.GeneratedPlan, serializerSettings),
            clock.Now);
        
        uow.NutritionPlanDraftRepository.Add(draft);
        await uow.SaveChangesAsync(ct);

        context.PlanDraftId = draft.Id;
    }
}