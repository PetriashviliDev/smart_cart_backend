namespace SmartCartBackend.API.Requests;

public record LoginUserRequest
{
    /// <summary>
    /// Мобильный телефон
    /// </summary>
    public string Phone { get; set; }
}