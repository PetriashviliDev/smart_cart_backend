namespace SmartCardBackend.Domain.Entities.SeedWork;

public interface IActualizable<in TEnumeration> 
    where TEnumeration : Enumeration
{
    /// <summary>
    /// Актуализация справочника
    /// </summary>
    /// <param name="enumeration">Справочника</param>
    void Actualize(TEnumeration enumeration);
}