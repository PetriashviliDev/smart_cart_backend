using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class AllergyCategory(
    int id,
    string title) : Enumeration(id, title)
{
    #region Seeds
    
    public static AllergyCategory Food = new(1, "Пищевая");
    public static AllergyCategory Drug = new(2, "Лекарственная");
    public static AllergyCategory Ecology = new(3, "Экологическая");
    
    #endregion Seeds
}