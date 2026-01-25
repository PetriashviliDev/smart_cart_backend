using System.Text;
using SmartCardBackend.Application.Services.Embedding;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Nutrition;

public class NutritionDishEmbeddingTextBuilder : IEmbeddingTextBuilder<Dish>
{
    public string BuildFor(Dish dish)
    {
        var sb = new StringBuilder($"Название блюда: {dish.Title}{Environment.NewLine}");
        sb.AppendLine($"Описание: {dish.Description}");
        sb.AppendLine($"Ингредиенты: {string.Join(", ", dish.Ingredients.Select(i => i.Title))}");
        sb.AppendLine($"Тип приема пищи: {dish.MealType.Title}");
        sb.AppendLine($"Теги: {string.Join(", ", dish.Tags.Select(t => t.Title))}");
        
        return sb.ToString();
    }
}