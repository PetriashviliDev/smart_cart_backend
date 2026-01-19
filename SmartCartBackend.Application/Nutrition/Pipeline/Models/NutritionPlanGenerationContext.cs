using Pgvector;
using SmartCardBackend.Application.Services.Identity;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Nutrition.Pipeline.Models;

public record NutritionPlanGenerationContext
{
    public UserContext User { get; init; }

    public NutritionRequirements Requirements { get; init; }

    public List<Dish> FilteredDishes { get; set; }
    
    public string RawQuery { get; set; }

    public Vector EmbeddingQuery { get; set; }
}