namespace SmartCardBackend.Application.Hangfire;

public record JobOptionsBase
{
    public bool Enabled { get; set; }

    public string Cron { get; set; }
}