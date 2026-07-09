using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a PvP rank tier milestone, defining the title and finisher awarded across a range of PvP rank numbers.</summary>
public record PvpRank
{
    /// <summary>Unique rank ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Finisher ID associated with this rank tier; resolvable to a <see cref="Finisher"/>.</summary>
    [JsonPropertyName("finisher_id")]
    public required int FinisherId { get; init; }

    /// <summary>Display name of this rank tier (e.g., "Veteran", "Champion").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>URL to the rank tier's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Minimum PvP rank number included in this tier (inclusive).</summary>
    [JsonPropertyName("min_rank")]
    public required int MinRank { get; init; }

    /// <summary>Maximum PvP rank number included in this tier (inclusive).</summary>
    [JsonPropertyName("max_rank")]
    public required int MaxRank { get; init; }

    /// <summary>Individual level thresholds within this rank tier.</summary>
    [JsonPropertyName("levels")]
    public PvpRankLevel[] Levels { get; init; } = [];
}

/// <summary>Represents a single level step within a <see cref="PvpRank"/> tier.</summary>
public record PvpRankLevel
{
    /// <summary>Minimum rank number for this level (inclusive).</summary>
    [JsonPropertyName("min_rank")]
    public required int MinRank { get; init; }

    /// <summary>Maximum rank number for this level (inclusive).</summary>
    [JsonPropertyName("max_rank")]
    public required int MaxRank { get; init; }

    /// <summary>Total rank points required to advance through this level.</summary>
    [JsonPropertyName("points")]
    public required int Points { get; init; }
}
