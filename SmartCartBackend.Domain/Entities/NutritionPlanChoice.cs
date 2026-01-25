using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель рациона
/// </summary>
public class NutritionPlanChoice : Entity<Guid>
{
    #region Constructors

    private NutritionPlanChoice(Guid id) : base(id) { }
    
    [JsonConstructor]
    protected NutritionPlanChoice(
        Guid id, 
        Guid planId,
        NutritionPlan plan,
        int dayNumber,
        int mealTypeId,
        MealType mealType,
        int dishId,
        Dish dish,
        DishChoice choice) : base(id)
    {
        PlanId = planId;
        Plan = plan;
        DayNumber = dayNumber;
        MealTypeId = mealTypeId;
        MealType = mealType;
        DishId = dishId;
        Dish = dish;
        Choice = choice;
    }
    
    private NutritionPlanChoice(
        Guid id, 
        Guid planId,
        int dayNumber,
        int mealTypeId,
        int dishId,
        DishChoice choice) 
        : base(id)
    {
        PlanId = planId;
        DayNumber = dayNumber;
        MealTypeId = mealTypeId;
        DishId = dishId;
        Choice = choice;
    }

    public static NutritionPlanChoice Create(
        Guid id, 
        Guid planId,
        int dayNumber,
        int mealTypeId,
        int dishId,
        DishChoice choice)
    {
        var dishChoice = new NutritionPlanChoice(
            id, planId, dayNumber, mealTypeId, dishId, choice);
        
        return dishChoice;
    }
    
    #endregion Constructors

    #region Properties

    /// <summary>
    /// План питания
    /// </summary>
    public Guid PlanId { get; private set; }
    public NutritionPlan Plan { get; private set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public int DayNumber { get; private set; }

    /// <summary>
    /// Тип приема пищи
    /// </summary>
    public int MealTypeId { get; private set; }
    public MealType MealType { get; private set; }

    /// <summary>
    /// Блюдо
    /// </summary>
    public int DishId { get; private set; }
    public Dish Dish { get; private set; }

    /// <summary>
    /// Признак выбора
    /// </summary>
    public DishChoice Choice { get; private set; }
    
    #endregion Properties
}