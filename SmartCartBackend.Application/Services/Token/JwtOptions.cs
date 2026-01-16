using System.Text;

namespace SmartCardBackend.Application.Services.Token;

public record JwtOptions
{
    public string Issuer { get; init; }
    
    public string Audience { get; init; }
    
    public string SecretKey { get; init; }

    public int AccessTokenExpiryInHours { get; init; }
    
    public int RefreshTokenExpiryInDays { get; init; }
    
    public byte[] GetSecretKeyBytes() =>
        string.IsNullOrEmpty(SecretKey) 
            ? throw new ArgumentException("JWT SecretKey is not configured") 
            : Encoding.ASCII.GetBytes(SecretKey);
}