using System.Text.RegularExpressions;
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
    public async Task<NutritionPlanResponse> EnrichAsync(
        NutritionPlanResponse plan, 
        CancellationToken ct = default)
    {
        var mealTypes = Enumeration
            .GetCached<MealType>()
            .ToDictionary(mt => mt.Id);

        var dishIds = plan.Days
            .SelectMany(d => d.Meals)
            .SelectMany(m => m.Groups)
            .SelectMany(m => m.Dishes)
            .Select(d => d.Id)
            .ToList();
        
        var dishes = (await uow.DishRepository.FindManyAsync(
            dish => dishIds.Contains(dish.Id),
            trackingEnabled: false, 
            ct: ct))
            .ToDictionary(d => d.Id);

        var enrichmentPlan = new NutritionPlanResponse();
        var groupId = 1;

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
                    Groups = []
                };

                foreach (var group in meal.Groups)
                {
                    var enrichmentGroup = new NutritionPlanMealGroupDto
                    {
                        Id = groupId++,
                        Dishes = []
                    };
                    
                    foreach (var dish in group.Dishes)
                    {
                        var storedDish = dishes[dish.Id];

                        var enrichmentDish = new NutritionPlanDishDto
                        {
                            Id = dish.Id,
                            Title = storedDish.Title,
                            Description = storedDish.Description,
                            Image = storedDish.Image,
                            Difficulty = new Pair<int>
                            {
                                Id = storedDish.Difficulty.Id, 
                                Title = storedDish.Difficulty.Title
                            },
                            CookingTimeInMinutes = storedDish.CookingTime,
                            RecipeSteps = RecipeSplitToSteps(storedDish.Recipe),
                            Calories = storedDish.TotalCalories,
                            Role = dish.Role,
                            Ingredients = []
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
                        
                        enrichmentGroup.Dishes.Add(enrichmentDish);
                    }
                    
                    enrichmentMeal.Groups.Add(enrichmentGroup);
                }
                
                enrichmentDay.Meals.Add(enrichmentMeal);
            }
            
            enrichmentPlan.Days.Add(enrichmentDay);
        }

        return enrichmentPlan;
    }

    private List<NutritionPlanRecipeStepDto> RecipeSplitToSteps(string recipe)
    {
        var parts = Regex
            .Split(recipe, @"\s*(?=\d+\.\s)")
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .ToList();

        var result = new List<NutritionPlanRecipeStepDto>(parts.Count);

        for (var i = 0; i < parts.Count; i++)
        {
            var text = Regex.Replace(parts[i], @"^\d+\.\s*", "").Trim();
            result.Add(new NutritionPlanRecipeStepDto { Order = i + 1, Description = text });
        }

        return result;
    }
}