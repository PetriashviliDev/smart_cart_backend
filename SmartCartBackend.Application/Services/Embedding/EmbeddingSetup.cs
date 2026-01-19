using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.Extensions;

namespace SmartCardBackend.Application.Services.Embedding;

public static class EmbeddingSetup
{
    public static IServiceCollection AddEmbedding(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddHttpClient<IEmbeddingService, EmbeddingService>(cfg =>
            {
                var options = configuration.GetSection(
                    nameof(EmbeddingOptions)).Get<EmbeddingOptions>();
            
                cfg.BaseAddress = new Uri(options.BaseAddress);
                cfg.Timeout = Timeout.InfiniteTimeSpan;
            })
            .WithTimeoutPolicyHandler()
            .WithRetryPolicyHandler();

        return services;
    }
}