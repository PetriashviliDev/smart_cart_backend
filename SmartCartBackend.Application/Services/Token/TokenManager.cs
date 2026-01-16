using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.Services.Token;

public class TokenManager(
    ILogger<TokenManager> logger,
    IOptions<JwtOptions> options,
    ISystemClock clock) : ITokenManager
{
    protected readonly ILogger<TokenManager> Logger = logger;
    protected readonly JwtOptions JwtOptions = options.Value;
    protected readonly ISystemClock Clock = clock;

    public string HashToken(string token)
    {
        var bytes = Encoding.UTF8.GetBytes(token);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }

    public JwtSecurityToken ParseToken(string authorization)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(authorization) as JwtSecurityToken;

        return token;
    }

    protected SigningCredentials CreateSigningCredentials()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        return credentials;
    }
}