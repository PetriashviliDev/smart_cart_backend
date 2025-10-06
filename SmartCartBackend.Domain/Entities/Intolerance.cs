using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

public class Intolerance(
    int id,
    string title) : Enumeration(id, title)
{
    #region Seeds
    
    public static Intolerance Lactose = new(1, "Лактоза");
    public static Intolerance Gluten = new(2, "Глютен");
    public static Intolerance Fructose = new(3, "Фруктоза");
    public static Intolerance Histamine = new(4, "Гистамин");
    public static Intolerance Sorbitol = new(5, "Сорбитол");
    public static Intolerance Celiac = new(6, "Глютен (целиакия)");
    public static Intolerance Fructans = new(7, "Фруктаны");
    public static Intolerance Galactose = new(8, "Галактоза");
    public static Intolerance Casein = new(9, "Казеин");
    public static Intolerance Yeast = new(10, "Дрожжи");

    #endregion Seeds
}