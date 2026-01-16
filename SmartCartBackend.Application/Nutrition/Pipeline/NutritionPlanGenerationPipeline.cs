using Microsoft.Extensions.Logging;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Nutrition.Pipeline.Steps;
using SmartCardBackend.Domain;

namespace SmartCardBackend.Application.Nutrition.Pipeline;

public class NutritionPlanGenerationPipeline(
    ILogger<NutritionPlanGenerationPipeline> logger,
    IUnitOfWork uow,
    IEnumerable<INutritionPlanGenerationPipelineStep> steps) : INutritionPlanGenerationPipeline
{
    public async Task<NutritionPlanGenerationResult> GenerateAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        var localTransactionBegin = await uow.TryBeginTransactionAsync(ct);

        try
        {
            foreach (var step in steps)
                await step.HandleAsync(context, ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Возникла ошибка в RagPipeline");
            
            if (localTransactionBegin)
                await uow.TryRollbackTransactionAsync(ct);

            throw;
        }
        
        return new NutritionPlanGenerationResult();
    }
}