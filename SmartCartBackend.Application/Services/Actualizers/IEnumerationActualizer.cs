namespace SmartCardBackend.Application.Services.Actualizers;

public interface IEnumerationActualizer
{
    Task ActualizeAsync(CancellationToken ct = default);
}