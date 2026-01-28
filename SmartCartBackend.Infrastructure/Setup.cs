using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Repositories;
using SmartCartBackend.Infrastructure.Repositories;

namespace SmartCartBackend.Infrastructure;

public static class Setup
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(
            configuration.GetConnectionString(nameof(DatabaseContext)));
        
        dataSourceBuilder
            .EnableDynamicJson()
            .UseVector();
        
        var dataSource = dataSourceBuilder.Build();
        
        services.AddDbContextFactory<DatabaseContext>(options =>
            options.UseNpgsql(dataSource, builder => builder.UseVector()));

        services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IDatabaseContextFactory, DatabaseContextFactory>()
            .AddScoped<IIngredientRepository, IngredientRepository>()
            .AddScoped<IDishRepository, DishRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IPhoneVerificationRepository, PhoneVerificationRepository>()
            .AddScoped<ISessionRepository, SessionRepository>()
            .AddScoped<IUserAiRequestRepository, UserAiRequestRepository>()
            .AddScoped<IEnumerationRepository, EnumerationRepository>()
            .AddScoped<INutritionPlanDraftRepository, NutritionPlanDraftRepository>()
            .AddScoped<INutritionPlanRepository, NutritionPlanRepository>()
            .AddScoped<INutritionPlanChoiceRepository, NutritionPlanChoiceRepository>();
        
        return services;
    }
}