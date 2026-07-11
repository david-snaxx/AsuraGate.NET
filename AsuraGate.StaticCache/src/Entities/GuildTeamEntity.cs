using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildTeam"/>.
/// </summary>
[Table("guild_teams")]
public class GuildTeamEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Indexed, Column("state")]
    public string State { get; set; } = string.Empty;

    [NotNull, Column("aggregate_wins")] public int AggregateWins { get; set; }
    [NotNull, Column("aggregate_losses")] public int AggregateLosses { get; set; }
    [NotNull, Column("aggregate_desertions")] public int AggregateDesertions { get; set; }
    [NotNull, Column("aggregate_byes")] public int AggregateByes { get; set; }
    [NotNull, Column("aggregate_forfeits")] public int AggregateForfeits { get; set; }
}

/// <summary>A guild member on a <see cref="GuildTeamEntity"/>.</summary>
[Table("guild_team_members")]
public class GuildTeamMemberEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_team_id")]
    public int GuildTeamId { get; set; } // FK to GuildTeamEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("role")]
    public string Role { get; set; } = string.Empty;
}

/// <summary>A per-ladder win/loss breakdown for a <see cref="GuildTeamEntity"/>.</summary>
[Table("guild_team_ladders")]
public class GuildTeamLadderEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed(Name = "ux_guild_team_ladders_team_id_ladder", Order = 1, Unique = true)]
    [Column("guild_team_id")]
    public int GuildTeamId { get; set; } // FK to GuildTeamEntity

    [NotNull]
    [Indexed(Name = "ux_guild_team_ladders_team_id_ladder", Order = 2, Unique = true)]
    [Column("ladder")]
    public string Ladder { get; set; } = string.Empty; // dictionary key

    [NotNull, Column("wins")] public int Wins { get; set; }
    [NotNull, Column("losses")] public int Losses { get; set; }
    [NotNull, Column("desertions")] public int Desertions { get; set; }
    [NotNull, Column("byes")] public int Byes { get; set; }
    [NotNull, Column("forfeits")] public int Forfeits { get; set; }
}

/// <summary>A single PvP game played by a <see cref="GuildTeamEntity"/>.</summary>
[Table("guild_team_games")]
public class GuildTeamGameEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("guild_team_id")]
    public int GuildTeamId { get; set; } // FK to GuildTeamEntity

    [NotNull, Indexed, Column("map_id")]
    public int MapId { get; set; }

    [NotNull, Indexed, Column("started")]
    public DateTime Started { get; set; }

    [NotNull, Column("ended")]
    public DateTime Ended { get; set; }

    [NotNull, Indexed, Column("result")]
    public string Result { get; set; } = string.Empty;

    [NotNull, Column("team")]
    public string Team { get; set; } = string.Empty;

    [NotNull, Column("scores_red")] public int ScoresRed { get; set; }
    [NotNull, Column("scores_blue")] public int ScoresBlue { get; set; }

    [NotNull, Column("rating_type")]
    public string RatingType { get; set; } = string.Empty;
}

/// <summary>A per-season rating record for a <see cref="GuildTeamEntity"/>.</summary>
[Table("guild_team_seasons")]
public class GuildTeamSeasonEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed(Name = "ux_guild_team_seasons_team_id_season_id", Order = 1, Unique = true)]
    [Column("guild_team_id")]
    public int GuildTeamId { get; set; } // FK to GuildTeamEntity

    [NotNull]
    [Indexed(Name = "ux_guild_team_seasons_team_id_season_id", Order = 2, Unique = true)]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty; // FK to PvpSeasonEntity

    [NotNull, Column("wins")] public int Wins { get; set; }
    [NotNull, Column("losses")] public int Losses { get; set; }
    [NotNull, Column("rating")] public int Rating { get; set; }
}
