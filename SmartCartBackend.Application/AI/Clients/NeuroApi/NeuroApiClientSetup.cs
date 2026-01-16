using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Polly.Timeout;

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
            .AddPolicyHandler((sp, _) => GetRetryPolicy(sp.GetRequiredService<ILogger<NeuroApiClient>>()))
            .AddPolicyHandler(GetTimeoutPolicy());

        return services;
    }
    
    private static AsyncTimeoutPolicy<HttpResponseMessage> GetTimeoutPolicy()
    {
        return Policy
            .TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromMinutes(5),
                TimeoutStrategy.Optimistic);
    }

    private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy(ILogger<NeuroApiClient> logger)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError() // 5xx, 408, network
            .OrResult(r => r.StatusCode == HttpStatusCode.TooManyRequests) // 429
            .WaitAndRetryAsync(
                retryCount: 2,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(2 * retry),
                onRetry: (exception, timeSpan, context) =>
                {
                    logger.LogWarning($"Повтор http вызова из-за - " +
                                      $"{exception.Result?.StatusCode.ToString()}. " +
                                      $"{exception.Exception.Message}. " +
                                      $"{exception.Exception.InnerException?.Message}");
                }
            );
    }
}