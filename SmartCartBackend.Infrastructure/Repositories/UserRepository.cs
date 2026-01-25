using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class UserRepository(
    IDatabaseContextFactory contextFactory)
    : Repository<User, Guid>(contextFactory),
        IUserRepository
{
    protected override IQueryable<User> Set => 
        Context.Users
            .Include(u => u.ActivityLevel)
            .Include(u => u.Allergies)
                .ThenInclude(x => x.Allergy)
            .Include(u => u.Preferences)
                .ThenInclude(p => p.Dish);
}