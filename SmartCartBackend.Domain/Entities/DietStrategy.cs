using SmartCardBackend.Domain.Entities.SeedWork;

namespace SmartCardBackend.Domain.Entities;

/// <summary>
/// Доменная модель справочника стратегии диеты
/// </summary>
/// <param name="id">Идентификатор</param>
/// <param name="title">Наименование</param>
public class DietStrategy(
    int id,
    string title)
    : Enumeration(id, title)
{
    #region Seeds

    /// <summary>
    /// Поддержание веса
    /// </summary>
    public static DietStrategy WeightMaintenance = new(1, "Поддержание веса");
    
    /// <summary>
    /// Набор мышечной массы
    /// </summary>
    public static DietStrategy MuscleGain = new(2, "Набор мышечной массы");
    
    /// <summary>
    /// Повышение энергии
    /// </summary>
    public static DietStrategy EnergyBoost = new(3, "Повышение энергии");
    
    /// <summary>
    /// Улучшение общего самочувствия
    /// </summary>
    public static DietStrategy Wellbeing = new(4, "Улучшение общего самочувствия");
    
    /// <summary>
    /// Повышение энергии
    /// </summary>
    public static DietStrategy SportPreparation = new(5, "Подготовка к спортивному событию");
    
    /// <summary>
    /// Повышение энергии
    /// </summary>
    public static DietStrategy WeightLoss = new(6, "Похудение");
    
    #endregion Seeds
}