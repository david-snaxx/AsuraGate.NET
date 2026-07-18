using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Persistence.Static.Mappers;

public static class MapperUtils
{
    private static ILogger? _logger;
    public static void Configure(ILogger logger) => _logger = logger;
    
    public static string? SerializeModel<TModel>(TModel model, JsonSerializerOptions? options = null)
    {
        try
        {
            return JsonSerializer.Serialize(model, options);
        }
        catch (JsonException jsonException)
        {
            _logger?.LogWarning(jsonException, "Failed to serialize {Type}", typeof(TModel).Name);
            return null;
        }
    }

    public static TModel? DeserializeJson<TModel>(string json, JsonSerializerOptions? options = null)
    {
        if (string.IsNullOrEmpty(json))
        {
            return default;
        }

        try
        {
            return JsonSerializer.Deserialize<TModel>(json, options);
        }
        catch (JsonException jsonException)
        {
            _logger?.LogWarning(jsonException, "Failed to deserialize {Type}", typeof(TModel).Name);
            return default;
        }
    }
}