using Microsoft.EntityFrameworkCore;

namespace SmartCartBackend.Infrastructure;

public interface IDatabaseContextFactory : IDbContextFactory<DatabaseContext>
{
    DatabaseContext GetOrCreateDbContext();
}