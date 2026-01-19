using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class CookingTime : ActualizedEnumeration<CookingTime>
{
    private CookingTime() {}

    public CookingTime(
        int id,
        string title,
        int? limit = null,
        [CallerMemberName] string callerName = null) 
        : base(id, title, callerName) { }

    public int? Limit { get; private set; }
    
    #region Seeds

    public static CookingTime Small = new(1, "До 15 мин", limit: 15);
    public static CookingTime Medium = new(2, "15-30 мин", limit: 30);
    public static CookingTime Hard = new(3, "30-60 мин", limit: 60);
    public static CookingTime Unlimited = new(4, "Не ограничено");

    #endregion Seeds
    
    public override void Actualize(CookingTime cookingTime)
    {
        base.Actualize(cookingTime);
        
        Limit = cookingTime.Limit;
    }
}