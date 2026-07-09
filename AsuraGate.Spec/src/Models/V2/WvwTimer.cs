using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the WvW weekly reset timestamps for each game region.</summary>
public record WvwTimer
{
    /// <summary>Timestamp of the next scheduled WvW reset for the North American region.</summary>
    [JsonPropertyName("na")]
    public required DateTime Na { get; init; }

    /// <summary>Timestamp of the next scheduled WvW reset for the European region.</summary>
    [JsonPropertyName("eu")]
    public required DateTime Eu { get; init; }
}
