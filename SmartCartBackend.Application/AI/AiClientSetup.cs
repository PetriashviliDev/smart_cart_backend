using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.AI.Clients;

namespace SmartCardBackend.Application.AI;

public static class AiClientSetup
{
    public static IServiceCollection AddAiClients(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient<IAiClient, OpenRouterAiClient>(cfg =>
        {
            cfg.BaseAddress = new Uri("https://openrouter.ai/api/v1/chat/completions");
            cfg.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", 
                "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");
        });

        return services;
    }
}