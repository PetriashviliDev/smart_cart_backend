using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель блюда
/// </summary>
public class Dish : DisplayEnumeration
{
    #region Constructors

    private Dish() { }
    
    [JsonConstructor]
    protected Dish(
        int id,
        string title, 
        string description, 
        string recipe, 
        int cookingTime, 
        int difficultyId, 
        string image,
        int categoryId,
        int portions,
        decimal? price,
        Difficulty difficulty,
        DishCategory dishCategory,
        List<DishIngredient> dishIngredients,
        DishEmbedding dishEmbedding,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName)
    {
        Recipe = recipe;
        CookingTime = cookingTime;
        DifficultyId = difficultyId;
        CategoryId = categoryId;
        Portions = portions;
        Price = price;
        Difficulty = difficulty;
        DishCategory = dishCategory;
        _dishIngredients = dishIngredients;
        DishEmbedding = dishEmbedding;
    }
    
    private Dish(
        int id,
        string title, 
        string description, 
        string recipe, 
        int cookingTime, 
        int difficultyId, 
        string image,
        int categoryId,
        int portions,
        decimal? price,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName)
    {
        Recipe = recipe;
        CookingTime = cookingTime;
        DifficultyId = difficultyId;
        CategoryId = categoryId;
        Portions = portions;
        Price = price;
        _dishIngredients = [];
    }

    public static Dish Create(
        int id,
        string title,
        string description,
        string recipe,
        int cookingTime,
        int difficultyId,
        string image,
        int categoryId,
        int portions,
        decimal? price)
    {
        var dish = new Dish(id, title, description, recipe,
            cookingTime, difficultyId, image, categoryId, portions, price);
        
        return dish;
    }
    
    #endregion Constructors

    #region Properties

    /// <summary>
    /// Рецепт
    /// </summary>
    public string Recipe { get; private set; }
    
    /// <summary>
    /// Время на готовку в минутах
    /// </summary>
    public int CookingTime { get; private set; }
    
    /// <summary>
    /// Идентификатор трудности приготовления
    /// </summary>
    public int DifficultyId { get; private set; }
    
    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public int CategoryId { get; private set; }

    /// <summary>
    /// Количество порций
    /// </summary>
    public int Portions { get; private set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal? Price { get; private set; }

    /// <summary>
    /// Трудность приготовления
    /// </summary>
    public Difficulty Difficulty { get; private set; }
    
    /// <summary>
    /// Категория
    /// </summary>
    public DishCategory DishCategory { get; private set; }

    /// <summary>
    /// Связи блюда и ингредиентов
    /// </summary>
    public IReadOnlyCollection<DishIngredient> DishIngredients => _dishIngredients.AsReadOnly();

    private readonly List<DishIngredient> _dishIngredients;

    /// <summary>
    /// Связь с векторным представлением
    /// </summary>
    public DishEmbedding DishEmbedding { get; private set; }

    /// <summary>
    /// Ингредиенты
    /// </summary>
    [NotMapped]
    public List<Ingredient> Ingredients => DishIngredients.Select(x => x.Ingredient).ToList();
    
    /// <summary>
    /// Общее количество калорий
    /// </summary>
    public decimal TotalCalories => Ingredients.Sum(x => x.Calories);
    
    /// <summary>
    /// Общее количество белка
    /// </summary>
    public decimal TotalProteins => Ingredients.Sum(di => di.Proteins);
    
    /// <summary>
    /// Общее количество жиров
    /// </summary>
    public decimal TotalFats => Ingredients.Sum(di => di.Fats);
    
    /// <summary>
    /// Общее количество углеводов
    /// </summary>
    public decimal TotalCarbohydrates => Ingredients.Sum(di => di.Carbohydrates);
    
    #endregion Properties
}