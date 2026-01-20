using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class IngredientRepository(
    IDatabaseContextFactory contextFactory) 
    : Repository<Ingredient, int>(contextFactory), 
        IIngredientRepository;