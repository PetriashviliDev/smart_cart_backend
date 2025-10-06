using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class User : Entity<Guid>
{
    #region Constructors

    [JsonConstructor]
    protected User(
        Guid id,
        string name,
        string email,
        string phone,
        string gender,
        int age,
        double height,
        double weight
        /*,
        List<UserIntolerance> intolerances,
        List<UserPreference> preferences,
        List<UserAllergy> allergies*/) : base(id)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Gender = gender;
        Age = age;
        Height = height;
        Weight = weight;
        Intolerances = [];
        Preferences = [];
        Allergies = [];
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
        List<UserIntolerance> intolerances = null, 
        List<UserPreference> preferences = null, 
        List<UserAllergy> allergies = null)
    {
        var user = new User(id, name, email, phone, gender, 
            age, height, weight);

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
    public DateTime RefreshTokenExpiry { get; private set; }

    /// <summary>
    /// Непереносимости
    /// </summary>
    public List<UserIntolerance> Intolerances { get; private set; }

    /// <summary>
    /// Предпочтения
    /// </summary>
    public List<UserPreference> Preferences { get; private set; }

    /// <summary>
    /// Аллергии
    /// </summary>
    public List<UserAllergy> Allergies { get; private set; }

    
    #endregion Properties

    public void SetRefreshToken(string refreshTokenHash, DateTime refreshTokenExpiry)
    {
        RefreshTokenHash = refreshTokenHash;
        RefreshTokenExpiry = refreshTokenExpiry;
    }
}