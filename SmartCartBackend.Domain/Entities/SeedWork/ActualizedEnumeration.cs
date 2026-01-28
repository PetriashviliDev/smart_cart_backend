namespace SmartCardBackend.Domain.Entities.SeedWork;

/// <summary>
/// Актуализируемый справочник
/// </summary>
/// <typeparam name="TEnumeration">Тип справочника</typeparam>
public abstract class ActualizedEnumeration<TEnumeration>
    : Enumeration, IActualizable<TEnumeration>
    where TEnumeration : Enumeration
{
    protected ActualizedEnumeration() { }

    protected ActualizedEnumeration(
        int id,
        string title,
        string internalName)
        : base(id, title, internalName) { }

    /// <inheritdoc />
    public virtual void Actualize(TEnumeration enumeration)
    {
        SetTitle(enumeration.Title);
        SetInternalName(enumeration.InternalName);
        SetIsDeleted(enumeration.IsDeleted);
    }
}