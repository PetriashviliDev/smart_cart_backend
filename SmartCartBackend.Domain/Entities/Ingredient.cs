using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель ингредиента
/// </summary>
public class Ingredient : DisplayEnumeration
{
    #region Constructors

    private Ingredient() { }
    
    [JsonConstructor]
    protected Ingredient(
        int id,
        string title,
        string description,
        string image,
        decimal calories, 
        decimal proteins, 
        decimal fats, 
        decimal carbohydrates,
        List<DishIngredient> dishIngredients,
        List<IngredientAllergy> ingredientAllergies,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName)
    {
        Calories = calories;
        Proteins = proteins;
        Fats = fats;
        Carbohydrates = carbohydrates;
        _dishIngredients = dishIngredients;
        _ingredientAllergies = ingredientAllergies;
    }
    
    private Ingredient(
        int id,
        string title,
        string description,
        string image,
        decimal calories, 
        decimal proteins, 
        decimal fats, 
        decimal carbohydrates,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName)
    {
        Calories = calories;
        Proteins = proteins;
        Fats = fats;
        Carbohydrates = carbohydrates;
        _dishIngredients = [];
        _ingredientAllergies = [];
    }

    public static Ingredient Create(
        int id,
        string title,
        string description,
        string image,
        decimal calories,
        decimal proteins,
        decimal fats,
        decimal carbohydrates)
    {
        var ingredient = new Ingredient(id, title, description,
            image, calories, proteins, fats, carbohydrates);
        
        return ingredient;
    }
    
    #endregion Constructors

    #region Properties
    
    /// <summary>
    /// Калории на 100 г.
    /// </summary>
    public decimal Calories { get; private set; }
    
    /// <summary>
    /// Белок на 100 г.
    /// </summary>
    public decimal Proteins { get; private set; }
    
    /// <summary>
    /// Жиры на 100 г.
    /// </summary>
    public decimal Fats { get; private set; }
    
    /// <summary>
    /// Углеводы на 100 г.
    /// </summary>
    public decimal Carbohydrates { get; private set; }

    /// <summary>
    /// Связи блюда и ингредиентов
    /// </summary>
    public IReadOnlyCollection<DishIngredient> DishIngredients => _dishIngredients.AsReadOnly();
    private readonly List<DishIngredient> _dishIngredients;

    /// <summary>
    /// Связь с аллергиями
    /// </summary>
    public IReadOnlyCollection<IngredientAllergy> IngredientAllergies => _ingredientAllergies.AsReadOnly();
    private readonly List<IngredientAllergy> _ingredientAllergies;
    
    /// <summary>
    /// Аллергии
    /// </summary>
    [NotMapped]
    public List<Allergy> Allergies => _ingredientAllergies.Select(x => x.Allergy).ToList();
    
    #endregion Properties
}