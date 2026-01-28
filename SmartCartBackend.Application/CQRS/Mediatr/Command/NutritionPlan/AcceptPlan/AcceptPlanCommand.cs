using SmartCardBackend.Application.Nutrition.Dto;
using SmartCardBackend.Application.Services.Identity;

namespace SmartCardBackend.Application.CQRS.Mediatr.Command.NutritionPlan.AcceptPlan;

public record AcceptPlanCommand(
    UserContext User, 
    AcceptedNutritionPlanDto AcceptedPlan) 
    : ICommand;