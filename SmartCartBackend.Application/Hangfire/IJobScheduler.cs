using SmartCardBackend.Application.Hangfire.Jobs;

namespace SmartCardBackend.Application.Hangfire;

public interface IJobScheduler
{
    void ScheduleRecurringJob<TJob>(string cron) 
        where TJob : class, IJob;

    void ScheduleRecurringJob(Type jobType, string cron);
    
    void ScheduleDelayedJob<TJob>(TimeSpan delay)
        where TJob : class, IJob;
    
    void RemoveRecurringJob(string jobTypeName);
}