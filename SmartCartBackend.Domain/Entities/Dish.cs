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
        int mealTypeId,
        Difficulty difficulty,
        DishCategory dishCategory,
        List<DishIngredient> dishIngredients,
        DishEmbedding dishEmbedding,
        List<DishTag> dishTags,
        MealType mealType,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName)
    {
        Recipe = recipe;
        CookingTime = cookingTime;
        DifficultyId = difficultyId;
        CategoryId = categoryId;
        Portions = portions;
        MealTypeId = mealTypeId;
        Difficulty = difficulty;
        DishCategory = dishCategory;
        _dishIngredients = dishIngredients;
        DishEmbedding = dishEmbedding;
        _dishTags = dishTags;
        MealType = mealType;
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
        int mealTypeId,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName)
    {
        Recipe = recipe;
        CookingTime = cookingTime;
        DifficultyId = difficultyId;
        CategoryId = categoryId;
        Portions = portions;
        MealTypeId = mealTypeId;
        _dishIngredients = [];
        _dishTags = [];
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
        int mealTypeId)
    {
        var dish = new Dish(id, title, description, recipe, cookingTime, 
            difficultyId, image, categoryId, portions, mealTypeId);
        
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
    /// Идентификатор типа приема
    /// </summary>
    public int MealTypeId { get; private set; }

    /// <summary>
    /// Трудность приготовления
    /// </summary>
    public Difficulty Difficulty { get; }
    
    /// <summary>
    /// Категория
    /// </summary>
    public DishCategory DishCategory { get; }

    /// <summary>
    /// Тип приема
    /// </summary>
    public MealType MealType { get; }

    /// <summary>
    /// Связи блюда и ингредиентов
    /// </summary>
    public IReadOnlyCollection<DishIngredient> DishIngredients => _dishIngredients.AsReadOnly();
    private readonly List<DishIngredient> _dishIngredients;
    
    /// <summary>
    /// Связи блюда и тегов
    /// </summary>
    public IReadOnlyCollection<DishTag> DishTags => _dishTags.AsReadOnly();
    private readonly List<DishTag> _dishTags;

    /// <summary>
    /// Связь с векторным представлением
    /// </summary>
    public DishEmbedding DishEmbedding { get; private set; }

    /// <summary>
    /// Ингредиенты
    /// </summary>
    [NotMapped]
    public List<Ingredient> Ingredients => _dishIngredients.Select(x => x.Ingredient).ToList();
    
    /// <summary>
    /// Теги
    /// </summary>
    [NotMapped]
    public List<Tag> Tags => _dishTags.Select(x => x.Tag).ToList();
    
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

    #region Methods

    public void SetEmbedding(DishEmbedding dishEmbedding) => DishEmbedding = dishEmbedding;

    #endregion Methods
}