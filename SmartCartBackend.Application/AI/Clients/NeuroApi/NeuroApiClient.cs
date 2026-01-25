using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SmartCardBackend.Application.Services.Generators;
using SmartCardBackend.Domain;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.AI.Clients.NeuroApi;

public class NeuroApiClient(
    ILogger<NeuroApiClient> logger,
    HttpClient client, 
    IOptions<NeuroApiOptions> options, 
    JsonSerializerSettings jsonSerializerSettings, 
    IGuidGenerator guidGenerator, 
    ISystemClock clock, 
    IUnitOfWork uow) 
    : AiClient(logger, uow, client, guidGenerator, clock, jsonSerializerSettings)
{
    protected override string ClientName => nameof(NeuroApiClient);
    
    protected override AiOptions Options => options.Value;
}