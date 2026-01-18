using System.Security.Cryptography;
using System.Text;

namespace SmartCardBackend.Application.Services.Helpers;

public class HashHelper
{
    public static string ComputeSha256(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        
        var bytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = SHA256.HashData(bytes);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
    }
}