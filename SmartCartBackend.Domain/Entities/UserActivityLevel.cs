using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class UserActivityLevel(
    int id,
    string title) : Enumeration(id, title)
{
    #region Seeds
    
    public static readonly UserActivityLevel Sedentary = new(1, "Сидячий образ жизни");
    public static readonly UserActivityLevel LightlyActive = new(2, "Низкая активность");
    public static readonly UserActivityLevel ModeratelyActive = new(3, "Умеренная активность");
    public static readonly UserActivityLevel VeryActive = new(4, "Высокая активность");
    public static readonly UserActivityLevel ExtremelyActive = new(5, "Очень высокая активность");
    
    #endregion Seeds
}