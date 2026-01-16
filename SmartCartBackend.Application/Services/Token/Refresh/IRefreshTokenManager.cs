using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Services.Token.Refresh;

public interface IRefreshTokenManager : ITokenManager
{
    TokenResponse Generate();

    bool Validate(User user, string token);
}