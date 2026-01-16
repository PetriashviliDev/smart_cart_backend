using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class ActivityLevel : Enumeration
{
    private ActivityLevel() { }

    public ActivityLevel(
        int id,
        string title,
        [CallerMemberName] string callerName = null) 
        : base(id, title, callerName) { }
    
    #region Seeds
    
    public static readonly ActivityLevel Sedentary = new(1, "Сидячий образ жизни");
    public static readonly ActivityLevel LightlyActive = new(2, "1-3 тренировки");
    public static readonly ActivityLevel ModeratelyActive = new(3, "4-5 тренировок");
    public static readonly ActivityLevel VeryActive = new(4, "6-7 тренировок");
    public static readonly ActivityLevel ProfessionalActive = new(5, "Профессиональный спорт");
    
    #endregion Seeds
}