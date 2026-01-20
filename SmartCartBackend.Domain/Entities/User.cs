using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class User : Entity<Guid>
{
    #region Constructors

    private User(Guid id) : base(id) { }

    [JsonConstructor]
    protected User(
        Guid id,
        string name,
        string email,
        string phone,
        string gender,
        int age,
        double height,
        double weight,
        string excludedProducts,
        List<UserAllergy> allergies,
        List<UserPreference> preferences,
        int activityLevelId,
        ActivityLevel activityLevel) : base(id)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Gender = gender;
        Age = age;
        Height = height;
        Weight = weight;
        ExcludedProducts = excludedProducts;
        Allergies = allergies;
        Preferences = preferences;
        ActivityLevelId = activityLevelId;
        ActivityLevel = activityLevel;
    }
    
    private User(
        Guid id,
        string name,
        string email,
        string phone,
        string gender,
        int age,
        double height,
        double weight,
        string excludedProducts,
        List<UserAllergy> allergies,
        List<UserPreference> preferences,
        int activityLevelId) : base(id)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Gender = gender;
        Age = age;
        Height = height;
        Weight = weight;
        ExcludedProducts = excludedProducts;
        Allergies = allergies;
        Preferences = preferences;
        ActivityLevelId = activityLevelId;
    }

    public static User Create(
        Guid id,
        string name, 
        string email,
        string phone, 
        string gender,
        int age, 
        double height, 
        double weight,
        string excludedProducts,
        List<UserAllergy> allergies,
        List<UserPreference> preferences,
        int activityLevelId)
    {
        var user = new User(
            id, 
            name, 
            email, 
            phone, 
            gender, 
            age, 
            height, 
            weight,
            excludedProducts, 
            allergies,
            preferences,
            activityLevelId);

        return user;
    }
    
    #endregion Constructors

    #region Properties
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; private set; }
    
    /// <summary>
    /// Мобильный телефон
    /// </summary>
    public string Phone { get; private set; }

    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; private set; }
    
    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; private set; }

    /// <summary>
    /// Рост
    /// </summary>
    public double Height { get; private set; }
    
    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; private set; }

    /// <summary>
    /// Хеш рефреш токена
    /// </summary>
    public string RefreshTokenHash { get; private set; }
    
    /// <summary>
    /// Срок действия рефреш токена
    /// </summary>
    public DateTimeOffset RefreshTokenExpiry { get; private set; }

    /// <summary>
    /// Исключенные продукты
    /// </summary>
    public string ExcludedProducts { get; private set; }

    /// <summary>
    /// Предпочтения
    /// </summary>
    public List<UserPreference> Preferences { get; private set; }

    /// <summary>
    /// Аллергии
    /// </summary>
    public List<UserAllergy> Allergies { get; private set; }

    /// <summary>
    /// Идентификатор уровня активности
    /// </summary>
    public int ActivityLevelId { get; private set; }

    /// <summary>
    /// Уровень активности
    /// </summary>
    public ActivityLevel ActivityLevel { get; set; }
    
    #endregion Properties

    public void SetRefreshToken(string refreshTokenHash, DateTimeOffset refreshTokenExpiry)
    {
        RefreshTokenHash = refreshTokenHash;
        RefreshTokenExpiry = refreshTokenExpiry;
    }
}