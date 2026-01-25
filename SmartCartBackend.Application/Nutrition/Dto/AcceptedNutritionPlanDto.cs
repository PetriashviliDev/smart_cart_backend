namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// Подтвержденный план
/// </summary>
public record AcceptedNutritionPlanDto
{
    /// <summary>
    /// Идентификатор черновика
    /// </summary>
    public Guid DraftId { get; set; }

    /// <summary>
    /// Дни рациона
    /// </summary>
    public List<AcceptedNutritionPlanDayDto> Days { get; set; } = [];
}