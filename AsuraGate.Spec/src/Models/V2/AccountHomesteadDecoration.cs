using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a homestead decoration owned by the authenticated account.</summary>
public record AccountHomesteadDecoration
{
    /// <summary>Decoration ID; resolvable to a <see cref="HomesteadDecoration"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Number of this decoration owned by the account.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
