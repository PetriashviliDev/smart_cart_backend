using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Application.Nutrition.Dto;

/// <summary>
/// Блюдо
/// </summary>
public record AcceptedNutritionPlanDishDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Результат выбора
    /// </summary>
    public DishChoice Choice { get; set; }

    /// <summary>
    /// Роль блюда в рационе
    /// </summary>
    public DishRole Role { get; set; }
}