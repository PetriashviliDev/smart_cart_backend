using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Количество ингредиентов в блюде
/// </summary>
public class DishIngredient : Entity<int>
{
    #region Constructors
    
    private DishIngredient(int id) : base(id) { }
    
    [JsonConstructor]
    protected DishIngredient(
        int id,
        int dishId,
        int ingredientId,
        decimal amount, 
        int unitId,
        Unit unit,
        Dish dish,
        Ingredient ingredient) : base(id)
    {
        DishId = dishId;
        IngredientId = ingredientId;
        Amount = amount;
        UnitId = unitId;
        Unit = unit;
        Dish = dish;
        Ingredient = ingredient;
    }
    
    private DishIngredient(
        int id,
        int dishId,
        int ingredientId,
        decimal amount, 
        int unitId) : base(id)
    {
        DishId = dishId;
        IngredientId = ingredientId;
        Amount = amount;
        UnitId = unitId;
    }

    public static DishIngredient Create(
        int id,
        int dishId,
        int ingredientId,
        decimal amount,
        int unitId)
    {
        var dishIngredient = new DishIngredient(
            id, dishId, ingredientId, amount, unitId);
        
        return dishIngredient;
    }
    
    #endregion Constructors

    #region Properties
    
    /// <summary>
    /// Количество ингредиента
    /// </summary>
    public decimal Amount { get; private set; }
    
    /// <summary>
    /// Единица измерения ингредиента
    /// </summary>
    public int UnitId { get; private set; }
    
    /// <summary>
    /// Идентификатор блюда
    /// </summary>
    public int DishId { get; private set; }
    
    /// <summary>
    /// Индентификатор ингредиента
    /// </summary>
    public int IngredientId { get; private set; }

    /// <summary>
    /// Единица измерения ингредиента
    /// </summary>
    public Unit Unit { get; }

    /// <summary>
    /// Блюдо
    /// </summary>
    public Dish Dish { get; }
    
    /// <summary>
    /// Ингредиент
    /// </summary>
    public Ingredient Ingredient { get; }

    /// <summary>
    /// Общее количество калорий
    /// </summary>
    public decimal TotalCalories => Ingredient.Calories * Amount / 100;
    
    /// <summary>
    /// Общее количество белка
    /// </summary>
    public decimal TotalProteins => Ingredient.Proteins * Amount / 100;
    
    /// <summary>
    /// Общее количество жиров
    /// </summary>
    public decimal TotalFats => Ingredient.Fats * Amount / 100;
    
    /// <summary>
    /// Общее количество угеводов
    /// </summary>
    public decimal TotalCarbohydrates => Ingredient.Calories * Amount / 100;
    
    #endregion Properties
}