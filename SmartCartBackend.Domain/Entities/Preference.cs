using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class Preference(
    int id,
    string title,
    string description) : Enumeration(id, title)
{
    public string Description { get; private set; } = description;

    #region Seeds

    // Диетические предпочтения
    public static Preference Vegetarianism = new(1, "Вегетарианство", "Исключение мяса, но допущение молочных продуктов и яиц");
    public static Preference Veganism = new(2, "Веганство", "Полное исключение продуктов животного происхождения");
    public static Preference Pescatarianism = new(3, "Пескетарианство", "Исключение мяса, но допущение рыбы и морепродуктов");
    public static Preference Pollotarianism = new(4, "Поллотарианство", "Исключение красного мяса, но допущение птицы");
    public static Preference Flexitarianism = new(5, "Флекситарианство", "Преимущественно растительная диета с редким употреблением мяса");
    public static Preference GlutenFree = new(6, "Безглютеновая диета", "Исключение глютеносодержащих продуктов");
    public static Preference Paleo = new(7, "Палео диета", "Диета древних людей - мясо, рыба, овощи, орехи");
    public static Preference Keto = new(8, "Кето диета", "Низкоуглеводная высокожировая диета");
    public static Preference LowCarb = new(9, "Низкоуглеводная диета", "Ограничение углеводов в рационе");
    public static Preference Mediterranean = new(10, "Средиземноморская диета", "Диета на основе овощей, фруктов, оливкового масла");

    // Этические предпочтения
    public static Preference Organic = new(11, "Органические продукты", "Предпочтение органически выращенным продуктам");
    public static Preference Local = new(12, "Локальные продукты", "Предпочтение местным производителям");
    public static Preference Seasonal = new(13, "Сезонные продукты", "Предпочтение сезонным фруктам и овощам");
    public static Preference FairTrade = new(14, "Справедливая торговля", "Поддержка fair trade продуктов");
    public static Preference CrueltyFree = new(15, "Без жестокости", "Продукты, не тестированные на животных");

    // Образ жизни
    public static Preference AlcoholFree = new(16, "Без алкоголя", "Исключение алкогольных напитков");
    public static Preference CaffeineFree = new(17, "Без кофеина", "Исключение кофеиносодержащих продуктов");
    public static Preference LowSalt = new(18, "Низкое содержание соли", "Ограничение натрия в рационе");
    public static Preference LowSugar = new(19, "Низкое содержание сахара", "Ограничение сахара в рационе");
    public static Preference HighProtein = new(20, "Высокобелковая диета", "Увеличение потребления белка");

    #endregion Seeds
}