using Newtonsoft.Json;
using SmartCardBackend.Application.AI.Clients;
using SmartCardBackend.Application.Identity;

namespace SmartCardBackend.Application.Nutrition.Strategy;

public class WeightLossStrategy(
    JsonSerializerSettings jsonSerializerSettings,
    IAiClient aiClient)
    : NutritionStrategy(jsonSerializerSettings, aiClient)
{
    protected override string BuildPrompt(
        UserContext user,
        NutritionRequirements requirements)
    {
        var allergies = user.Allergies.Count > 0 ? string.Join(", ", user.Allergies) : "Нет";
        var intolerances = user.Intolerances.Count > 0 ? string.Join(", ", user.Intolerances) : "Нет";
        var preferences = user.Preferences.Count > 0 ? string.Join(", ", user.Preferences) : "Нет";
        var cuisines = requirements.Cuisines.Count > 0 ? string.Join(", ", requirements.Cuisines) : "Любая";

        return $$"""
                 Создай недельный план питания для похудения со следующими параметрами:

                 ### ДАННЫЕ ПОЛЬЗОВАТЕЛЯ:
                 - Возраст: {{user.Age}}
                 - Пол: {{user.Gender}}
                 - Вес: {{user.Weight}} кг.
                 - Рост: {{user.Height}} см.
                 - Уровень активности: {{user.ActivityLevel}}
                 - Аллергии: {{allergies}}
                 - Непереносимости: {{intolerances}}
                 - Предпочтения: {{preferences}}

                 ### ТРЕБОВАНИЯ:
                 - Дефицит калорий: 500 ккал в день
                 - Белки: 30%, Жиры: 25%, Углеводы: 45%
                 - Используй только доступные продукты
                 - Время приготовления: не более {{requirements.CookingTimeInMinutes}} мин.
                 - Бюджет: {{requirements.Budget}}
                 - Кухня: {{cuisines}}
                 - Количество приемов пищи в день: {{requirements.MealsCountPerDay}}
                 - Разнообразие рациона

                 ### КРИТИЧЕСКИЕ ПРАВИЛА:
                 - Строго соблюдать аллергии и непереносимости
                 - Учитывать бюджет и время приготовления
                 - Не повторять блюда чаще 2 раз в неделю
                 - Для каждого блюда подбери 2 альтернативы
                 """;
    }
}