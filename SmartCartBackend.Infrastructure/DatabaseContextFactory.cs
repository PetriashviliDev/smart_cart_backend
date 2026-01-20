using Microsoft.EntityFrameworkCore;

namespace SmartCartBackend.Infrastructure;

public class DatabaseContextFactory(
    IDbContextFactory<DatabaseContext> contextFactory) 
    : IDatabaseContextFactory
{
    private DatabaseContext _context;
    
    public DatabaseContext CreateDbContext() => 
        contextFactory.CreateDbContext();
    
    public DatabaseContext GetOrCreateDbContext() =>
        _context ??= CreateDbContext();
}