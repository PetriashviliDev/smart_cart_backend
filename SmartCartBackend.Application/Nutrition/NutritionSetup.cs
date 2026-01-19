using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.Nutrition.Pipeline;
using SmartCardBackend.Application.Nutrition.Pipeline.Steps;

namespace SmartCardBackend.Application.Nutrition;

public static class NutritionSetup
{
    public static void AddNutritionServices(this IServiceCollection services)
    {
        services
            .AddScoped<INutritionPlanEnricher, NutritionPlanEnricher>()
            .AddScoped<INutritionPlanGenerationPipeline, NutritionPlanGenerationPipeline>()
            .AddScoped<INutritionPlanGenerationPipelineStep, QueryBuildingPipelineStep>()
            .AddScoped<INutritionPlanGenerationPipelineStep, QueryEmbeddingPipelineStep>()
            .AddScoped<INutritionPlanGenerationPipelineStep, DishesFilteringPipelineStep>()
            .AddScoped<INutritionPlanGenerationPipelineStep, DishesSearchingPipelineStep>()
            .AddScoped<INutritionPlanGenerationPipelineStep, GenerationPlanPipelineStep>();
    }
}