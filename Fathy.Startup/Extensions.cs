using System.Text.Json;

namespace Fathy.Startup;

public static class Extensions
{
    public static string ToJsonStringContent<T>(this T data) => JsonSerializer.Serialize(data);
}