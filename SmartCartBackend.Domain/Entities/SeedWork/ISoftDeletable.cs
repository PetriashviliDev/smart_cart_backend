namespace SmartCardBackend.Domain.Entities.SeedWork;

public interface ISoftDeletable
{
    /// <summary>
    /// Признак удаления
    /// </summary>
    bool IsDeleted { get;  }

    /// <summary>
    /// Установка признака удаления
    /// </summary>
    /// <param name="isDeleted">Признак удаления</param>
    void SetIsDeleted(bool isDeleted = true);
}