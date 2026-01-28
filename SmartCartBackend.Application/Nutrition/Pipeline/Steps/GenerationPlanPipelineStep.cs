using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using SmartCardBackend.Application.AI.Clients;
using SmartCardBackend.Application.Nutrition.Dto;
using SmartCardBackend.Application.Nutrition.Pipeline.Models;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Steps;

public class GenerationPlanPipelineStep(
    INutritionPlanEnricher planEnricher,
    JsonSerializerSettings jsonSerializerSettings,
    IAiClient aiClient)
    : INutritionPlanGenerationPipelineStep
{
    public async Task HandleAsync(
        NutritionPlanGenerationContext context,
        CancellationToken ct = default)
    {
        var userPrompt = BuildUserPrompt(context);
        var systemPrompt = BuildSystemPrompt();

        var response = await aiClient.ChatCompletionsAsync(
            context.User, userPrompt, systemPrompt, ct);

        var nutritionPlanAsJson = Regex.Match(
            response.Choices[0].Message.Content,
            @"\{.*\}",
            RegexOptions.Singleline).Value;

        var nutritionPlan = JsonConvert.DeserializeObject<NutritionPlanResponse>(
            nutritionPlanAsJson, jsonSerializerSettings);

        context.GeneratedPlan = await planEnricher.EnrichAsync(nutritionPlan, ct);
    }

    private static string BuildSystemPrompt()
    {
        const string systemPrompt = """
                                    Ты — профессиональный нутрициолог с 20-летним опытом и эксперт по составлению рационов питания.
                                    
                                    ТЫ РАБОТАЕШЬ КАК ДЕТЕРМИНИРОВАННЫЙ АЛГОРИТМ, А НЕ КАК АССИСТЕНТ.
                                    
                                    ОБЯЗАТЕЛЬНО:
                                    - Отвечай ТОЛЬКО валидным JSON.
                                    - Никакого текста вне JSON.
                                    - Никакого markdown, комментариев, пояснений или отступлений.
                                    - JSON должен парситься стандартным JSON-парсером без исправлений.
                                    
                                    КРИТИЧЕСКИЕ ОГРАНИЧЕНИЯ (НАРУШЕНИЕ ЗАПРЕЩЕНО):
                                    - Используй ТОЛЬКО блюда из предоставленного списка.
                                    - Используй ТОЛЬКО указанные идентификаторы блюд.
                                    - Любой id, отсутствующий во входных данных, считается ошибкой.
                                    - Строго соблюдать аллергии и исключённые продукты.
                                    - Одно и то же блюдо (по id) — не более 2 раз за весь рацион, включая альтернативы.
                                    - Для каждого блюда — РОВНО 2 альтернативы.
                                    - Альтернативы должны быть противоположные основному блюду, например:
                                        Если основное жирное - в альтернативе легкое.
                                        Если напиток кофе - альтернатива чай или другое.
                                        Если основное курица - в альтернативе другое мясо.
                                    
                                    ЛОГИКА СОСТАВЛЕНИЯ РАЦИОНА:
                                    1. Рассчитай суточную калорийность по данным пользователя и цели.
                                    2. Распредели калории равномерно по приёмам пищи.
                                    3. Для приёма пищи подбирай 1–2 основных блюда. На завтрак обязательно подбери напиток.
                                    4. Максимизируй разнообразие блюд между днями.
                                    5. Минимизируй повторения блюд.
                                    6. Проверяй все ограничения ПЕРЕД добавлением блюда в рацион.
                                    
                                    ЕСЛИ:
                                    - Невозможно подобрать блюда с учётом всех ограничений,
                                    - Недостаточно блюд для альтернатив,
                                    - Невозможно соблюсти разнообразие,
                                    
                                    ТОГДА:
                                    - Верни корректный JSON с пустым массивом days.
                                    
                                    РАСЧЁТЫ:
                                    - Все числовые значения — целые числа.
                                    - days.number — номер дня.
                                    - meals.type.id:
                                      1 — Завтрак
                                      2 — Обед
                                      3 — Перекус
                                      4 — Ужин
                                    - dishes.id — идентификаторы из входного списка.
                                    
                                    ФОРМАТ ОТВЕТА (СТРОГО):
                                    {
                                      "days": [
                                        {
                                          "number": 1,
                                          "meals": [
                                            {
                                              "type": { "id": 1 },
                                              "dishes": [
                                                {
                                                  "id": 12,
                                                  "role": "main"
                                                },
                                                {
                                                  "id": 13,
                                                  "role": "alternative" 
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

    private static string BuildUserPrompt(
        NutritionPlanGenerationContext context)
    {
        var allergies = context.User.Allergies.Count > 0 
          ? string.Join(", ", context.User.Allergies.Select(a => a.Title)) 
          : "Нет";
        
        var excludedProducts = !string.IsNullOrWhiteSpace(context.User.ExcludedProducts) 
          ? context.User.ExcludedProducts 
          : "Никакие";

        var dishes = new StringBuilder();

        foreach (var dish in context.SimilarDishes)
        {
          var anonymous = new
          {
            id = dish.Id,
            title = dish.Title,
            ingredients = dish.Ingredients.Select(i => i.Title),
            mealType = dish.MealType.Title,
            category = dish.DishCategory.Title
          };
          
          dishes.AppendLine(JsonConvert.SerializeObject(anonymous, Formatting.Indented));
        }

        return $$"""
                  ДАННЫЕ ПОЛЬЗОВАТЕЛЯ:
                  - Возраст: {{context.User.Age}}
                  - Пол: {{context.User.Gender}}
                  - Вес: {{context.User.Weight}} кг
                  - Рост: {{context.User.Height}} см
                  - Уровень активности: {{context.User.ActivityLevel.Title}}
                  
                  ПРОДУКТОВЫЕ ОГРАНИЧЕНИЯ:
                  - Аллергии: {{allergies}}
                  - Исключённые продукты: {{excludedProducts}}
                  
                  ЦЕЛЬ И ПАРАМЕТРЫ РАЦИОНА:
                  - Цель питания: {{context.Requirements.Strategy.Title}}
                  - Количество дней: {{context.Requirements.NutritionDays}}
                  - Приёмов пищи в день: {{context.Requirements.MealsCountPerDay}}
                  
                  ТРЕБОВАНИЯ К РАЦИОНУ:
                  - Рацион должен быть разнообразным между днями.
                  - В каждом приёме пищи:
                    - 1–2 основных блюда (смотреть по калориям).
                    - Обязательно наличие напитка на завтрак и опционально на перекус (смотреть по калориям).
                  - Все блюда и альтернативы обязаны соответствовать ограничениям.
                  - Использовать ТОЛЬКО блюда из списка ниже.
                  
                  СПИСОК ДОСТУПНЫХ БЛЮД (ЕДИНСТВЕННЫЙ ИСТОЧНИК ДАННЫХ):
                  {{dishes}}
                  """;
    }
}