using Newtonsoft.Json;
using SmartCardBackend.Application.AI.Clients;
using SmartCardBackend.Application.Identity;
using SmartCardBackend.Application.Nutrition.ResponseExamples;

namespace SmartCardBackend.Application.Nutrition.Strategy;

public abstract class NutritionStrategy(
    JsonSerializerSettings jsonSerializerSettings,
    IAiClient aiClient) : INutritionStrategy
{
    private readonly string _jsonExample = JsonConvert.SerializeObject(
        ResponseExampleFactory.CreateMealPlanExample(),
        Formatting.Indented,
        jsonSerializerSettings);

    protected abstract string BuildPrompt(
        UserContext user,
        NutritionRequirements requirements);

    public async Task<NutritionPlan> GeneratePlanAsync(
        UserContext user,
        NutritionRequirements requirements,
        CancellationToken ct = default)
    {
        var prompt = BuildPrompt(user, requirements);
        var systemPrompt = $$"""
                             Ты — эксперт-нутрициолог с 20-летним опытом. Создай персонализированный план питания.
                             Всегда отвечай строго в формате JSON. Не добавляй поясняющий текст.

                             ### ФОРМАТ ОТВЕТА:
                             {{_jsonExample}}
                             """;

        var response = await aiClient.AskAsync(prompt, systemPrompt, ct);
        
        return new NutritionPlan();

        //return JsonSerializer.Deserialize<NutritionPlan>(response) ?? throw new Exception();
    }
}