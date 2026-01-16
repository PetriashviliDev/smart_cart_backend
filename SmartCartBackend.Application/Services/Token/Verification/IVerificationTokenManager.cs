using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Services.Token.Verification;

public interface IVerificationTokenManager : ITokenManager
{
    TokenResponse Generate(
        Session session,
        TimeSpan expirationPeriod);
}