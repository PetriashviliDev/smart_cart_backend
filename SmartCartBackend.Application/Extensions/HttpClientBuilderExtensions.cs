using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Polly.Timeout;
using SmartCardBackend.Application.AI.Clients.NeuroApi;

namespace SmartCardBackend.Application.Extensions;

public static class HttpClientBuilderExtensions
{
    public static IHttpClientBuilder WithTimeoutPolicyHandler(
        this IHttpClientBuilder builder) => 
        builder.AddPolicyHandler(GetTimeoutPolicy());
    
    public static IHttpClientBuilder WithRetryPolicyHandler(
        this IHttpClientBuilder builder) => 
        builder.AddPolicyHandler((sp, _) => 
            GetRetryPolicy(sp.GetRequiredService<ILogger<NeuroApiClient>>()));
    
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