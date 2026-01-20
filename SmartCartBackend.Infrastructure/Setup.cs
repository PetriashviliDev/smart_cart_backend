using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        services.AddDbContextFactory<DatabaseContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(DatabaseContext)));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IIngredientRepository, IngredientRepository>()
            .AddScoped<IDishRepository, DishRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IPhoneVerificationRepository, PhoneVerificationRepository>()
            .AddScoped<ISessionRepository, SessionRepository>()
            .AddScoped<IUserAiRequestRepository, UserAiRequestRepository>()
            .AddScoped<IEnumerationRepository, EnumerationRepository>();
        
        return services;
    }
}