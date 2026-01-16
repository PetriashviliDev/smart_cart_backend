using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SmartCardBackend.Application.AI;
using SmartCardBackend.Application.Nutrition;
using SmartCardBackend.Application.Nutrition.Strategies;
using SmartCardBackend.Application.Services.Generators;
using SmartCardBackend.Application.Services.Identity;
using SmartCardBackend.Application.Services.Token;
using SmartCardBackend.Application.Services.Token.Access;
using SmartCardBackend.Application.Services.Token.Refresh;
using SmartCardBackend.Application.Services.Token.Verification;
using SmartCardBackend.Application.Services.Verifications;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application;

public static class Setup
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(assembly));
            
        services.AddValidatorsFromAssembly(assembly);
        
        services.AddAiClients(configuration);
        services.AddNutritionServices(configuration);

        services.AddHttpContextAccessor();

        services
            .AddTransient<ISystemClock, LocalSystemClock>()
            .AddTransient<IGuidGenerator, GuidGenerator>();

        services
            .AddScoped<IIdentityService, IdentityService>()
            .AddScoped<INutritionStrategy, WeightLossStrategy>()
            .AddScoped<ITokenManager, TokenManager>()
            .AddScoped<IAccessTokenManager, AccessTokenManager>()
            .AddScoped<IRefreshTokenManager, RefreshTokenManager>()
            .AddScoped<IVerificationTokenManager, VerificationTokenManager>()
            .AddScoped<IPhoneVerificationService, PhoneVerificationService>()
            .AddScoped<IVerificationCodeSender, SmsVerificationCodeSender>();
        
        services.Configure<VerificationOptions>(
            configuration.GetSection(nameof(VerificationOptions)));

        services.AddSingleton(_ => new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        });

        //services.AddHostedService<DishesUploader>();
        
        return services;
    }
}