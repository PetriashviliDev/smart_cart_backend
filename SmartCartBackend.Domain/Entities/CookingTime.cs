using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class CookingTime : Enumeration
{
    private CookingTime() {}

    public CookingTime(
        int id,
        string title,
        [CallerMemberName] string callerName = null) 
        : base(id, title, callerName) { }
    
    #region Seeds

    public static CookingTime Small = new(1, "До 15 мин");
    public static CookingTime Medium = new(2, "15-30 мин");
    public static CookingTime Hard = new(3, "30-60 мин");
    public static CookingTime Unlimited = new(4, "Не ограничено");

    #endregion Seeds
}