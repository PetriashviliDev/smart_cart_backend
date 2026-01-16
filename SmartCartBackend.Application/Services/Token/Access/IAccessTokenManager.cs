using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Services.Token.Access;

public interface IAccessTokenManager : ITokenManager
{
    TokenResponse Generate(User user);
    
    ClaimsPrincipal Validate(
        string token, 
        bool validateLifetime, 
        out SecurityToken validatedToken);
}