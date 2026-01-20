using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.Nutrition.Pipeline;
using SmartCardBackend.Application.Nutrition.Pipeline.Steps;
using SmartCardBackend.Application.Services.Embedding;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Nutrition;

public static class NutritionSetup
{
    public static void AddNutritionServices(this IServiceCollection services)
    {
        services
            .AddScoped<INutritionPlanEnricher, NutritionPlanEnricher>()
            .AddScoped<IEmbeddingTextBuilder<Dish>, NutritionDishEmbeddingTextBuilder>()
            .AddScoped<INutritionPlanGenerationPipeline, NutritionPlanGenerationPipeline>()
            .AddScoped<INutritionPlanGenerationPipelineStep, QueryBuildingPipelineStep>()
            .AddScoped<INutritionPlanGenerationPipelineStep, QueryEmbeddingPipelineStep>()
            .AddScoped<INutritionPlanGenerationPipelineStep, DishesFilteringPipelineStep>()
            .AddScoped<INutritionPlanGenerationPipelineStep, DishesSearchingPipelineStep>()
            .AddScoped<INutritionPlanGenerationPipelineStep, GenerationPlanPipelineStep>();
    }
}