using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Account;

/// <summary>Represents the World vs. World team and rank details for the authenticated account.</summary>
public record AccountWvwDetails
{
    /// <summary>ID of the WvW world team this account is currently fighting for; corresponds to a home world or alliance ID.</summary>
    [JsonPropertyName("team_id")]
    public required int TeamId { get; init; }

    /// <summary>Current WvW rank of the account.</summary>
    [JsonPropertyName("rank")]
    public required int Rank { get; init; }

    /// <summary>Current WvW rating of the account; null if not available.</summary>
    [JsonPropertyName("rating")]
    public int? Rating { get; init; }
}
