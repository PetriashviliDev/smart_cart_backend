using SmartCardBackend.Application.Nutrition.Pipeline.Models;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class QueryBuildingPipelineStep : INutritionPlanGenerationPipelineStep
{
    public Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        var breakfastPreferences = string.Join(", ", 
            context.User.BreakfastPreferences.Select(p => p.Title));
        
        var lunchPreferences = string.Join(", ", 
            context.User.LunchPreferences.Select(p => p.Title));
        
        var snackPreferences = string.Join(", ", 
            context.User.SnackPreferences.Select(p => p.Title));
        
        var dinnerPreferences = string.Join(", ", 
            context.User.DinnerPreferences.Select(p => p.Title));
        
        context.RawQuery = $$"""
                             - Цель: {{context.Requirements.Strategy.Title}}
                             - Приемов пищи в день: {{context.Requirements.MealsCountPerDay}}
                             - Время приготовления блюда: ≤ {{context.Requirements.CookingTimeInMinutes}} мин
                             - Предпочтения на завтрак: {{breakfastPreferences}} 
                             - Предпочтения на обед: {{lunchPreferences}} 
                             - Предпочтения на перекус: {{snackPreferences}} 
                             - Предпочтения на ужин: {{dinnerPreferences}} 
                             """;
        
        return Task.CompletedTask;
    }
}