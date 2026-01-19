using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.Services.Token.Access;
using SmartCardBackend.Application.Services.Token.Refresh;
using SmartCardBackend.Application.Services.Token.Verification;
using SmartCardBackend.Application.Services.Verifications;

namespace SmartCardBackend.Application.Services.Token;

public static class TokenSetup
{
    public static IServiceCollection AddTokenServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddScoped<ITokenManager, TokenManager>()
            .AddScoped<IAccessTokenManager, AccessTokenManager>()
            .AddScoped<IRefreshTokenManager, RefreshTokenManager>()
            .AddScoped<IVerificationTokenManager, VerificationTokenManager>()
            .AddScoped<IPhoneVerificationService, PhoneVerificationService>()
            .AddScoped<IVerificationCodeSender, SmsVerificationCodeSender>();
        
        services.Configure<VerificationOptions>(
            configuration.GetSection(nameof(VerificationOptions)));

        return services;
    }
}