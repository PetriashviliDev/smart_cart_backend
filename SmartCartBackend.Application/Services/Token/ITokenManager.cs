using System.IdentityModel.Tokens.Jwt;

namespace SmartCardBackend.Application.Services.Token;

public interface ITokenManager
{
    string HashToken(string token);

    JwtSecurityToken ParseToken(string authorization);
}