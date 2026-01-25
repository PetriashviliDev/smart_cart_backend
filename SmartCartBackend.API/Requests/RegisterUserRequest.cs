using SmartCardBackend.Application.Responses;

namespace SmartCartBackend.API.Requests;

public record RegisterUserRequest
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; set; }
    
    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Рост
    /// </summary>
    public double Height { get; set; }
    
    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; set; }
    
    /// <summary>
    /// Исключенные продукты
    /// </summary>
    public string ExcludedProducts { get; set; }
    
    /// <summary>
    /// Уровень активности
    /// </summary>
    public Pair<int> ActivityLevel { get; set; }

    /// <summary>
    /// Аллергии
    /// </summary>
    public List<Pair<int>> Allergies { get; set; }
    
    /// <summary>
    /// Предпочтения
    /// </summary>
    public List<Pair<int>> PreferenceDishes { get; set; } = [];
}