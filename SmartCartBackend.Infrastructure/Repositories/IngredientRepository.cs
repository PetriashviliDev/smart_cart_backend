using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class IngredientRepository(
    DatabaseContext context) 
    : Repository<Ingredient>(context), IIngredientRepository;