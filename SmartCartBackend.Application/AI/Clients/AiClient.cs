using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartCardBackend.Application.AI.Models;
using SmartCardBackend.Application.Generators;
using SmartCardBackend.Application.Identity;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Entities.SeedWork;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.AI.Clients;

public abstract class AiClient(
    ILogger<AiClient> logger,
    IUnitOfWork uow,
    HttpClient client,
    IGuidGenerator guidGenerator,
    ISystemClock clock,
    JsonSerializerSettings jsonSerializerSettings) : IAiClient
{
    protected abstract string ClientName { get; }
    
    protected abstract AiOptions Options { get; }
    
    public virtual async Task<AiResponse> ChatCompletionsAsync(
        UserContext user,
        string userPrompt, 
        string systemPrompt, 
        CancellationToken ct = default)
    {
        var aiRequest = BuildRequest(userPrompt, systemPrompt);
        var json = JsonConvert.SerializeObject(aiRequest, jsonSerializerSettings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var requestedAt = clock.Now;

        var stopwatch = Stopwatch.StartNew();
        try
        {
            var response = await client.PostAsync("v1/chat/completions", content, ct);
            stopwatch.Stop();

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync(ct);
                throw new HttpRequestException($"{response.StatusCode}. {errorContent}");
            }
            
            var aiResponse = await response.Content.ReadFromJsonAsync<AiResponse>(ct);

            var userAiRequest = UserAiRequest.Create(
                guidGenerator.NewGuid,
                user.Id,
                ClientName,
                aiRequest.Model,
                requestedAt,
                stopwatch.ElapsedMilliseconds,
                nameof(AiRequestStatus.Succeeded).ToLower(),
                promptTokens: aiResponse.Usage.PromptTokens,
                completionTokens: aiResponse.Usage.CompletionTokens,
                totalTokens: aiResponse.Usage.TotalTokens);
            
            uow.UserAiRequestRepository.Add(userAiRequest);
            await uow.SaveChangesAsync(ct);
                
            return aiResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"При вызове {ClientName} возникла ошибка");
            
            if (stopwatch.IsRunning)
                stopwatch.Stop();
            
            var userAiRequest = UserAiRequest.Create(
                guidGenerator.NewGuid,
                user.Id,
                ClientName,
                aiRequest.Model,
                requestedAt,
                stopwatch.ElapsedMilliseconds,
                nameof(AiRequestStatus.Failed).ToLower(),
                ex.Message);
            
            uow.UserAiRequestRepository.Add(userAiRequest);
            await uow.SaveChangesAsync(ct);
            
            throw;
        }
    }

    protected AiRequest BuildRequest(string userPrompt, string systemPrompt)
    {
        var request = new AiRequest
        {
            Model = Options.Model,
            Messages =
            [
                new AiMessage
                {
                    Role = "system",
                    Content = systemPrompt
                },
                new AiMessage
                {
                    Role = "user",
                    Content = userPrompt
                }
            ]
        };

        return request;
    }
}