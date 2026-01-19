using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель справочника трудности приготовления
/// </summary>
public class Difficulty : ActualizedEnumeration<Difficulty>
{
    private Difficulty() { }

    public Difficulty(
        int id,
        string title,
        [CallerMemberName] string callerName = null) 
        : base(id, title, callerName) { }
    
    #region Seeds

    public static Difficulty Easy = new(1, "Легко");
    public static Difficulty Normal = new(2, "Средне");
    public static Difficulty Hard = new(3, "Сложно");
    
    #endregion Seeds
}