using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmartCartBackend.API;

public static class Setup
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        return services;
    }
}