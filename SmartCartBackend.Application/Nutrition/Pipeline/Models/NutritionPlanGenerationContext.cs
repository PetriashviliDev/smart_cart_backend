using Pgvector;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Application.Services.Identity;
using SmartCardBackend.Domain.Entities;

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
    public List<Dish> FilteredDishes { get; set; }
    
    /// <summary>
    /// Похожие блюда
    /// </summary>
    public List<Dish> SimilarDishes { get; set; }

    /// <summary>
    /// Сгенерированный план
    /// </summary>
    public NutritionPlanDto GeneratedPlan { get; set; }
}