using System.Security.Cryptography;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.Services.Token.Refresh;

public class RefreshTokenManager(
    ILogger<RefreshTokenManager> logger, 
    IOptions<JwtOptions> options, 
    ISystemClock clock) 
    : TokenManager(logger, options, clock), IRefreshTokenManager
{
    public TokenResponse Generate()
    {
        var randomNumber = new byte[64];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(randomNumber);
        
        var expires = Clock.Now.AddDays(JwtOptions.RefreshTokenExpiryInDays);
        var refreshToken = Convert.ToBase64String(randomNumber);
        
        return new TokenResponse { Token = refreshToken, ExpiresAt = expires.UtcDateTime };
    }
    
    public bool Validate(User user, string token)
    {
        if (user.RefreshTokenExpiry <= Clock.Now)
            return false;
        
        var hash = HashToken(token);
        
        return user.RefreshTokenHash == hash;
    }
}