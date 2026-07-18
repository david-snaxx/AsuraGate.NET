using System.Text.Json.Serialization;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Spec.Models.V2.Account;

/// <summary>Represents the progress and completion state of a single achievement for the authenticated account.</summary>
public record AccountAchievement
{
    /// <summary>Achievement ID; resolvable to an <see cref="Achievement"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Whether the achievement has been fully completed.</summary>
    [JsonPropertyName("done")]
    public required bool Done { get; init; }

    /// <summary>Zero-based bit indices representing which optional steps or collectibles within the achievement are completed; empty if none completed or the achievement has no bits.</summary>
    [JsonPropertyName("bits")]
    public int[] Bits { get; init; } = [];

    /// <summary>Current progress toward the achievement's goal; null if this achievement does not use a progress counter.</summary>
    [JsonPropertyName("current")]
    public int? Current { get; init; }

    /// <summary>Maximum progress value required to complete the achievement; null if not applicable.</summary>
    [JsonPropertyName("max")]
    public int? Max { get; init; }

    /// <summary>Number of times this achievement has been completed and repeated (for repeatable achievements); null if never repeated or not repeatable.</summary>
    [JsonPropertyName("repeated")]
    public int? Repeated { get; init; }

    /// <summary>Whether this achievement is currently available to earn on this account; null if always available.</summary>
    [JsonPropertyName("unlocked")]
    public bool? Unlocked { get; init; }
}
