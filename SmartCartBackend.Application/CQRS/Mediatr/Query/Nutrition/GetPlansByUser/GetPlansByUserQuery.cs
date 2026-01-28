using SmartCardBackend.Application.Nutrition.Dto;
using SmartCardBackend.Domain;

namespace SmartCardBackend.Application.CQRS.Mediatr.Query.Nutrition.GetPlansByUser;

public record GetPlansByUserQuery(
    Guid UserId, 
    int Page, 
    int Size) 
    : IQuery<PageResponse<NutritionPlanResponse>>;