using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.Extensions;

namespace SmartCardBackend.Application.AI.Clients.NeuroApi;

public static class NeuroApiClientSetup
{
    public static IServiceCollection AddNeuroApiClient(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<NeuroApiOptions>()
            .Bind(configuration.GetSection(nameof(NeuroApiOptions)));
        
        services.AddHttpClient<IAiClient, NeuroApiClient>(cfg =>
            {
                var options = configuration.GetSection(
                    nameof(NeuroApiOptions)).Get<NeuroApiOptions>();
            
                cfg.BaseAddress = new Uri(options.BaseAddress);
                cfg.Timeout = Timeout.InfiniteTimeSpan;
                cfg.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer", 
                    options.ApiKey);
            })
            .WithTimeoutPolicyHandler()
            .WithRetryPolicyHandler();

        return services;
    }
}