using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.AI.Clients.NeuroApi;

namespace SmartCardBackend.Application.AI;

public static class AiClientSetup
{
    public static IServiceCollection AddAiClients(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddNeuroApiClient(configuration);

        return services;
    }
}