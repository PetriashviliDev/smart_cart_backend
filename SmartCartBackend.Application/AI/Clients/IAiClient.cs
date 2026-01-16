using SmartCardBackend.Application.AI.Models;
using SmartCardBackend.Application.Services.Identity;

namespace SmartCardBackend.Application.AI.Clients;

public interface IAiClient
{
    Task<AiResponse> ChatCompletionsAsync(
        UserContext user,
        string userPrompt, 
        string systemPrompt, 
        CancellationToken ct = default);
}