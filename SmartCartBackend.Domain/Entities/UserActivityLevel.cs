using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class UserActivityLevel(
    int id,
    string title) : Enumeration(id, title)
{
    #region Seeds
    
    public static readonly UserActivityLevel Sedentary = new(1, "Сидячий образ жизни");
    public static readonly UserActivityLevel LightlyActive = new(2, "Тренируюсь 1-3 раза в неделю");
    public static readonly UserActivityLevel ModeratelyActive = new(3, "Тренируюсь 3-5 раза в неделю");
    public static readonly UserActivityLevel VeryActive = new(4, "Тренируюсь 6-7 раз в неделю");
    public static readonly UserActivityLevel ProfessionalActive = new(5, "Профессионально занимаюсь спортом");
    
    #endregion Seeds
}