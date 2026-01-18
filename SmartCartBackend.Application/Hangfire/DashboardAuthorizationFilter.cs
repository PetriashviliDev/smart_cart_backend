using Hangfire.Dashboard;

namespace SmartCardBackend.Application.Hangfire;

public class DashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}