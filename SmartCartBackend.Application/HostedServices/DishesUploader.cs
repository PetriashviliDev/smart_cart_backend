using Microsoft.Extensions.Hosting;
using SmartCardBackend.Application.AI.Clients;
using SmartCartBackend.Infrastructure;

namespace SmartCardBackend.Application.HostedServices;

public class DishesUploader(
    IAiClient aiClient,
    DatabaseContext context) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var cuisines = new List<string>
        {

        };
        
       return Task.CompletedTask;
    }
}