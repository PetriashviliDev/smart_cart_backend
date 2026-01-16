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
        decimal? price,
        List<DishIngredient> dishIngredients,
        List<Allergy> allergies,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName)
    {
        Calories = calories;
        Proteins = proteins;
        Fats = fats;
        Carbohydrates = carbohydrates;
        Price = price;
        _dishIngredients = dishIngredients;
        _allergies = allergies;
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
        decimal? price,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName)
    {
        Calories = calories;
        Proteins = proteins;
        Fats = fats;
        Carbohydrates = carbohydrates;
        Price = price;
        _dishIngredients = [];
        _allergies = [];
    }

    public static Ingredient Create(
        int id,
        string title,
        string description,
        string image,
        decimal calories,
        decimal proteins,
        decimal fats,
        decimal carbohydrates,
        decimal? price)
    {
        var ingredient = new Ingredient(id, title, description,
            image, calories, proteins, fats, carbohydrates, price);
        
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
    /// Цена за 100 г.
    /// </summary>
    public decimal? Price { get; private set; }

    /// <summary>
    /// Связи блюда и ингредиентов
    /// </summary>
    public IReadOnlyCollection<DishIngredient> DishIngredients => _dishIngredients.AsReadOnly();

    private readonly List<DishIngredient> _dishIngredients;

    /// <summary>
    /// Аллергии
    /// </summary>
    public IReadOnlyCollection<Allergy> Allergies => _allergies.AsReadOnly();

    private readonly List<Allergy> _allergies;
    
    #endregion Properties
}