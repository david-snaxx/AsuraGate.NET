using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Account;

/// <summary>Represents a material stored in the authenticated account's material storage.</summary>
public record AccountMaterial
{
    /// <summary>Item ID of the material; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Material storage category ID this item belongs to; resolvable to a <see cref="MaterialCategory"/>.</summary>
    [JsonPropertyName("category")]
    public required int Category { get; init; }

    /// <summary>Item binding type: "Account" if account-bound; null if unbound.</summary>
    [JsonPropertyName("binding")]
    public string? Binding { get; init; }

    /// <summary>Number of this material currently stored.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
