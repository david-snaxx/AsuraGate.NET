using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the top-level account data for an authenticated Guild Wars 2 account.</summary>
public record Account
{
    /// <summary>Unique account UUID string.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Total time played across all characters, in seconds.</summary>
    [JsonPropertyName("age")]
    public required int Age { get; init; }

    /// <summary>Display name of the account including the four-digit discriminator (e.g., "PlayerName.1234").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Home world ID; resolvable to a <see cref="Model.World"/>.</summary>
    [JsonPropertyName("world")]
    public required int World { get; init; }

    /// <summary>List of guild IDs this account is a member of.</summary>
    [JsonPropertyName("guilds")]
    public string[] Guilds { get; init; } = [];

    /// <summary>List of guild IDs where this account holds a leader role (requires guilds scope).</summary>
    [JsonPropertyName("guild_leader")]
    public string[] GuildLeader { get; init; } = [];

    /// <summary>Timestamp of when this account was originally created.</summary>
    [JsonPropertyName("created")]
    public required DateTime Created { get; init; }

    /// <summary>List of game expansion access flags (e.g., "GuildWars2", "HeartOfThorns", "PathOfFire", "EndOfDragons", "SecretsOfTheObscure").</summary>
    [JsonPropertyName("access")]
    public string[] Access { get; init; } = [];

    /// <summary>Whether the account has purchased the Commander tag.</summary>
    [JsonPropertyName("commander")]
    public required bool Commander { get; init; }

    /// <summary>Highest personal fractal scale unlocked (requires progression scope); null if scope not granted.</summary>
    [JsonPropertyName("fractal_level")]
    public int? FractalLevel { get; init; }

    /// <summary>Daily achievement points earned today (requires progression scope); null if scope not granted.</summary>
    [JsonPropertyName("daily_ap")]
    public int? DailyAp { get; init; }

    /// <summary>Monthly achievement points earned this month (requires progression scope); null if scope not granted.</summary>
    [JsonPropertyName("monthly_ap")]
    public int? MonthlyAp { get; init; }

    /// <summary>Current WvW rank (requires progression scope); null if scope not granted.</summary>
    [JsonPropertyName("wvw_rank")]
    public int? WvwRank { get; init; }

    /// <summary>Current WvW team assignment and account rank (requires progression scope).</summary>
    [JsonPropertyName("wvw")]
    public AccountWvw? Wvw { get; init; }

    /// <summary>Timestamp of the most recent modification to this account.</summary>
    [JsonPropertyName("last_modified")]
    public required DateTime LastModified { get; init; }

    /// <summary>Number of build storage template slots purchased; null if scope not granted.</summary>
    [JsonPropertyName("build_storage_slots")]
    public int? BuildStorageSlots { get; init; }
}

/// <summary>Represents the World vs. World team assignment embedded in an <see cref="Account"/>.</summary>
public record AccountWvw
{
    /// <summary>ID of the WvW team this account is assigned to (corresponds to a home world ID or alliance ID).</summary>
    [JsonPropertyName("team_id")]
    public required int TeamId { get; init; }

    /// <summary>Current WvW rank of the account.</summary>
    [JsonPropertyName("rank")]
    public required int Rank { get; init; }
}
