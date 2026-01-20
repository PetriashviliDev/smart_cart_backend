using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SmartCardBackend.Application.Mapping;

public static class MapsterSetup
{
    public static IServiceCollection ConfigureMapster(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        var config = new TypeAdapterConfig();
        config.Default
            .NameMatchingStrategy(NameMatchingStrategy.Flexible)
            .IgnoreNullValues(true);

        config.Scan(assemblies);
        config.Compile();
        
        services
            .AddSingleton(config)
            .AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}