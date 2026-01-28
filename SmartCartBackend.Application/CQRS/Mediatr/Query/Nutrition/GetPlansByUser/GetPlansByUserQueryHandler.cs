using System.Linq.Expressions;
using MapsterMapper;
using SmartCardBackend.Application.Nutrition.Dto;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Domain;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.CQRS.Mediatr.Query.Nutrition.GetPlansByUser;

public class GetPlansByUserQueryHandler(
    IUnitOfWork uow, 
    IMapper mapper)
    : IQueryHandler<GetPlansByUserQuery, PageResponse<NutritionPlanResponse>>
{
    public async Task<Result<PageResponse<NutritionPlanResponse>>> Handle(
        GetPlansByUserQuery query, 
        CancellationToken ct)
    {
        Expression<Func<NutritionPlan, bool>> filter = plan => plan.UserId == query.UserId;
        
        var total = await uow.NutritionPlanRepository.CountAsync(filter, ct);
        if (total == 0)
            return PageResponse<NutritionPlanResponse>.Default;
        
        var chunk = await uow.NutritionPlanRepository
            .FindManyAsync(
                filter,
                sort: new Sort<NutritionPlan>(plan => plan.CreatedDate, SortDirection.Desc),
                query.Page,
                query.Size,
                trackingEnabled: false,
                ct);
        
        return new PageResponse<NutritionPlanResponse>(
            mapper.Map<List<NutritionPlanResponse>>(chunk),
            total, 
            query.Page, 
            query.Size);
    }
}