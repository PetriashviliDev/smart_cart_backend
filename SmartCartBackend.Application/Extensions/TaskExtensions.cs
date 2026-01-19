using System.Reflection;

namespace SmartCardBackend.Application.Extensions;

public static class TaskExtensions
{
    public static async Task<object> InvokeAsync(
        this MethodInfo @this,
        object instance,
        params object[] parameters)
    {
        var task = (Task)@this.Invoke(instance, parameters);
        if (task != null)
            await task.ConfigureAwait(false);
        
        var result = task?.GetType().GetProperty("Result")?.GetValue(task);
        return result;
    }
}