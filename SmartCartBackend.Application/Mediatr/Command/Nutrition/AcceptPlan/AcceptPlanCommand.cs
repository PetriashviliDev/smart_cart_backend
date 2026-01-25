using SmartCardBackend.Application.Nutrition.Dto;
using SmartCardBackend.Application.Services.Identity;

namespace SmartCardBackend.Application.Mediatr.Command.Nutrition.AcceptPlan;

public record AcceptPlanCommand(
    UserContext User, 
    AcceptedNutritionPlanDto AcceptedPlan) 
    : ICommand;