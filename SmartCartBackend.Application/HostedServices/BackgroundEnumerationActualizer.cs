using Microsoft.Extensions.Hosting;
using SmartCardBackend.Application.Services.Actualizers;

namespace SmartCardBackend.Application.HostedServices;

public class BackgroundEnumerationActualizer(
    IEnumerationActualizer actualizer) 
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken ct) =>
        await actualizer.ActualizeAsync(ct);
}