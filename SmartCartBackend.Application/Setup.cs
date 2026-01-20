using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SmartCardBackend.Application.AI;
using SmartCardBackend.Application.Hangfire;
using SmartCardBackend.Application.Mapping;
using SmartCardBackend.Application.Nutrition;
using SmartCardBackend.Application.Services.Actualizers;
using SmartCardBackend.Application.Services.Embedding;
using SmartCardBackend.Application.Services.Generators;
using SmartCardBackend.Application.Services.Identity;
using SmartCardBackend.Application.Services.Searchers;
using SmartCardBackend.Application.Services.Token;
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
        
        services
            .AddAiClients(configuration)
            .AddEmbedding(configuration)
            .AddTokenServices(configuration)
            .AddNutritionServices();

        services.AddHttpContextAccessor();
        
        services
            .ConfigureMapster(assembly)
            .ConfigureHangfire(configuration);

        services
            .AddTransient<ISystemClock, LocalSystemClock>()
            .AddTransient<IGuidGenerator, GuidGenerator>()
            .AddScoped<IIdentityService, IdentityService>()
            .AddScoped<IEnumerationActualizer, EnumerationActualizer>()
            .AddScoped<IDishSearcher, DishSearcher>();

        services.AddSingleton(_ => new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        });
        
        return services;
    }
}