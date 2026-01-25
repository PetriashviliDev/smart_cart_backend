using System.Text;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Embedding;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class QueryBuildingPipelineStep(
    IEmbeddingTextBuilder<Dish> textBuilder,
    IUnitOfWork uow) 
    : INutritionPlanGenerationPipelineStep
{
    public async Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        var breakfastDishIds = context.User.PreferenceDishes
            .Where(d => d.MealTypeId == MealType.Breakfast.Id)
            .Select(p => p.Id)
            .ToList();
        
        var lunchDishIds = context.User.PreferenceDishes
            .Where(d => d.MealTypeId == MealType.Lunch.Id)
            .Select(p => p.Id)
            .ToList();
        
        var snackDishIds = context.User.PreferenceDishes
            .Where(d => d.MealTypeId == MealType.Snack.Id)
            .Select(p => p.Id)
            .ToList();
        
        var dinnerDishIds = context.User.PreferenceDishes
            .Where(d => d.MealTypeId == MealType.Dinner.Id)
            .Select(p => p.Id)
            .ToList();
        
        var preferenceDishIds = breakfastDishIds
            .Concat(lunchDishIds)
            .Concat(snackDishIds)
            .Concat(dinnerDishIds)
            .Distinct()
            .ToList();

        var preferenceDishes = await uow.DishRepository.FindManyAsync(
            dish => preferenceDishIds.Contains(dish.Id),
            trackingEnabled: false,
            ct: ct);
        
        var breakfastDishes = preferenceDishes
            .Where(p => breakfastDishIds.Contains(p.Id))
            .ToList();
        
        var lunchDishes = preferenceDishes
            .Where(p => lunchDishIds.Contains(p.Id))
            .ToList();
        
        var snackDishes = preferenceDishes
            .Where(p => snackDishIds.Contains(p.Id))
            .ToList();
        
        var dinnerDishes = preferenceDishes
            .Where(p => dinnerDishIds.Contains(p.Id))
            .ToList();

        var rawQueryBuilder = new StringBuilder($"Цель: {context.Requirements.Strategy.Title}{Environment.NewLine}");
        rawQueryBuilder.AppendLine($"{Environment.NewLine}Предпочтения на завтрак:");

        foreach (var dish in breakfastDishes)
            rawQueryBuilder.AppendLine(textBuilder.BuildFor(dish));
        
        rawQueryBuilder.AppendLine("Предпочтения на обед:");
        foreach (var dish in lunchDishes)
            rawQueryBuilder.AppendLine(textBuilder.BuildFor(dish));
        
        rawQueryBuilder.AppendLine("Предпочтения на перекус:");
        foreach (var dish in snackDishes)
            rawQueryBuilder.AppendLine(textBuilder.BuildFor(dish));
        
        rawQueryBuilder.AppendLine("Предпочтения на ужин:");
        foreach (var dish in dinnerDishes)
            rawQueryBuilder.AppendLine(textBuilder.BuildFor(dish));
        
        context.RawQuery = rawQueryBuilder.ToString();
    }
}