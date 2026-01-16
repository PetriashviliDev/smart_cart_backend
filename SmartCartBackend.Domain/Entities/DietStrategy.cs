using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель справочника стратегии диеты
/// </summary>
public class DietStrategy : DisplayEnumeration
{
    private DietStrategy() { }

    public DietStrategy(
        int id,
        string title, 
        string description, 
        string image = null,
        [CallerMemberName] string callerName = null) 
        : base(id, title, description, image, callerName) { }
    
    #region Seeds

    public static DietStrategy FormMaintenance = new(1, "Поддержание формы", "Сохранить текущий вес и тонус");
    public static DietStrategy MuscleGain = new(2, "Набор массы", "Увеличение мышечной массы и силы");
    public static DietStrategy VariedDiet = new(3, "Просто разнообразить питание", "Вкусные и разные блюда каждый день");
    public static DietStrategy WeightLoss = new(4, "Снижение веса", "Постепенное и комфортное похудение");
    
    #endregion Seeds
}