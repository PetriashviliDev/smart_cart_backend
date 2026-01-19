namespace SmartCardBackend.Domain.Extensions;

public static class StringExtensions
{
    public static bool EqualsIgnoreCase(this string str, string other) => 
        string.Equals(str, other, StringComparison.OrdinalIgnoreCase);
}