using Microsoft.EntityFrameworkCore;
using SmartCardBackend.Domain.Entities;
using SmartCartBackend.Infrastructure.Extensions;

namespace SmartCartBackend.Infrastructure;

public class DatabaseContext : DbContext
{
    public DbSet<Allergy> Allergies { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<DishCategory> DishCategories { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealPlan> MealPlans { get; set; }
    public DbSet<ActivityLevel> UserActivityLevels { get; set; }
    public DbSet<UserAllergy> UserAllergies { get; set; }
    public DbSet<UserPreference> UserPreferences { get; set; }
    public DbSet<PhoneVerification> PhoneVerifications { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DatabaseContext() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(o => o.UseVector());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("vector");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        modelBuilder.AddSeeds();
    }
}