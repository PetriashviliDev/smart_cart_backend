using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Attributes;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель справочника тегов
/// </summary>
[Dictionary]
public class Tag : ActualizedEnumeration<Tag>
{
    #region Constructors

    private Tag() { }
    
    [JsonConstructor]
    protected Tag(
        int id,
        string title,
        List<DishTag> dishTags,
        [CallerMemberName] string callerName = null)
        : base(id, title, callerName)
    {
        _dishTags = dishTags;
    }

    public Tag(
        int id,
        string title,
        [CallerMemberName] string callerName = null)
        : base(id, title, callerName)
    {
        _dishTags = [];
    }
    
    #endregion Constructors
    
    /// <summary>
    /// Связи блюда и тегов
    /// </summary>
    public IReadOnlyCollection<DishTag> DishTags => _dishTags.AsReadOnly();
    private readonly List<DishTag> _dishTags;
    
    /// <summary>
    /// Теги
    /// </summary>
    [NotMapped]
    public List<Dish> Dishes => _dishTags.Select(x => x.Dish).ToList();
}