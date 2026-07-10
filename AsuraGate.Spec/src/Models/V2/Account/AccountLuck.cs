using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Account;

/// <summary>Represents the total accumulated luck on the authenticated account.</summary>
public record AccountLuck
{
    /// <summary>Luck identifier string (always "luck").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Total amount of luck accumulated on this account.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}
