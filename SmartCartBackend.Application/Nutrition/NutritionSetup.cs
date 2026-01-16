using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.Extensions;
using SmartCardBackend.Application.Services.Embedding;

namespace SmartCardBackend.Application.Nutrition;

public static class NutritionSetup
{
    public static void AddNutritionServices(
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
    }
}