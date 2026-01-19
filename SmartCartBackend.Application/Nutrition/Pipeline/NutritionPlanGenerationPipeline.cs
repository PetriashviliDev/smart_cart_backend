using Mapster;
using Microsoft.Extensions.Logging;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Nutrition.Pipeline.Steps;
using SmartCardBackend.Domain;

namespace SmartCardBackend.Application.Nutrition.Pipeline;

public class NutritionPlanGenerationPipeline(
    ILogger<NutritionPlanGenerationPipeline> logger,
    IUnitOfWork uow,
    IEnumerable<INutritionPlanGenerationPipelineStep> steps) 
    : INutritionPlanGenerationPipeline
{
    public async Task<NutritionPlanGenerationResult> GenerateAsync(
        NutritionPlanGenerationRequest request, 
        CancellationToken ct = default)
    {
        var context = request.Adapt<NutritionPlanGenerationContext>();
        
        await uow.TryBeginTransactionAsync(ct);

        try
        {
            foreach (var step in steps)
                await step.HandleAsync(context, ct);

            await uow.TryCommitTransactionAsync(ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Возникла ошибка при создании рациона питания");
            
            await uow.TryRollbackTransactionAsync(ct);

            throw;
        }
        
        return new NutritionPlanGenerationResult { Plan = context.GeneratedPlan };
    }
}