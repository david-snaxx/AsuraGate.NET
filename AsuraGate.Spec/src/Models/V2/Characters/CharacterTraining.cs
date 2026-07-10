using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Characters;

/// <summary>Represents the hero point training progress across all training tracks for a character.</summary>
public record CharacterTraining
{
    /// <summary>Training track entries showing progress in each skill and specialization track.</summary>
    [JsonPropertyName("training")]
    public TrainingTree[] Training { get; init; } = [];
}

/// <summary>Represents the hero point investment progress in a single training track within <see cref="CharacterTraining"/>.</summary>
public record TrainingTree
{
    /// <summary>Training track ID corresponding to a profession training tree; resolvable via the profession's training list in <see cref="Profession"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Total hero points spent in this training track.</summary>
    [JsonPropertyName("spent")]
    public required int Spent { get; init; }

    /// <summary>Whether all nodes in this training track have been fully unlocked.</summary>
    [JsonPropertyName("done")]
    public required bool Done { get; init; }
}
