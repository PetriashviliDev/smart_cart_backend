using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.Services.Token.Access;

public class AccessTokenManager(
    ILogger<AccessTokenManager> logger, 
    IOptions<JwtOptions> options, 
    ISystemClock clock) 
    : TokenManager(logger, options, clock), IAccessTokenManager
{
    public TokenResponse Generate(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.MobilePhone, user.Phone)
        };

        var expires = Clock.Now.AddHours(JwtOptions.AccessTokenExpiryInHours);
        
        var securityToken = new JwtSecurityToken(
            issuer: JwtOptions.Issuer,
            audience: JwtOptions.Audience,
            claims: claims,
            expires: expires.UtcDateTime,
            signingCredentials: CreateSigningCredentials()
        );
        
        var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return new TokenResponse { Token = accessToken, ExpiresAt = expires.UtcDateTime };
    }

    public ClaimsPrincipal Validate(string token, bool validateLifetime, out SecurityToken validatedToken)
    {
        try
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(JwtOptions.GetSecretKeyBytes()),
                ValidateIssuer = true,
                ValidIssuer = JwtOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = JwtOptions.Audience,
                ValidateLifetime = validateLifetime,
                ClockSkew = TimeSpan.FromMinutes(1)
            };

            var principal = new JwtSecurityTokenHandler().ValidateToken(
                token, validationParameters, out validatedToken);
            
            return principal;
        }
        catch (SecurityTokenExpiredException ex)
        {
            Logger.LogError(ex, "Token is expired");
            throw;
        }
        catch (SecurityTokenInvalidSignatureException ex)
        {
            Logger.LogError(ex, "Invalid token signature");
            throw;
        }
        catch (SecurityTokenInvalidIssuerException ex)
        {
            Logger.LogError(ex, "Invalid token issuer");
            throw;
        }
        catch (SecurityTokenInvalidAudienceException ex)
        {
            Logger.LogError(ex, "Invalid token audience");
            throw;
        }
        catch (ArgumentException ex)
        {
            Logger.LogError(ex, "Invalid token format");
            throw;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Token validation failed");
            throw;
        }
    }
}