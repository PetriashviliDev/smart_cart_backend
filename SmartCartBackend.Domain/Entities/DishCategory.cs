using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель категории блюда
/// </summary>
public class DishCategory : DisplayEnumeration
{
    #region Constructors
    
    private DishCategory() { }

    [JsonConstructor]
    protected DishCategory(
        int id,
        string title, 
        string description, 
        string image, 
        List<Dish> dishes,
        [CallerMemberName] string callerName = null)
        : base(id, title, description, image, callerName)
    {
        _dishes = dishes;
    }
    
    private DishCategory(
        int id,
        string title, 
        string description, 
        string image,
        [CallerMemberName] string callerName = null)
        : base(id, title, description, image, callerName)
    {
        _dishes = [];
    }

    public static DishCategory Create(
        int id,
        string title, 
        string description, 
        string image)
    {
        var category = new DishCategory(id, title, description, image);
        return category;
    }
    
    #endregion Constructors

    #region Properties

    /// <summary>
    /// Блюда
    /// </summary>
    public IReadOnlyCollection<Dish> Dishes => _dishes.AsReadOnly();

    private readonly List<Dish> _dishes;
    
    #endregion Properties
}