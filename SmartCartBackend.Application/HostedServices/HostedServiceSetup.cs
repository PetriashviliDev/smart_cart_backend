using Microsoft.Extensions.DependencyInjection;

namespace SmartCardBackend.Application.HostedServices;

public static class HostedServiceSetup
{
    public static IServiceCollection AddHostedServices(
        this IServiceCollection services)
    {
        services
            .AddHostedService<BackgroundEnumerationActualizer>();

        return services;
    }
}