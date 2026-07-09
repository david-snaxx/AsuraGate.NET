using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents the metadata for a GW2 API key or subtoken, including its granted permission scopes.</summary>
public record TokenInfo
{
    /// <summary>The API key or subtoken string value.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>User-assigned name for this API key.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>List of permission scopes granted (e.g., "account", "characters", "inventories").</summary>
    [JsonPropertyName("permissions")]
    public string[] Permissions { get; init; } = [];

    /// <summary>Token type: "APIKey" for standard keys, "Subtoken" for subtokens.</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Expiry timestamp; present only for subtokens, null for standard API keys.</summary>
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; init; }

    /// <summary>Timestamp when this token was issued; null for standard API keys.</summary>
    [JsonPropertyName("issued_at")]
    public DateTime? IssuedAt { get; init; }

    /// <summary>List of allowed endpoint URL prefixes; present only for subtokens with URL restrictions.</summary>
    [JsonPropertyName("urls")]
    public string[] Urls { get; init; } = [];
}
