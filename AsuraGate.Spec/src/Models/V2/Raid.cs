using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a raid instance in GW2, grouping its component wings and events.</summary>
public record Raid
{
    /// <summary>Unique raid identifier string (e.g., "forsaken_thicket").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>List of wings within this raid; see <see cref="RaidWing"/>.</summary>
    [JsonPropertyName("wings")]
    public RaidWing[] Wings { get; init; } = [];
}

/// <summary>Represents a wing within a <see cref="Raid"/>.</summary>
public record RaidWing
{
    /// <summary>Unique wing identifier string.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>List of events (bosses and checkpoints) within this wing; see <see cref="RaidEvent"/>.</summary>
    [JsonPropertyName("events")]
    public RaidEvent[] Events { get; init; } = [];
}

/// <summary>Represents a single event (boss encounter or checkpoint) within a <see cref="RaidWing"/>.</summary>
public record RaidEvent
{
    /// <summary>Unique event identifier string.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Event category (e.g., "Boss", "Checkpoint").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
