using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a guild's PvP team and its match history and season statistics.</summary>
public record GuildTeam
{
    /// <summary>Unique team ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the team.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Current team state (e.g., "Active", "Disbanded").</summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    /// <summary>Guild members on this team.</summary>
    [JsonPropertyName("members")]
    public TeamMember[] Members { get; init; } = [];

    /// <summary>Aggregated win/loss statistics across all ladders.</summary>
    [JsonPropertyName("aggregate")]
    public required PvpStatBreakdown Aggregate { get; init; }

    /// <summary>Per-ladder win/loss statistics keyed by ladder name.</summary>
    [JsonPropertyName("ladders")]
    public Dictionary<string, PvpStatBreakdown> Ladders { get; init; } = [];

    /// <summary>Recent games played by this team.</summary>
    [JsonPropertyName("games")]
    public TeamGame[] Games { get; init; } = [];

    /// <summary>Per-season rating records for this team.</summary>
    [JsonPropertyName("seasons")]
    public TeamSeason[] Seasons { get; init; } = [];
}

/// <summary>Represents a single guild member on a <see cref="GuildTeam"/>.</summary>
public record TeamMember
{
    /// <summary>Account display name of the team member.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Role within the team (e.g., "Captain", "Member").</summary>
    [JsonPropertyName("role")]
    public required string Role { get; init; }
}

/// <summary>Represents a win/loss breakdown for a <see cref="GuildTeam"/> in a specific ladder or in aggregate.</summary>
public record PvpStatBreakdown
{
    /// <summary>Number of games won.</summary>
    [JsonPropertyName("wins")]
    public required int Wins { get; init; }

    /// <summary>Number of games lost.</summary>
    [JsonPropertyName("losses")]
    public required int Losses { get; init; }

    /// <summary>Number of games the team deserted (left early, resulting in a loss).</summary>
    [JsonPropertyName("desertions")]
    public required int Desertions { get; init; }

    /// <summary>Number of byes received (automatic wins with no opponent).</summary>
    [JsonPropertyName("byes")]
    public required int Byes { get; init; }

    /// <summary>Number of games forfeited.</summary>
    [JsonPropertyName("forfeits")]
    public required int Forfeits { get; init; }
}

/// <summary>Represents a single PvP game played by a <see cref="GuildTeam"/>.</summary>
public record TeamGame
{
    /// <summary>Unique game ID (UUID string).</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>ID of the PvP map this game was played on.</summary>
    [JsonPropertyName("map_id")]
    public required int MapId { get; init; }

    /// <summary>Timestamp when the game started.</summary>
    [JsonPropertyName("started")]
    public required DateTime Started { get; init; }

    /// <summary>Timestamp when the game ended.</summary>
    [JsonPropertyName("ended")]
    public required DateTime Ended { get; init; }

    /// <summary>Outcome for this team: "Victory" or "Defeat".</summary>
    [JsonPropertyName("result")]
    public required string Result { get; init; }

    /// <summary>Team color this guild team was assigned to: "Red" or "Blue".</summary>
    [JsonPropertyName("team")]
    public required string Team { get; init; }

    /// <summary>Final score breakdown for both teams.</summary>
    [JsonPropertyName("scores")]
    public required TeamGameScores Scores { get; init; }

    /// <summary>Rating type for this match (e.g., "Rated", "Ranked", "None").</summary>
    [JsonPropertyName("rating_type")]
    public required string RatingType { get; init; }
}

/// <summary>Represents the final score for both teams in a <see cref="TeamGame"/>.</summary>
public record TeamGameScores
{
    /// <summary>Final score of the red team.</summary>
    [JsonPropertyName("red")]
    public required int Red { get; init; }

    /// <summary>Final score of the blue team.</summary>
    [JsonPropertyName("blue")]
    public required int Blue { get; init; }
}

/// <summary>Represents a <see cref="GuildTeam"/>'s rating record for a single PvP season.</summary>
public record TeamSeason
{
    /// <summary>Season ID; resolvable to a <see cref="PvpSeason"/>.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Number of rated games won during this season.</summary>
    [JsonPropertyName("wins")]
    public required int Wins { get; init; }

    /// <summary>Number of rated games lost during this season.</summary>
    [JsonPropertyName("losses")]
    public required int Losses { get; init; }

    /// <summary>Final rating achieved by the team at the end of this season.</summary>
    [JsonPropertyName("rating")]
    public required int Rating { get; init; }
}
