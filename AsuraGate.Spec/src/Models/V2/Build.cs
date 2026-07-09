using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents the current GW2 game build.</summary>
public record Build
{
    /// <summary>The current build ID; increments with each game update and is used to determine whether cached static data is stale.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }
}
