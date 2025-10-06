namespace SmartCardBackend.Application.Nutrition.ResponseExamples;

public static class ResponseExampleFactory
{
    public static MealPlanExample CreateMealPlanExample()
    {
        var mealPlan = new MealPlanExample
        {
            WeeklyPlan =
            [
                new DayPlanExample
                {
                    Day = "Понедельник",
                    Meals =
                    [
                        new MealExample
                        {
                            Type = "Завтрак",
                            Dishes =
                            [
                                new DishExample
                                {
                                    Number = 1,
                                    Name = "Омлет с помидорами и зеленью",
                                    Calories = 350,
                                    Protein = 25,
                                    Fat = 15,
                                    Carbs = 20,
                                    CookingTime = 15,
                                    Ingredients =
                                    [
                                        new IngredientExample
                                        {
                                            Name = "Яйца",
                                            Amount = 2,
                                            Unit = "шт."
                                        }
                                    ],
                                    RecipeSteps =
                                    [
                                        new RecipeStepExample
                                        {
                                            Number = 1,
                                            Step = "Взбить яйца с солью"
                                        }
                                    ]
                                }
                            ]
                        }
                    ],
                    TotalCalories = 2100,
                    TotalProtein = 100,
                    TotalFat = 70,
                    TotalCarbs = 250
                }
            ],
            TotalCalories = 14700,
            AverageDailyCalories = 2100,
            TotalProtein = 450,
            TotalFat = 350,
            TotalCarbs = 1800
        };
        
        return mealPlan;
    }
}