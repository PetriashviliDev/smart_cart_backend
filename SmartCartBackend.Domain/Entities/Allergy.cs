using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using SmartCardBackend.Domain.Attributes;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

[Dictionary]
public class Allergy : ActualizedEnumeration<Allergy>
{
    #region Constructors
    
    private Allergy() { }

    public Allergy(
        int id,
        string title,
        List<IngredientAllergy> ingredientAllergies,
        [CallerMemberName] string callerName = null)
        : base(id, title, callerName)
    {
        _ingredientAllergies = ingredientAllergies;
    }

    public Allergy(
        int id,
        string title,
        [CallerMemberName] string callerName = null)
        : base(id, title, callerName)
    {
        _ingredientAllergies = [];
    }

    #endregion Constructors
    
    /// <summary>
    /// Связь с ингредиентами
    /// </summary>
    public IReadOnlyCollection<IngredientAllergy> IngredientAllergies => _ingredientAllergies.AsReadOnly();
    private readonly List<IngredientAllergy> _ingredientAllergies;
    
    /// <summary>
    /// Ингредиенты
    /// </summary>
    [NotMapped]
    public List<Ingredient> Ingredients => _ingredientAllergies.Select(x => x.Ingredient).ToList();
    
    #region Seeds

    public static Allergy Peanut = new(1, "Арахис");
    public static Allergy Milk = new(2, "Молочное");
    public static Allergy Eggs = new(3, "Яйца");
    public static Allergy Gluten = new(4, "Глютен");

    #endregion Seeds
}