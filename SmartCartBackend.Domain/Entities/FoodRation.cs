using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Attributes;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

[Dictionary]
public class FoodRation : ActualizedEnumeration<FoodRation>
{
    private FoodRation() { }

    public FoodRation(
        int id,
        string title,
        [CallerMemberName] string callerName = null) 
        : base(id, title, callerName) {
    }
    
    #region Seeds

    public static FoodRation ThreeMain = new(1, "3 основных");
    public static FoodRation ThreeMainAndOneSnack = new(2, "3 основных + 1 перекус");
    public static FoodRation ThreeMainAndTwoSnack = new(3, "3 основных + 2 перекуса");
    public static FoodRation IntervalFasting = new(4, "2 раза в день (интервальное голодание)");

    #endregion Seeds
}