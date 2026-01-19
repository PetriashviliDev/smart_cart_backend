using System.Text.RegularExpressions;
using Newtonsoft.Json;
using SmartCardBackend.Application.AI.Clients;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;
using SmartCardBackend.Application.Services.Identity;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class GenerationPlanPipelineStep(
    INutritionPlanEnricher plaEnricher,
    JsonSerializerSettings jsonSerializerSettings,
    IAiClient aiClient)
    : INutritionPlanGenerationPipelineStep
{
    public async Task HandleAsync(
        NutritionPlanGenerationContext context,
        CancellationToken ct = default)
    {
        var userPrompt = BuildUserPrompt(context.User, context.Requirements);
        var systemPrompt = BuildSystemPrompt();

        var response = await aiClient.ChatCompletionsAsync(
            context.User, userPrompt, systemPrompt, ct);

        var nutritionPlanAsJson = Regex.Match(
            response.Choices[0].Message.Content,
            @"\{.*\}",
            RegexOptions.Singleline).Value;

        var nutritionPlan = JsonConvert.DeserializeObject<NutritionPlan>(
            nutritionPlanAsJson, jsonSerializerSettings);

        context.GeneratedPlan = await plaEnricher.EnrichAsync(nutritionPlan, ct);
    }

    private string BuildSystemPrompt()
    {
        const string systemPrompt = """
                                    Ты — профессиональный нутрициолог (20 лет опыта).

                                    ОБЯЗАТЕЛЬНО:
                                    - Отвечай ТОЛЬКО валидным JSON.
                                    - Никакого текста вне JSON.
                                    - Никакого markdown, комментариев или пояснений.
                                    - JSON должен парситься стандартным парсером.

                                    ОГРАНИЧЕНИЯ:
                                    - Строго соблюдать аллергии и не любимые продукты.
                                    - Учитывать лимит времени приготовления.
                                    - Одно и то же блюдо (по name) — не более 2 раз за весь план, включая альтернативы.
                                    - Для каждого блюда строго 2 альтернативы.
                                    - Альтернативы нутриционно сопоставимы (±10% калорий).

                                    РАСЧЁТЫ:
                                    - Все значения — целые числа.
                                    - days.number — номер дня в рационе.
                                    - meals.type — тип приема пищи:
                                      1 - Завтрак
                                      2 - Обед
                                      3 - Перекус
                                      4 - Ужин
                                    - dishes.id и alternatives.id - идентификаторы блюд из предложенного списка.

                                    ФОРМАТ ОТВЕТА (СТРОГО):
                                    {
                                      "days": [
                                        {
                                          "number": 1,
                                          "meals": [
                                            {
                                              "type": {
                                                "id": 1
                                              },
                                              "dishes": [
                                                {
                                                  "id": 1
                                                  "alternatives": [
                                                    {
                                                      "id": 15
                                                    },
                                                    {
                                                      "id": 91
                                                    }
                                                  ]
                                                },
                                                {
                                                  "id": 36
                                                  "alternatives": [
                                                    {
                                                      "id": 37
                                                    },
                                                    {
                                                      "id": 87
                                                    }
                                                  ]
                                                }
                                              ]
                                            }
                                          ]
                                        }
                                      ]
                                    }
                                    """;

        return systemPrompt;
    }

    private string BuildUserPrompt(
        UserContext user,
        NutritionRequirements requirements)
    {
        var allergies = user.Allergies.Count > 0 ? string.Join(", ", user.Allergies) : "Нет";
        var doesNotEat = !string.IsNullOrWhiteSpace(user.DoesNotEat) ? user.DoesNotEat : "Никакие";

        return $$"""
                 ПОЛЬЗОВАТЕЛЬ:
                 - Возраст: {{user.Age}}
                 - Пол: {{user.Gender}}
                 - Вес: {{user.Weight}} кг
                 - Рост: {{user.Height}} см
                 - Активность: {{user.ActivityLevel}}

                 ПРОДУКТОВЫЕ ОГРАНИЧЕНИЯ:
                 - Аллергии: {{allergies}}
                 - Исключить продукты: {{doesNotEat}})

                 ТРЕБОВАНИЯ:
                 - Цель: {{requirements.Strategy.Title}}
                 - Приемов пищи в день: {{requirements.MealsCountPerDay}}
                 - Время приготовления блюда: ≤ {{requirements.CookingTimeInMinutes}} мин
                 - Разнообразие рациона обязательно

                 ПРАВИЛА:
                 - Калорийность рассчитывать по полу, возрасту, росту, весу и активности.
                 - Все блюда и альтернативы должны соблюдать ограничения.
                 """;
    }
}