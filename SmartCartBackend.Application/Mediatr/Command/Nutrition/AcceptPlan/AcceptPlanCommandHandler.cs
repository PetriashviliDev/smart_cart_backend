using SmartCardBackend.Application.ResultResponseHelper;
using SmartCardBackend.Application.Services.Generators;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Common.Clock;

namespace SmartCardBackend.Application.Mediatr.Command.Nutrition.AcceptPlan;

public class AcceptPlanCommandHandler(
    ISystemClock clock,
    IGuidGenerator guidGenerator,
    IUnitOfWork uow) 
    : ICommandHandler<AcceptPlanCommand>
{
    public async Task<Result> Handle(
        AcceptPlanCommand command, 
        CancellationToken ct)
    {
        var draft = await uow.NutritionPlanDraftRepository
            .SingleOrDefaultAsync(
                draft => draft.Id == command.AcceptedPlan.DraftId,
                trackingEnabled: false,
                ct: ct);
        
        if (draft == null)
            return Result.Failure(Error.NotFound($"Draft {command.AcceptedPlan.DraftId} not found"));
        
        var now = clock.Now;
        var planId = guidGenerator.NewGuid;

        var plan = NutritionPlan.Create(
            planId, command.User.Id, draft.Id, now);
        
        uow.NutritionPlanRepository.Add(plan);

        var choices = new List<NutritionPlanChoice>();
        
        foreach (var day in command.AcceptedPlan.Days)
        {
            foreach (var meal in day.Meals)
            {
                foreach (var dish in meal.Dishes)
                {
                    var choice = NutritionPlanChoice.Create(
                        guidGenerator.NewGuid,
                        planId,
                        day.Number,
                        meal.Type.Id,
                        dish.Id,
                        dish.Choice
                    );
                    
                    choices.Add(choice);
                }
            }
        }
        
        uow.NutritionPlanChoiceRepository.AddRange(choices);
        await uow.SaveChangesAsync(ct);
        
        return Result.Success();
    }
}