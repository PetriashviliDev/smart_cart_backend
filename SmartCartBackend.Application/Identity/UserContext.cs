namespace SmartCardBackend.Application.Identity;

public record UserContext
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Ip адрес
    /// </summary>
    public string IpAddress { get; set; }
    
    /// <summary>
    /// Устройство
    /// </summary>
    public string UserAgent { get; set; }
    
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
    public string ActivityLevel { get; set; }

    /// <summary>
    /// Список аллергий
    /// </summary>
    public List<string> Allergies { get; set; }
    
    /// <summary>
    /// Список предпочтений
    /// </summary>
    public List<string> Preferences { get; set; }
    
    /// <summary>
    /// Список непереносимостей
    /// </summary>
    public List<string> Intolerances { get; set; }
}