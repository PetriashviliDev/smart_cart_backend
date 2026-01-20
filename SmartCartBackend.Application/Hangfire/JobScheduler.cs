using Hangfire;
using Microsoft.Extensions.Logging;
using SmartCardBackend.Application.Hangfire.Jobs;

namespace SmartCardBackend.Application.Hangfire;

public class JobScheduler(
    ILogger<JobScheduler> logger,
    IRecurringJobManager manager) 
    : IJobScheduler
{
    public void ScheduleRecurringJob<TJob>(string cron) 
        where TJob : class, IJob
    {
        if (string.IsNullOrWhiteSpace(cron))
            return;
        
        manager.AddOrUpdate<TJob>(
            typeof(TJob).Name,
            job => job.ExecuteAsync(CancellationToken.None),
            cron,
            new RecurringJobOptions { TimeZone = TimeZoneInfo.Local });
    }

    public void ScheduleRecurringJob(Type jobType, string cron)
    {
        var scheduleMethod = typeof(JobScheduler)
            .GetMethod(nameof(ScheduleRecurringJob), [typeof(string)]);
        
        var genericScheduleMethod = scheduleMethod?.MakeGenericMethod(jobType);
        genericScheduleMethod?.Invoke(this, [cron]);
    }

    public void ScheduleDelayedJob<TJob>(TimeSpan delay) 
        where TJob : class, IJob
    {
        var jobId = BackgroundJob.Schedule<TJob>(job => 
            job.ExecuteAsync(CancellationToken.None), delay);
        
        logger.LogInformation($"Executing {typeof(TJob).Name} " +
                              $"({jobId}) planned after {delay.Minutes} minutes");
    }

    public void RemoveRecurringJob(string jobTypeName) => 
        manager.RemoveIfExists(jobTypeName);
}