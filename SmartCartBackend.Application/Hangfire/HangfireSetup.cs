using System.Reflection;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartCardBackend.Application.Hangfire.Jobs;

namespace SmartCardBackend.Application.Hangfire;

public static class HangfireSetup
{
    public static IApplicationBuilder UseHangfire(
        this IApplicationBuilder app, 
        IJobScheduler scheduler,
        IConfiguration configuration)
    {
        var dashboardOptions = new DashboardOptions
        {
            Authorization = [new DashboardAuthorizationFilter()]
        };
        
        app.UseHangfireDashboard("/hangfire", dashboardOptions);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHangfireDashboard(dashboardOptions);
        });
        
        SchedulingJobs(scheduler, configuration);
        
        return app;
    }
    
    public static IServiceCollection ConfigureHangfire(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHangfireServer();

        services.AddHangfire(cfg => cfg
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(opt => opt
                    .UseNpgsqlConnection(configuration.GetConnectionString("Hangfire")),
                new PostgreSqlStorageOptions
                {
                    DistributedLockTimeout = TimeSpan.FromMinutes(5),
                    InvisibilityTimeout = TimeSpan.FromMinutes(5)
                })
            .UseFilter(new AutomaticRetryAttribute { Attempts = 1, DelaysInSeconds = [600]})
        );
        
        services.AddSingleton<IJobScheduler, JobScheduler>();
        
        RegistrationJobs(services);

        return services;
    }

    private static void SchedulingJobs(IJobScheduler scheduler, IConfiguration configuration)
    {
        var section = configuration.GetSection("JobOptions");
        
        var jobTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IJob).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var jobType in jobTypes)
        {
            var jobTypeName = jobType.Name;

            var options = section
                .GetSection($"{jobTypeName}Options")
                .Get<JobOptionsBase>();
            
            if (options?.Enabled == true)
                scheduler.ScheduleRecurringJob(jobType, options.Cron);
            else
                scheduler.RemoveRecurringJob(jobTypeName);
        }
    }

    private static void RegistrationJobs(IServiceCollection services)
    {
        var jobTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IJob).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .ToList();
        
        jobTypes.ForEach(jobType => services.AddTransient(jobType));
    }
}