using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель приема пищи
/// </summary>
public class Meal : Entity<int>
{
    #region Constructors

    [JsonConstructor]
    protected Meal(
        int id, 
        DateTimeOffset date, 
        int mealTypeId, 
        int dishId,
        int mealPlanId,
        MealType mealType,
        Dish dish, 
        MealPlan mealPlan) : base(id)
    {
        Date = date;
        MealTypeId = mealTypeId;
        DishId = dishId;
        MealPlanId = mealPlanId;
        MealType = mealType;
        Dish = dish;
        MealPlan = mealPlan;
    }
    
    private Meal(
        int id, 
        DateTimeOffset date, 
        int mealTypeId, 
        int dishId, 
        int mealPlanId) : base(id)
    {
        Date = date;
        MealTypeId = mealTypeId;
        DishId = dishId;
        MealPlanId = mealPlanId;
    }

    public static Meal Create(
        int id,
        DateTimeOffset date,
        int mealTypeId,
        int dishId, 
        int mealPlanId)
    {
        var meal = new Meal(id, date, mealTypeId, dishId, mealPlanId);
        return meal;
    }
    
    #endregion Constructors
    
    #region Properties
    
    /// <summary>
    /// Дата приема пищи
    /// </summary>
    public DateTimeOffset Date { get; private set; }
    
    /// <summary>
    /// Идентификатор типа приема пищи
    /// </summary>
    public int MealTypeId { get; private set; }
    
    /// <summary>
    /// Тип приема пищи
    /// </summary>
    public MealType MealType { get; }
    
    /// <summary>
    /// Идентификатор блюда
    /// </summary>
    public int DishId { get; private set; }
    
    /// <summary>
    /// Блюдо
    /// </summary>
    public Dish Dish { get; }
    
    /// <summary>
    /// Идентификатор рациона
    /// </summary>
    public int MealPlanId { get; private set; }
    
    /// <summary>
    /// Рацион
    /// </summary>
    public MealPlan MealPlan { get; }
    
    #endregion Properties
}