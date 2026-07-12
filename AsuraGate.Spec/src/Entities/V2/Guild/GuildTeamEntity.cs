using SQLite;

namespace AsuraGate.Spec.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildTeam"/>. <c>Aggregate</c> is a fixed
/// 1:1 <c>PvpStatBreakdown</c>, so it's flattened directly onto this row; <c>Ladders</c> (a dictionary of
/// the same shape) gets its own keyed child table below.
/// </summary>
[Table("guild_teams")]
public class GuildTeamEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("state")]
    public string State { get; set; } = string.Empty;

    [NotNull]
    [Column("aggregate_wins")]
    public int AggregateWins { get; set; }

    [NotNull]
    [Column("aggregate_losses")]
    public int AggregateLosses { get; set; }

    [NotNull]
    [Column("aggregate_desertions")]
    public int AggregateDesertions { get; set; }

    [NotNull]
    [Column("aggregate_byes")]
    public int AggregateByes { get; set; }

    [NotNull]
    [Column("aggregate_forfeits")]
    public int AggregateForfeits { get; set; }
}

/// <summary>A guild member on a <see cref="GuildTeamEntity"/>.</summary>
[Table("guild_team_members")]
public class GuildTeamMemberEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_team_id")]
    public int GuildTeamId { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("role")]
    public string Role { get; set; } = string.Empty;
}

/// <summary>Per-ladder win/loss breakdown (dictionary entry) for a <see cref="GuildTeamEntity"/>.</summary>
[Table("guild_team_ladders")]
public class GuildTeamLadderEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_team_id")]
    public int GuildTeamId { get; set; }

    [NotNull]
    [Indexed]
    [Column("ladder")]
    public string Ladder { get; set; } = string.Empty;

    [NotNull]
    [Column("wins")]
    public int Wins { get; set; }

    [NotNull]
    [Column("losses")]
    public int Losses { get; set; }

    [NotNull]
    [Column("desertions")]
    public int Desertions { get; set; }

    [NotNull]
    [Column("byes")]
    public int Byes { get; set; }

    [NotNull]
    [Column("forfeits")]
    public int Forfeits { get; set; }
}

/// <summary>A recent PvP game played by a <see cref="GuildTeamEntity"/>; <c>Scores</c> is flattened (fixed 1:1).</summary>
[Table("guild_team_games")]
public class GuildTeamGameEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("guild_team_id")]
    public int GuildTeamId { get; set; }

    [NotNull]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull]
    [Column("started")]
    public DateTime Started { get; set; }

    [NotNull]
    [Column("ended")]
    public DateTime Ended { get; set; }

    [NotNull]
    [Column("result")]
    public string Result { get; set; } = string.Empty;

    [NotNull]
    [Column("team")]
    public string Team { get; set; } = string.Empty;

    [NotNull]
    [Column("score_red")]
    public int ScoreRed { get; set; }

    [NotNull]
    [Column("score_blue")]
    public int ScoreBlue { get; set; }

    [NotNull]
    [Column("rating_type")]
    public string RatingType { get; set; } = string.Empty;
}

/// <summary>A per-season rating record for a <see cref="GuildTeamEntity"/>.</summary>
[Table("guild_team_seasons")]
public class GuildTeamSeasonEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_team_id")]
    public int GuildTeamId { get; set; }

    [NotNull]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("wins")]
    public int Wins { get; set; }

    [NotNull]
    [Column("losses")]
    public int Losses { get; set; }

    [NotNull]
    [Column("rating")]
    public int Rating { get; set; }
}
