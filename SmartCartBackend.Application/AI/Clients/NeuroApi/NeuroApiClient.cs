using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SmartCardBackend.Application.AI.Models;
using SmartCardBackend.Application.Services.Generators;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Entities.SeedWork;
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

    // public override async Task<AiResponse> ChatCompletionsAsync(
    //     UserContext user, 
    //     string userPrompt, 
    //     string systemPrompt, 
    //     CancellationToken ct = default)
    // {
    //     var aiRequest = BuildRequest(userPrompt, systemPrompt);
    //     var requestedAt = clock.Now;
    //
    //     var stopwatch = Stopwatch.StartNew();
    //     try
    //     {
    //         var aiResponse = new AiResponse
    //         {
    //             Choices = [new AiChoice
    //             {
    //                 Message = new AiMessage
    //                 {
    //                     Role = "assistant",
    //                     Content = """
    //                               
    //                               ```json
    //                               {
    //                               "days": [
    //                               {
    //                               "day": 1,
    //                               "meals": [
    //                               {
    //                               "type": "Завтрак",
    //                               "dish": {
    //                               "name": "Творожная запеканка с ягодами",
    //                               "calories": 320,
    //                               "protein": 25,
    //                               "fat": 12,
    //                               "carbs": 28,
    //                               "cooking_time_in_minutes": 40
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Омлет с куриной грудкой и шпинатом",
    //                               "calories": 290,
    //                               "protein": 28,
    //                               "fat": 16,
    //                               "carbs": 6,
    //                               "cooking_time_in_minutes": 25
    //                               }
    //                               ]
    //                               },
    //                               {
    //                               "type": "Обед",
    //                               "dish": {
    //                               "name": "Куриный суп с овощами и гречкой",
    //                               "calories": 380,
    //                               "protein": 32,
    //                               "fat": 10,
    //                               "carbs": 38,
    //                               "cooking_time_in_minutes": 50
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Индейка тушеная с капустой и морковью",
    //                               "calories": 350,
    //                               "protein": 30,
    //                               "fat": 12,
    //                               "carbs": 25,
    //                               "cooking_time_in_minutes": 45
    //                               }
    //                               ]
    //                               },
    //                               {
    //                               "type": "Ужин",
    //                               "dish": {
    //                               "name": "Рыба запеченная с брокколи",
    //                               "calories": 300,
    //                               "protein": 35,
    //                               "fat": 12,
    //                               "carbs": 15,
    //                               "cooking_time_in_minutes": 35
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Куриные котлеты на пару с цветной капустой",
    //                               "calories": 280,
    //                               "protein": 33,
    //                               "fat": 13,
    //                               "carbs": 12,
    //                               "cooking_time_in_minutes": 40
    //                               }
    //                               ]
    //                               }
    //                               ],
    //                               "total_calories": 1000,
    //                               "total_protein": 92,
    //                               "total_fat": 34,
    //                               "total_carbs": 81
    //                               },
    //                               {
    //                               "day": 2,
    //                               "meals": [
    //                               {
    //                               "type": "Завтрак",
    //                               "dish": {
    //                               "name": "Гречневая каша с куриным фаршем",
    //                               "calories": 310,
    //                               "protein": 24,
    //                               "fat": 8,
    //                               "carbs": 35,
    //                               "cooking_time_in_minutes": 30
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Творог с зеленью и огурцом",
    //                               "calories": 280,
    //                               "protein": 26,
    //                               "fat": 15,
    //                               "carbs": 12,
    //                               "cooking_time_in_minutes": 10
    //                               }
    //                               ]
    //                               },
    //                               {
    //                               "type": "Обед",
    //                               "dish": {
    //                               "name": "Суп-пюре из тыквы с курицей",
    //                               "calories": 360,
    //                               "protein": 28,
    //                               "fat": 14,
    //                               "carbs": 32,
    //                               "cooking_time_in_minutes": 45
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Говядина тушеная с овощами",
    //                               "calories": 380,
    //                               "protein": 34,
    //                               "fat": 15,
    //                               "carbs": 28,
    //                               "cooking_time_in_minutes": 55
    //                               }
    //                               ]
    //                               },
    //                               {
    //                               "type": "Ужин",
    //                               "dish": {
    //                               "name": "Тушеная индейка с кабачками",
    //                               "calories": 290,
    //                               "protein": 32,
    //                               "fat": 11,
    //                               "carbs": 18,
    //                               "cooking_time_in_minutes": 40
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Рыбные тефтели с томатным соусом",
    //                               "calories": 270,
    //                               "protein": 29,
    //                               "fat": 10,
    //                               "carbs": 20,
    //                               "cooking_time_in_minutes": 35
    //                               }
    //                               ]
    //                               }
    //                               ],
    //                               "total_calories": 960,
    //                               "total_protein": 84,
    //                               "total_fat": 33,
    //                               "total_carbs": 85
    //                               },
    //                               {
    //                               "day": 3,
    //                               "meals": [
    //                               {
    //                               "type": "Завтрак",
    //                               "dish": {
    //                               "name": "Яичница с помидорами и зеленью",
    //                               "calories": 280,
    //                               "protein": 22,
    //                               "fat": 18,
    //                               "carbs": 8,
    //                               "cooking_time_in_minutes": 15
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Творожные сырники без муки",
    //                               "calories": 310,
    //                               "protein": 23,
    //                               "fat": 16,
    //                               "carbs": 20,
    //                               "cooking_time_in_minutes": 25
    //                               }
    //                               ]
    //                               },
    //                               {
    //                               "type": "Обед",
    //                               "dish": {
    //                               "name": "Куриная грудка запеченная с овощами",
    //                               "calories": 370,
    //                               "protein": 36,
    //                               "fat": 12,
    //                               "carbs": 25,
    //                               "cooking_time_in_minutes": 50
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Суп из чечевицы с овощами",
    //                               "calories": 350,
    //                               "protein": 24,
    //                               "fat": 10,
    //                               "carbs": 38,
    //                               "cooking_time_in_minutes": 40
    //                               }
    //                               ]
    //                               },
    //                               {
    //                               "type": "Ужин",
    //                               "dish": {
    //                               "name": "Телятина на пару с брокколи и морковью",
    //                               "calories": 310,
    //                               "protein": 34,
    //                               "fat": 13,
    //                               "carbs": 14,
    //                               "cooking_time_in_minutes": 45
    //                               },
    //                               "alternative_dishes": [
    //                               {
    //                               "name": "Куриное филе с тушеной капустой",
    //                               "calories": 290,
    //                               "protein": 32,
    //                               "fat": 11,
    //                               "carbs": 15,
    //                               "cooking_time_in_minutes": 35
    //                               }
    //                               ]
    //                               }
    //                               ],
    //                               "total_calories": 960,
    //                               "total_protein": 92,
    //                               "total_fat": 43,
    //                               "total_carbs": 47
    //                               }
    //                               ],
    //                               "summary": {
    //                               "total_calories": 2920,
    //                               "average_daily_calories": 973,
    //                               "total_protein": 268,
    //                               "total_fat": 110,
    //                               "total_carbs": 213
    //                               }
    //                               }
    //                               ```
    //                               
    //                               """
    //                 }
    //             }],
    //             Usage = new AiUsage
    //             {
    //                 PromptTokens = 800,
    //                 CompletionTokens = 1500,
    //                 TotalTokens = 2300
    //             }
    //         };
    //         
    //         stopwatch.Stop();
    //
    //         var userAiRequest = UserAiRequest.Create(
    //             guidGenerator.NewGuid,
    //             user.Id,
    //             ClientName,
    //             aiRequest.Model,
    //             requestedAt,
    //             stopwatch.ElapsedMilliseconds,
    //             nameof(AiRequestStatus.Succeeded).ToLower(),
    //             promptTokens: aiResponse.Usage.PromptTokens,
    //             completionTokens: aiResponse.Usage.CompletionTokens,
    //             totalTokens: aiResponse.Usage.TotalTokens);
    //         
    //         uow.UserAiRequestRepository.Add(userAiRequest);
    //         await uow.SaveChangesAsync(ct);
    //             
    //         return aiResponse;
    //     }
    //     catch (Exception ex)
    //     {
    //         logger.LogError(ex, $"При вызове {ClientName} возникла ошибка");
    //         
    //         if (stopwatch.IsRunning)
    //             stopwatch.Stop();
    //         
    //         var userAiRequest = UserAiRequest.Create(
    //             guidGenerator.NewGuid,
    //             user.Id,
    //             ClientName,
    //             aiRequest.Model,
    //             requestedAt,
    //             stopwatch.ElapsedMilliseconds,
    //             nameof(AiRequestStatus.Failed).ToLower(),
    //             ex.Message);
    //         
    //         uow.UserAiRequestRepository.Add(userAiRequest);
    //         await uow.SaveChangesAsync(ct);
    //         
    //         throw;
    //     }
    // }
}