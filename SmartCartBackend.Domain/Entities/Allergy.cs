using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class Allergy : ActualizedEnumeration<Allergy>
{
    private Allergy() { }
    
    public Allergy(
        int id,
        string title,
        [CallerMemberName] string callerName = null) 
        : base(id, title, callerName) { }
    
    #region Seeds

    public static Allergy Peanut = new(1, "Арахис");
    public static Allergy Milk = new(2, "Молочное");
    public static Allergy Eggs = new(3, "Яйца");
    public static Allergy Gluten = new(4, "Глютен");

    #endregion Seeds
}