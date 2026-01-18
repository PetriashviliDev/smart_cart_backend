namespace SmartCardBackend.Application.Hangfire.Jobs;

public interface IJob
{
    Task ExecuteAsync(CancellationToken ct = default);
}