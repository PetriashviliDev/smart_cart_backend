using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartCardBackend.Application.Services.Actualizers;

namespace SmartCardBackend.Application.HostedServices;

public class BackgroundEnumerationActualizer(
    IServiceScopeFactory scopeFactory) 
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        using var scope = scopeFactory.CreateScope();
        
        var actualizer = scope.ServiceProvider.GetRequiredService<IEnumerationActualizer>();
        await actualizer.ActualizeAsync(ct);
    }
}