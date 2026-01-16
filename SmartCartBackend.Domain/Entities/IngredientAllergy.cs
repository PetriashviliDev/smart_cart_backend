using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Связь ингредиентов и аллергий
/// </summary>
public class IngredientAllergy : Entity<int>
{
    #region Constructors
    
    private IngredientAllergy(int id) : base(id) { }
        
    [JsonConstructor]
    protected IngredientAllergy(
        int id,
        int ingredientId,
        int allergyId, 
        Ingredient ingredient,
        Allergy allergy) : base(id)
    {
        IngredientId = ingredientId;
        AllergyId = allergyId;
        Ingredient = ingredient;
        Allergy = allergy;
    }
    
    private IngredientAllergy(
        int id,
        int ingredientId,
        int allergyId) : base(id)
    {
        IngredientId = ingredientId;
        AllergyId = allergyId;
    }

    public static IngredientAllergy Create(
        int id,
        int ingredientId,
        int allergyId)
    {
        var ingredientAllergy = new IngredientAllergy(
            id, ingredientId, allergyId);
        
        return ingredientAllergy;
    }
    
    #endregion Constructors

    #region Properties
    
    /// <summary>
    /// Идентификатор ингредиента
    /// </summary>
    public int IngredientId { get; private set; }
    
    /// <summary>
    /// Идентификатор аллергии
    /// </summary>
    public int AllergyId { get; private set; }
    
    /// <summary>
    /// Ингредиент
    /// </summary>
    public Ingredient Ingredient { get; }
    
    /// <summary>
    /// Аллергия
    /// </summary>
    public Allergy Allergy { get; }
    
    #endregion Properties
}