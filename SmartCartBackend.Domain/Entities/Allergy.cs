using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class Allergy : Enumeration
{
    #region Constructors

    [JsonConstructor]
    protected Allergy(
        int id,
        string title,
        string description,
        int categoryId,
        AllergyCategory category)
        : base(id, title)
    {
        Description = description;
        CategoryId = categoryId;
        Category = category;
    }

    private Allergy(
        int id,
        string title,
        string description,
        int categoryId)
        : base(id, title)
    {
        Description = description;
        CategoryId = categoryId;
    }
    
    #endregion Constructors
    
    #region Properties
    
    public string Description { get; private set; }

    public int CategoryId { get; private set; }

    public AllergyCategory Category { get; }
    
    #endregion Properties

    #region Seeds

    // Пищевые аллергии
    public static Allergy Peanut = new(1, "Арахис", "Аллергия на арахис и продукты содержащие арахис", 1);
    public static Allergy Milk = new(2, "Молоко", "Аллергия на белок коровьего молока", 1);
    public static Allergy Eggs = new(3, "Яйца", "Аллергия на яичный белок", 1);
    public static Allergy Fish = new(4, "Рыба", "Аллергия на рыбу и морепродукты", 1);
    public static Allergy Crustaceans = new(5, "Ракообразные", "Аллергия на креветки, крабы, лобстеры", 1);
    public static Allergy Nuts = new(6, "Орехи", "Аллергия на лесные орехи (грецкие, миндаль, кешью)", 1);
    public static Allergy Wheat = new(7, "Пшеница", "Аллергия на белок пшеницы", 1);
    public static Allergy Soy = new(8, "Соя", "Аллергия на соевые продукты", 1);
    public static Allergy Sesame = new(9, "Кунжут", "Аллергия на семена кунжута", 1);
    public static Allergy Kiwi = new(10, "Киви", "Аллергия на киви",  1);

    // Лекарственные аллергии
    public static Allergy Penicillin = new(11, "Пенициллин", "Аллергия на антибиотики пенициллинового ряда", 2);
    public static Allergy Aspirin = new(12, "Аспирин", "Аллергия на ацетилсалициловую кислоту", 2);
    public static Allergy Ibuprofen = new(13, "Ибупрофен", "Аллергия на нестероидные противовоспалительные", 2);
    public static Allergy Sulfonamides = new(14, "Сульфаниламиды", "Аллергия на сульфа drugs", 2);

    // Экологические аллергии
    public static Allergy BirchPollen = new(15, "Пыльца березы", "Сезонная аллергия на пыльцу березы", 3);
    public static Allergy RagweedPollen = new(16, "Пыльца амброзии", "Сезонная аллергия на амброзию", 3);
    public static Allergy DustMites = new(17, "Пылевые клещи", "Аллергия на домашних пылевых клещей", 3);
    public static Allergy CatHair = new(18, "Шерсть кошек", "Аллергия на кошачью шерсть", 3);
    public static Allergy DogHair = new(19, "Шерсть собак", "Аллергия на собачью шерсть", 3);
    public static Allergy Mold = new(20, "Плесень", "Аллергия на плесневые грибы", 3);

    #endregion Seeds
}