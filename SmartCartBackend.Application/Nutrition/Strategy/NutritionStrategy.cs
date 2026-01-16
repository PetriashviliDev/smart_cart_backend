using System.Text.RegularExpressions;
using Newtonsoft.Json;
using SmartCardBackend.Application.AI.Clients;
using SmartCardBackend.Application.Identity;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Nutrition.Strategy;

public abstract class NutritionStrategy(
    JsonSerializerSettings jsonSerializerSettings,
    IAiClient aiClient) : INutritionStrategy
{ 
    protected abstract DietStrategy Strategy { get; }
  
    protected abstract string BuildUserPrompt(
        UserContext user,
        NutritionRequirements requirements);

    protected virtual string BuildSystemPrompt()
    {
        const string systemPrompt = """
                                    Ты — профессиональный нутрициолог (20 лет опыта).

                                    ОБЯЗАТЕЛЬНО:
                                    - Отвечай ТОЛЬКО валидным JSON.
                                    - Никакого текста вне JSON.
                                    - Никакого markdown, комментариев или пояснений.
                                    - JSON должен парситься стандартным парсером.

                                    ОГРАНИЧЕНИЯ:
                                    - Строго соблюдать аллергии и непереносимости.
                                    - Учитывать бюджет и лимит времени приготовления.
                                    - Одно и то же блюдо (по name) — не более 2 раз за весь план, включая альтернативы.
                                    - Для каждого блюда минимум 1 альтернатива.
                                    - Альтернативы нутриционно сопоставимы (±10% калорий).

                                    РАСЧЁТЫ:
                                    - Все значения — целые числа.
                                    - cooking_time_in_minutes — целое число.
                                    - Итоги дня = сумма блюд.
                                    - summary:
                                      - total_* = сумма всех дней
                                      - average_daily_calories = total_calories / количество дней (округлить)

                                    ФОРМАТ ОТВЕТА (СТРОГО):
                                    {
                                      "days": [
                                        {
                                          "day": 1,
                                          "meals": [
                                            {
                                              "type": "string",
                                              "dish": {
                                                "name": "string",
                                                "calories": 0,
                                                "protein": 0,
                                                "fat": 0,
                                                "carbs": 0,
                                                "cooking_time_in_minutes": 0
                                              },
                                              "alternative_dishes": [
                                                {
                                                  "name": "string",
                                                  "calories": 0,
                                                  "protein": 0,
                                                  "fat": 0,
                                                  "carbs": 0,
                                                  "cooking_time_in_minutes": 0
                                                }
                                              ]
                                            }
                                          ],
                                          "total_calories": 0,
                                          "total_protein": 0,
                                          "total_fat": 0,
                                          "total_carbs": 0
                                        }
                                      ],
                                      "summary": {
                                        "total_calories": 0,
                                        "average_daily_calories": 0,
                                        "total_protein": 0,
                                        "total_fat": 0,
                                        "total_carbs": 0
                                      }
                                    }

                                    ЕСЛИ УСЛОВИЯ КОНФЛИКТУЮТ:
                                    - Всё равно верни JSON в этом формате.
                                    - Используй максимально близкое допустимое решение.
                                    """;

        return systemPrompt;
    }

    public async Task<NutritionPlan> GeneratePlanAsync(
        UserContext user,
        NutritionRequirements requirements,
        CancellationToken ct = default)
    {
        var prompt = BuildUserPrompt(user, requirements);
        var systemPrompt = BuildSystemPrompt();

        var response = await aiClient.ChatCompletionsAsync(user, prompt, systemPrompt, ct);
        var nutritionPlanAsJson = Regex.Match(response.Choices[0].Message.Content, @"\{.*\}", RegexOptions.Singleline).Value;
        
        var nutritionPlan = JsonConvert.DeserializeObject<NutritionPlan>(nutritionPlanAsJson, jsonSerializerSettings);

        return nutritionPlan;
    }
}