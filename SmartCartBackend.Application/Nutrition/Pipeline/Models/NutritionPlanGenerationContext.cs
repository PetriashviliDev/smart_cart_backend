using Pgvector;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Application.Services.Identity;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Models;

/// <summary>
/// Контекст процесса генерации рациона
/// </summary>
public record NutritionPlanGenerationContext
{
    /// <summary>
    /// Контекстный пользователь
    /// </summary>
    public UserContext User { get; init; }

    /// <summary>
    /// Требования
    /// </summary>
    public NutritionRequirements Requirements { get; init; }

    /// <summary>
    /// Сырое описание блюда с требованиями пользователя
    /// </summary>
    public string RawQuery { get; set; }
    
    /// <summary>
    /// Векторное представление описания блюда с требованиями пользователя
    /// </summary>
    public Vector EmbeddingQuery { get; set; }
    
    /// <summary>
    /// Отфильтрованные блюда
    /// </summary>
    public List<Pair<int>> FilteredDishes { get; set; }
    
    /// <summary>
    /// Похожие блюда
    /// </summary>
    public List<Pair<int>> SimilarDishes { get; set; }

    /// <summary>
    /// Сгенерированный план
    /// </summary>
    public NutritionPlan GeneratedPlan { get; set; }
}