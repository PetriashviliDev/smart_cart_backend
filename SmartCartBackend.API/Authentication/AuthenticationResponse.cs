using SmartCardBackend.Application.Identity;

namespace SmartCartBackend.API.Authentication;

public record AuthenticationResponse
{
    /// <summary>
    /// Токен доступа
    /// </summary>
    public string AccessToken { get; init; }
    
    /// <summary>
    /// Дата истечения срока годности токена доступа
    /// </summary>
    public DateTime AccessTokenExpiresAt { get; init; }
    
    /// <summary>
    /// Рефреш токен для получения нового токена доступа
    /// </summary>
    public string RefreshToken { get; init; }
    
    /// <summary>
    /// Дата истечения срока годности рефреш токена
    /// </summary>
    public DateTime RefreshTokenExpiresAt { get; init; }
    
    /// <summary>
    /// Пользователь
    /// </summary>
    public UserContext User { get; init; }
}