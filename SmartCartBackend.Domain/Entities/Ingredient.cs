using System.Text.Json.Serialization;
using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель ингредиента
/// </summary>
public class Ingredient : DisplayEnumeration
{
    #region Constructors

    [JsonConstructor]
    protected Ingredient(
        int id,
        string title,
        string description,
        string image,
        decimal calories, 
        decimal proteins, 
        decimal fats, 
        decimal carbohydrates,
        decimal price,
        List<DishIngredient> dishIngredients) 
        : base(id, title, description, image)
    {
        Calories = calories;
        Proteins = proteins;
        Fats = fats;
        Carbohydrates = carbohydrates;
        Price = price;
        _dishIngredients = dishIngredients;
    }
    
    private Ingredient(
        int id,
        string title,
        string description,
        string image,
        decimal calories, 
        decimal proteins, 
        decimal fats, 
        decimal carbohydrates,
        decimal price) 
        : base(id, title, description, image)
    {
        Calories = calories;
        Proteins = proteins;
        Fats = fats;
        Carbohydrates = carbohydrates;
        Price = price;
        _dishIngredients = [];
    }

    public static Ingredient Create(
        int id,
        string title,
        string description,
        string image,
        decimal calories,
        decimal proteins,
        decimal fats,
        decimal carbohydrates,
        decimal price)
    {
        var ingredient = new Ingredient(id, title, description,
            image, calories, proteins, fats, carbohydrates, price);
        
        return ingredient;
    }
    
    #endregion Constructors

    #region Properties
    
    /// <summary>
    /// Калории на 100 г.
    /// </summary>
    public decimal Calories { get; private set; }
    
    /// <summary>
    /// Белок на 100 г.
    /// </summary>
    public decimal Proteins { get; private set; }
    
    /// <summary>
    /// Жиры на 100 г.
    /// </summary>
    public decimal Fats { get; private set; }
    
    /// <summary>
    /// Углеводы на 100 г.
    /// </summary>
    public decimal Carbohydrates { get; private set; }

    /// <summary>
    /// Цена за 100 г.
    /// </summary>
    public decimal Price { get; private set; }

    /// <summary>
    /// Связи блюда и ингредиентов
    /// </summary>
    public IReadOnlyCollection<DishIngredient> DishIngredients => _dishIngredients.AsReadOnly();

    private readonly List<DishIngredient> _dishIngredients;
    
    #endregion Properties

    #region Seeds

    // Овощи
    public static readonly Ingredient Tomato = new(1, "Помидор", "Свежий красный помидор", "tomato.jpg", 18, 0.9m, 0.2m, 3.9m, 50);
    public static readonly Ingredient Cucumber = new(2, "Огурец", "Свежий зеленый огурец", "cucumber.jpg", 15, 0.8m, 0.1m, 2.8m, 40);
    public static readonly Ingredient Onion = new(3, "Лук репчатый", "Репчатый лук", "onion.jpg", 40, 1.1m, 0.1m, 9.3m, 30);
    public static readonly Ingredient Carrot = new(4, "Морковь", "Свежая морковь", "carrot.jpg", 41, 0.9m, 0.2m, 9.6m, 35);
    public static readonly Ingredient Potato = new(5, "Картофель", "Свежий картофель", "potato.jpg", 77, 2.0m, 0.1m, 17.5m, 45);
    public static readonly Ingredient BellPepper = new(6, "Болгарский перец", "Сладкий перец", "bell_pepper.jpg", 27, 1.0m, 0.3m, 6.0m, 70);
    public static readonly Ingredient Garlic = new(7, "Чеснок", "Свежий чеснок", "garlic.jpg", 149, 6.4m, 0.5m, 33.1m, 25);
    public static readonly Ingredient Cabbage = new(8, "Капуста белокочанная", "Свежая капуста", "cabbage.jpg", 25, 1.3m, 0.1m, 5.8m, 40);
    public static readonly Ingredient Broccoli = new(9, "Брокколи", "Свежая брокколи", "broccoli.jpg", 34, 2.8m, 0.4m, 7.0m, 120);
    public static readonly Ingredient Cauliflower = new(10, "Цветная капуста", "Свежая цветная капуста", "cauliflower.jpg", 25, 2.0m, 0.3m, 5.0m, 90);
    public static readonly Ingredient Zucchini = new(11, "Кабачок", "Свежий кабачок", "zucchini.jpg", 17, 1.2m, 0.3m, 3.1m, 60);
    public static readonly Ingredient Eggplant = new(12, "Баклажан", "Свежий баклажан", "eggplant.jpg", 24, 1.0m, 0.2m, 5.7m, 80);
    public static readonly Ingredient Spinach = new(13, "Шпинат", "Свежий шпинат", "spinach.jpg", 23, 2.9m, 0.4m, 3.6m, 100);
    public static readonly Ingredient Lettuce = new(14, "Салат листовой", "Свежий салат", "lettuce.jpg", 15, 1.4m, 0.2m, 2.9m, 70);
    public static readonly Ingredient Celery = new(15, "Сельдерей", "Стебли сельдерея", "celery.jpg", 16, 0.7m, 0.2m, 3.0m, 55);

    // Фрукты и ягоды
    public static readonly Ingredient Apple = new(16, "Яблоко", "Свежее яблоко", "apple.jpg", 52, 0.3m, 0.2m, 14.0m, 60);
    public static readonly Ingredient Banana = new(17, "Банан", "Спелый банан", "banana.jpg", 89, 1.1m, 0.3m, 22.8m, 50);
    public static readonly Ingredient Orange = new(18, "Апельсин", "Свежий апельсин", "orange.jpg", 47, 0.9m, 0.1m, 11.8m, 70);
    public static readonly Ingredient Lemon = new(19, "Лимон", "Свежий лимон", "lemons.jpg", 29, 1.1m, 0.3m, 9.3m, 40);
    public static readonly Ingredient Strawberry = new(20, "Клубника", "Свежая клубника", "strawberry.jpg", 32, 0.7m, 0.3m, 7.7m, 150);
    public static readonly Ingredient Blueberry = new(21, "Черника", "Свежая черника", "blueberry.jpg", 57, 0.7m, 0.3m, 14.5m, 200);
    public static readonly Ingredient Avocado = new(22, "Авокадо", "Спелый авокадо", "avocado.jpg", 160, 2.0m, 15.0m, 9.0m, 180);

    // Мясо и птица
    public static readonly Ingredient ChickenBreast = new(23, "Куриная грудка", "Филе куриной грудки", "chicken_breast.jpg", 165, 31.0m, 3.6m, 0.0m, 200);
    public static readonly Ingredient ChickenThigh = new(24, "Куриное бедро", "Куриное бедро с кожей", "chicken_thigh.jpg", 209, 26.0m, 11.0m, 0.0m, 180);
    public static readonly Ingredient Beef = new(25, "Говядина", "Постная говядина", "beef.jpg", 250, 26.0m, 15.0m, 0.0m, 350);
    public static readonly Ingredient Pork = new(26, "Свинина", "Свиная вырезка", "pork.jpg", 242, 25.0m, 14.0m, 0.0m, 300);
    public static readonly Ingredient Turkey = new(27, "Индейка", "Филе индейки", "turkey.jpg", 135, 29.0m, 3.0m, 0.0m, 250);
    public static readonly Ingredient Bacon = new(28, "Бекон", "Копченый бекон", "bacon.jpg", 541, 37.0m, 42.0m, 1.4m, 400);
    public static readonly Ingredient Sausage = new(29, "Сосиски", "Молочные сосиски", "sausage.jpg", 260, 12.0m, 23.0m, 2.0m, 180);

    // Рыба и морепродукты
    public static readonly Ingredient Salmon = new(30, "Лосось", "Филе лосося", "salmon.jpg", 208, 20.0m, 13.0m, 0.0m, 500);
    public static readonly Ingredient Tuna = new(31, "Тунец", "Филе тунца", "tuna.jpg", 184, 30.0m, 6.0m, 0.0m, 450);
    public static readonly Ingredient Cod = new(32, "Треска", "Филе трески", "cod.jpg", 82, 18.0m, 0.7m, 0.0m, 350);
    public static readonly Ingredient Shrimp = new(33, "Креветки", "Очищенные креветки", "shrimp.jpg", 85, 18.0m, 1.0m, 1.0m, 400);
    public static readonly Ingredient Mussels = new(34, "Мидии", "Свежие мидии", "mussels.jpg", 86, 12.0m, 2.0m, 4.0m, 300);

    // Молочные продукты и яйца
    public static readonly Ingredient Milk = new(35, "Молоко", "Цельное молоко", "milk.jpg", 61, 3.2m, 3.6m, 4.8m, 80);
    public static readonly Ingredient Cheese = new(36, "Сыр", "Твердый сыр", "cheese.jpg", 350, 25.0m, 27.0m, 1.3m, 150);
    public static readonly Ingredient CottageCheese = new(37, "Творог", "Обезжиренный творог", "cottage_cheese.jpg", 72, 16.0m, 0.5m, 3.0m, 100);
    public static readonly Ingredient Yogurt = new(38, "Йогурт", "Греческий йогурт", "yogurt.jpg", 59, 10.0m, 0.4m, 3.6m, 90);
    public static readonly Ingredient SourCream = new(39, "Сметана", "Сметана 20%", "sour_cream.jpg", 206, 2.8m, 20.0m, 3.2m, 70);
    public static readonly Ingredient Butter = new(40, "Сливочное масло", "Сливочное масло 82%", "butter.jpg", 717, 0.9m, 81.0m, 0.1m, 120);
    public static readonly Ingredient Eggs = new(41, "Яйца", "Куриные яйца", "eggs.jpg", 155, 13.0m, 11.0m, 1.1m, 80);

    // Крупы и зерновые
    public static readonly Ingredient Rice = new(42, "Рис", "Белый рис", "rice.jpg", 130, 2.7m, 0.3m, 28.0m, 80);
    public static readonly Ingredient Buckwheat = new(43, "Гречка", "Гречневая крупа", "buckwheat.jpg", 343, 13.0m, 3.4m, 72.0m, 70);
    public static readonly Ingredient Oatmeal = new(44, "Овсянка", "Овсяные хлопья", "oatmeal.jpg", 389, 16.9m, 6.9m, 66.3m, 60);
    public static readonly Ingredient Pasta = new(45, "Макароны", "Спагетти", "pasta.jpg", 131, 5.0m, 1.0m, 25.0m, 90);
    public static readonly Ingredient Bread = new(46, "Хлеб", "Пшеничный хлеб", "bread.jpg", 265, 9.0m, 3.2m, 49.0m, 50);
    public static readonly Ingredient Flour = new(47, "Мука", "Пшеничная мука", "flour.jpg", 364, 10.0m, 1.0m, 76.0m, 60);

    // Бобовые и орехи
    public static readonly Ingredient Beans = new(48, "Фасоль", "Консервированная фасоль", "beans.jpg", 139, 9.0m, 0.5m, 25.0m, 100);
    public static readonly Ingredient Lentils = new(49, "Чечевица", "Красная чечевица", "lentils.jpg", 116, 9.0m, 0.4m, 20.0m, 110);
    public static readonly Ingredient Peas = new(50, "Горох", "Зеленый горошек", "peas.jpg", 81, 5.0m, 0.4m, 14.0m, 70);
    public static readonly Ingredient Almonds = new(51, "Миндаль", "Сырой миндаль", "almonds.jpg", 579, 21.0m, 50.0m, 22.0m, 300);
    public static readonly Ingredient Walnuts = new(52, "Грецкие орехи", "Ядра грецких орехов", "walnuts.jpg", 654, 15.0m, 65.0m, 14.0m, 250);
    public static readonly Ingredient Peanuts = new(53, "Арахис", "Жареный арахис", "peanuts.jpg", 567, 26.0m, 49.0m, 16.0m, 200);

    // Масла и жиры
    public static readonly Ingredient OliveOil = new(54, "Оливковое масло", "Extra virgin", "olive_oil.jpg", 884, 0.0m, 100.0m, 0.0m, 300);
    public static readonly Ingredient SunflowerOil = new(55, "Подсолнечное масло", "Рафинированное", "sunflower_oil.jpg", 884, 0.0m, 100.0m, 0.0m, 150);
    public static readonly Ingredient CoconutOil = new(56, "Кокосовое масло", "Органическое", "coconut_oil.jpg", 862, 0.0m, 100.0m, 0.0m, 250);

    // Специи и приправы
    public static readonly Ingredient Salt = new(57, "Соль", "Поваренная соль", "salt.jpg", 0, 0.0m, 0.0m, 0.0m, 20);
    public static readonly Ingredient BlackPepper = new(58, "Черный перец", "Молотый перец", "black_pepper.jpg", 251, 10.0m, 3.3m, 64.0m, 30);
    public static readonly Ingredient Sugar = new(59, "Сахар", "Белый сахар", "sugar.jpg", 387, 0.0m, 0.0m, 100.0m, 40);
    public static readonly Ingredient Honey = new(60, "Мед", "Натуральный мед", "honey.jpg", 304, 0.3m, 0.0m, 82.0m, 200);
    public static readonly Ingredient Vinegar = new(61, "Уксус", "Яблочный уксус", "vinegar.jpg", 18, 0.0m, 0.0m, 0.9m, 80);
    public static readonly Ingredient SoySauce = new(62, "Соевый соус", "Темный соевый соус", "soy_sauce.jpg", 53, 8.0m, 0.0m, 5.0m, 120);
    public static readonly Ingredient Ketchup = new(63, "Кетчуп", "Томатный кетчуп", "ketchup.jpg", 101, 1.8m, 0.3m, 25.0m, 90);
    public static readonly Ingredient Mayonnaise = new(64, "Майонез", "Классический майонез", "mayonnaise.jpg", 680, 1.0m, 75.0m, 2.6m, 100);

    // Травы и зелень
    public static readonly Ingredient Basil = new(65, "Базилик", "Свежий базилик", "basil.jpg", 23, 3.2m, 0.6m, 2.7m, 60);
    public static readonly Ingredient Parsley = new(66, "Петрушка", "Свежая петрушка", "parsley.jpg", 36, 3.0m, 0.8m, 6.3m, 40);
    public static readonly Ingredient Dill = new(67, "Укроп", "Свежий укроп", "dill.jpg", 43, 3.5m, 1.1m, 7.0m, 35);
    public static readonly Ingredient Cilantro = new(68, "Кинза", "Свежая кинза", "cilantro.jpg", 23, 2.1m, 0.5m, 3.7m, 45);
    public static readonly Ingredient Mint = new(69, "Мята", "Свежая мята", "mint.jpg", 70, 3.8m, 0.9m, 14.9m, 50);

    // Напитки
    public static readonly Ingredient Coffee = new(70, "Кофе", "Молотый кофе", "coffee.jpg", 1, 0.1m, 0.0m, 0.0m, 250);
    public static readonly Ingredient Tea = new(71, "Чай", "Черный чай", "tea.jpg", 1, 0.0m, 0.0m, 0.3m, 150);
    public static readonly Ingredient Water = new(72, "Вода", "Питьевая вода", "water.jpg", 0, 0.0m, 0.0m, 0.0m, 20);

    // Консервы и готовые продукты
    public static readonly Ingredient TomatoPaste = new(73, "Томатная паста", "Концентрированная паста", "tomato_paste.jpg", 82, 4.3m, 0.5m, 19.0m, 70);
    public static readonly Ingredient CannedCorn = new(74, "Кукуруза консервированная", "Сладкая кукуруза", "canned_corn.jpg", 86, 3.3m, 1.2m, 19.0m, 80);
    public static readonly Ingredient CannedPeas = new(75, "Горошек консервированный", "Зеленый горошек", "canned_peas.jpg", 69, 4.4m, 0.4m, 12.0m, 75);
    public static readonly Ingredient Olives = new(76, "Оливки", "Консервированные оливки", "olives.jpg", 115, 0.8m, 11.0m, 6.0m, 120);
    public static readonly Ingredient Pickles = new(77, "Огурцы маринованные", "Соленые огурцы", "pickles.jpg", 11, 0.6m, 0.1m, 2.3m, 60);

    // Сладости и десерты
    public static readonly Ingredient Chocolate = new(78, "Шоколад", "Темный шоколад", "chocolate.jpg", 546, 4.9m, 31.0m, 61.0m, 180);
    public static readonly Ingredient Vanilla = new(79, "Ваниль", "Ванильный экстракт", "vanilla.jpg", 288, 0.1m, 0.1m, 13.0m, 200);
    public static readonly Ingredient Cinnamon = new(80, "Корица", "Молотая корица", "cinnamon.jpg", 247, 4.0m, 1.2m, 81.0m, 90);

    // Дополнительные ингредиенты
    public static readonly Ingredient Mushrooms = new(81, "Грибы", "Свежие шампиньоны", "mushrooms.jpg", 22, 3.1m, 0.3m, 3.3m, 120);
    public static readonly Ingredient Ginger = new(82, "Имбирь", "Свежий корень имбиря", "ginger.jpg", 80, 1.8m, 0.8m, 18.0m, 100);
    public static readonly Ingredient Chili = new(83, "Перец чили", "Острый перец", "chili.jpg", 40, 2.0m, 0.2m, 9.0m, 60);
    public static readonly Ingredient Corn = new(84, "Кукуруза", "Свежая кукуруза", "corn.jpg", 86, 3.3m, 1.2m, 19.0m, 50);
    public static readonly Ingredient Beetroot = new(85, "Свекла", "Свежая свекла", "beetroot.jpg", 43, 1.6m, 0.2m, 9.6m, 40);
    public static readonly Ingredient Radish = new(86, "Редис", "Свежий редис", "radish.jpg", 16, 0.7m, 0.1m, 3.4m, 35);
    public static readonly Ingredient Asparagus = new(87, "Спаржа", "Свежая спаржа", "asparagus.jpg", 20, 2.2m, 0.1m, 3.9m, 180);
    public static readonly Ingredient Artichoke = new(88, "Артишок", "Свежий артишок", "artichoke.jpg", 47, 3.3m, 0.2m, 10.5m, 200);
    public static readonly Ingredient Pineapple = new(89, "Ананас", "Свежий ананас", "pineapple.jpg", 50, 0.5m, 0.1m, 13.0m, 150);
    public static readonly Ingredient Mango = new(90, "Манго", "Спелое манго", "mango.jpg", 60, 0.8m, 0.4m, 15.0m, 170);
    public static readonly Ingredient Kiwi = new(91, "Киви", "Свежий киви", "kiwi.jpg", 61, 1.1m, 0.5m, 14.7m, 100);
    public static readonly Ingredient Pomegranate = new(92, "Гранат", "Спелый гранат", "pomegranate.jpg", 83, 1.7m, 1.2m, 19.0m, 220);
    public static readonly Ingredient Dates = new(93, "Финики", "Сушеные финики", "dates.jpg", 282, 2.5m, 0.4m, 75.0m, 180);
    public static readonly Ingredient Raisins = new(94, "Изюм", "Сушеный виноград", "raisins.jpg", 299, 3.1m, 0.5m, 79.0m, 120);
    public static readonly Ingredient Coconut = new(95, "Кокос", "Свежий кокос", "coconut.jpg", 354, 3.3m, 33.0m, 15.0m, 250);
    public static readonly Ingredient Sesame = new(96, "Кунжут", "Семена кунжута", "sesame.jpg", 573, 18.0m, 50.0m, 23.0m, 140);
    public static readonly Ingredient SunflowerSeeds = new(97, "Семечки подсолнечника", "Жареные семечки", "sunflower_seeds.jpg", 584, 21.0m, 51.0m, 20.0m, 100);
    public static readonly Ingredient Mustard = new(98, "Горчица", "Дижонская горчица", "mustard.jpg", 66, 4.4m, 3.3m, 5.8m, 80);
    public static readonly Ingredient Horseradish = new(99, "Хрен", "Тертый хрен", "horseradish.jpg", 48, 1.2m, 0.1m, 11.3m, 90);
    public static readonly Ingredient MapleSyrup = new(100, "Кленовый сироп", "Натуральный сироп", "maple_syrup.jpg", 260, 0.0m, 0.1m, 67.0m, 300);

    #endregion Seeds
}