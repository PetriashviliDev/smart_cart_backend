using Newtonsoft.Json;
using SmartCardBackend.Application.AI.Clients;
using SmartCardBackend.Application.Services.Identity;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Nutrition.Strategies;

public class WeightLossStrategy(
    JsonSerializerSettings jsonSerializerSettings,
    IAiClient aiClient)
    : NutritionStrategy(jsonSerializerSettings, aiClient)
{
    protected override DietStrategy Strategy => DietStrategy.WeightLoss;

    protected override string BuildUserPrompt(
        UserContext user,
        NutritionRequirements requirements)
    {
        var allergies = user.Allergies.Count > 0 ? string.Join(", ", user.Allergies) : "Нет";
        var doesNotEat = !string.IsNullOrWhiteSpace(user.DoesNotEat) ? user.DoesNotEat : "Нет";

        return $$"""
                  Создай план питания для похудения.
                  
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
                  - Цель: похудение
                  - Дефицит: 500 ккал от нормы поддержания
                  - БЖУ в сутки: Белки 30%, Жиры 25%, Углеводы 45%
                  - Приемов пищи в день: {{requirements.MealsCountPerDay}}
                  - Время приготовления блюда: ≤ {{requirements.CookingTimeInMinutes}} мин
                  - Разнообразие рациона обязательно
                  
                  ПРАВИЛА:
                  - Калорийность рассчитывать по полу, возрасту, росту, весу и активности.
                  - Суточная калорийность каждого дня: дефицит ±5%.
                  - Все блюда и альтернативы должны соблюдать ограничения.
                  - Использовать формат ответа из системного промпта.
                  """;
    }
}