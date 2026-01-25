using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class IngredientCategory : DisplayEnumeration
{
    private IngredientCategory() { }

    public IngredientCategory(
        int id,
        string title, 
        string description, 
        string image, 
        string internalName) 
        : base(id, title, description, image, internalName) { }

    public static IngredientCategory Create(
        int id,
        string title,
        string description,
        string image,
        string internalName)
    {
        var category = new IngredientCategory(
            id, title, description, image, internalName);

        return category;
    }
}