using System.Linq.Expressions;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Responses;
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
        Expression<Func<Dish, bool>> expr = dish => !dish.Ingredients.Any(i => 
            i.Allergies.Any(a => context.User.Allergies.Select(ua => ua.Id).Contains(a.Id) 
                                 && dish.CookingTime <= context.Requirements.CookingTimeInMinutes));

        var dishes = await uow.DishRepository
            .FindManyAsync(expr, trackingEnabled: false, ct: ct);
        
        context.FilteredDishes = dishes.Select(d => 
            new Pair<int>{ Id = d.Id, Title = d.Title}).ToList();
    }
}