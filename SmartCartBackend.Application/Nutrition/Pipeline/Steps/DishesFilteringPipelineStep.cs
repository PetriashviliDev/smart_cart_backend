using System.Linq.Expressions;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

/// <summary>
/// Предварительная фильтрация блюд по параметрам пользователя и требований к рациону
/// </summary>
public class DishesFilteringPipelineStep(
    IUnitOfWork uow)
    : INutritionPlanGenerationPipelineStep
{
    public async Task HandleAsync(
        NutritionPlanGenerationContext context, 
        CancellationToken ct = default)
    {
        // Фильтр по аллергиям и времени на приготовление
        var userAllergyIds = context.User.Allergies.Select(ua => ua.Id).ToList();
        var cookingTimeLimit = context.Requirements.CookingTimeInMinutes;

        Expression<Func<Dish, bool>> expr = dish => 
            (cookingTimeLimit == null || dish.CookingTime <= cookingTimeLimit) 
            && !dish.DishIngredients.Any(di => 
                di.Ingredient.IngredientAllergies.Any(ia => 
                    userAllergyIds.Contains(ia.AllergyId)));

        context.FilteredDishes = await uow.DishRepository
            .FindManyAsync(expr, trackingEnabled: false, ct: ct);
    }
}