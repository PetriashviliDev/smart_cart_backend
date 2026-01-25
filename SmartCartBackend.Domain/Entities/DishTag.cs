using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель связи блюда с тегом
/// </summary>
public class DishTag : Entity<int>
{
    #region Constructors
    
    private DishTag(int id) : base(id) { }

    [JsonConstructor]
    protected DishTag(
        int id,
        int dishId,
        Dish dish,
        int tagId,
        Tag tag)
        : base(id)
    {
        DishId = dishId;
        Dish = dish;
        TagId = tagId;
        Tag = tag;
    }
    
    private DishTag(
        int id,
        int dishId,
        int tagId)
        : base(id)
    {
        DishId = dishId;
        TagId = tagId;
    }

    public static DishTag Create(
        int id,
        int dishId,
        int tagId)
    {
        var dishTag = new DishTag(id, dishId, tagId);
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