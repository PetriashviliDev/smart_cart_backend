using SmartCardBackend.Application.Nutrition.Dto;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Application.Nutrition;

public class NutritionPlanEnricher(
    IUnitOfWork uow) 
    : INutritionPlanEnricher
{
    public async Task<NutritionPlanDto> EnrichAsync(
        NutritionPlanDto plan, 
        CancellationToken ct = default)
    {
        var mealTypes = Enumeration
            .GetCached<MealType>()
            .ToDictionary(mt => mt.Id);

        var dishIds = plan.Days
            .SelectMany(d => d.Meals)
            .SelectMany(m => m.Dishes)
            .SelectMany(d => new[] { d.Id }.Concat(d.Alternatives.Select(a => a.Id)))
            .ToList();
        
        var dishes = (await uow.DishRepository.FindManyAsync(
            dish => dishIds.Contains(dish.Id),
            trackingEnabled: false, 
            ct: ct))
            .ToDictionary(d => d.Id);

        var enrichmentPlan = new NutritionPlanDto();

        foreach (var day in plan.Days)
        {
            var enrichmentDay = new NutritionPlanDayDto
            {
                Number = day.Number, 
                Meals = []
            };

            foreach (var meal in day.Meals)
            {
                var enrichmentMeal = new NutritionMealDto
                {
                    Type = meal.Type with
                    {
                        Title = mealTypes[meal.Type.Id].Title
                    },
                    Dishes = []
                };

                foreach (var dish in meal.Dishes)
                {
                    var storedDish = dishes[dish.Id];

                    var enrichmentDish = new NutritionPlanDishDto
                    {
                        Id = dish.Id,
                        Title = storedDish.Title,
                        Image = storedDish.Image,
                        CookingTimeInMinutes = storedDish.CookingTime,
                        Calories = storedDish.TotalCalories,
                        Ingredients = [],
                        Alternatives = []
                    };

                    foreach (var ingredient in dish.Ingredients)
                    {
                        var enrichmentIngredient = ingredient with { 
                            Category = new Pair<int>
                        {
                            Id = ingredient.Category.Id, 
                            Title = ingredient.Category.Title
                        }, 
                            Unit = new Pair<int>
                        {
                            Id = ingredient.Unit.Id, 
                            Title = ingredient.Unit.Title
                        } };
                        
                        enrichmentDish.Ingredients.Add(enrichmentIngredient);
                    }

                    foreach (var alternative in dish.Alternatives)
                    {
                        var storedAlternative = dishes[alternative.Id];

                        var enrichmentAlternative = new NutritionPlanAlternativeDishDto
                        {
                            Id = alternative.Id,
                            Title = storedAlternative.Title,
                            Image = storedAlternative.Image,
                            CookingTimeInMinutes = storedAlternative.CookingTime,
                            Calories = storedAlternative.TotalCalories
                        };
                        
                        foreach (var ingredient in alternative.Ingredients)
                        {
                            var enrichmentIngredient = ingredient with { 
                                Category = new Pair<int>
                                {
                                    Id = ingredient.Category.Id, 
                                    Title = ingredient.Category.Title
                                }, 
                                Unit = new Pair<int>
                                {
                                    Id = ingredient.Unit.Id, 
                                    Title = ingredient.Unit.Title
                                } };
                        
                            enrichmentAlternative.Ingredients.Add(enrichmentIngredient);
                        }
                        
                        enrichmentDish.Alternatives.Add(enrichmentAlternative);
                    }
                    
                    enrichmentMeal.Dishes.Add(enrichmentDish);
                }
                
                enrichmentDay.Meals.Add(enrichmentMeal);
            }
            
            enrichmentPlan.Days.Add(enrichmentDay);
        }

        return enrichmentPlan;
    }
}