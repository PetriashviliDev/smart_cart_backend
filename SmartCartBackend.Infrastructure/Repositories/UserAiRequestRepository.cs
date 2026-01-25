using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class UserAiRequestRepository(
    IDatabaseContextFactory contextFactory)
    : Repository<UserAiRequest, Guid>(contextFactory),
        IUserAiRequestRepository
{
    protected override IQueryable<UserAiRequest> Set => 
        Context.UserAiRequests
            .Include(uar => uar.User);
}