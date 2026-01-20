using SmartCardBackend.Application.Responses;

namespace SmartCardBackend.Application.Services.Identity;

public record UserContext
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Мобильный телефон
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; set; }
    
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
    /// Уровень активности
    /// </summary>
    public Pair<int> ActivityLevel { get; set; }

    /// <summary>
    /// Аллергии
    /// </summary>
    public List<Pair<int>> Allergies { get; set; }
    
    /// <summary>
    /// Исключенные продукты
    /// </summary>
    public string ExcludedProducts { get; set; }
    
    /// <summary>
    /// Ip адрес
    /// </summary>
    public string IpAddress { get; set; }
    
    /// <summary>
    /// Устройство
    /// </summary>
    public string UserAgent { get; set; }
    
    /// <summary>
    /// Предпочтения на завтрак
    /// </summary>
    public List<Pair<int>> BreakfastPreferences { get; set; } = [];
    
    /// <summary>
    /// Предпочтения на обед
    /// </summary>
    public List<Pair<int>> LunchPreferences { get; set; } = [];
    
    /// <summary>
    /// Предпочтения на перекус
    /// </summary>
    public List<Pair<int>> SnackPreferences { get; set; } = [];
    
    /// <summary>
    /// Предпочтения на ужин
    /// </summary>
    public List<Pair<int>> DinnerPreferences { get; set; } = [];
}