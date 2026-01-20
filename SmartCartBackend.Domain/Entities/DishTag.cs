using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель связи блюда с тегом
/// </summary>
public class DishTag : ActualizedEnumeration<DishTag>
{
    #region Constructors
    
    private DishTag() { }

    [JsonConstructor]
    protected DishTag(
        int id,
        string title,
        int dishId,
        Dish dish,
        int tagId,
        Tag tag,
        [CallerMemberName] string callerName = null)
        : base(id, title, callerName)
    {
        DishId = dishId;
        Dish = dish;
        TagId = tagId;
        Tag = tag;
    }
    
    private DishTag(
        int id,
        string title,
        int dishId,
        int tagId,
        [CallerMemberName] string callerName = null)
        : base(id, title, callerName)
    {
        DishId = dishId;
        TagId = tagId;
    }

    public static DishTag Create(
        int id,
        string title,
        int dishId,
        int tagId)
    {
        var dishTag = new DishTag(
            id, title, dishId, tagId);
        
        return dishTag;
    }
    
    #endregion Constructors

    #region Properties

    /// <summary>
    /// Идентификатор блюда
    /// </summary>
    public int DishId { get; private set; }
    
    /// <summary>
    /// Идентификатор тега
    /// </summary>
    public int TagId { get; private set; }

    /// <summary>
    /// Блюдо
    /// </summary>
    public Dish Dish { get; }

    /// <summary>
    /// Тег
    /// </summary>
    public Tag Tag { get; }
    
    #endregion Properties
}