namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// План питания
/// </summary>
public record NutritionPlanResponse
{
    /// <summary>
    /// Идентификатор черновика
    /// </summary>
    public Guid DraftId { get; set; }
    
    /// <summary>
    /// Дни рациона
    /// </summary>
    public List<NutritionPlanDayDto> Days { get; set; } = [];
}