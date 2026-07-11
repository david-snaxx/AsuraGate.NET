using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpSeason"/>.
/// </summary>
[Table("pvp_seasons")]
public class PvpSeasonEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("start")]
    public string Start { get; set; } = string.Empty;

    [NotNull, Column("end")]
    public string End { get; set; } = string.Empty;

    [NotNull, Indexed, Column("active")]
    public bool Active { get; set; }
}

/// <summary>A division within a <see cref="PvpSeasonEntity"/>.</summary>
[Table("pvp_season_divisions")]
public class PvpSeasonDivisionEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("season_id")]
    public string SeasonId { get; set; } = string.Empty; // FK to PvpSeasonEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("large_icon")]
    public string LargeIcon { get; set; } = string.Empty;

    [NotNull, Column("small_icon")]
    public string SmallIcon { get; set; } = string.Empty;

    [NotNull, Column("pip_icon")]
    public string PipIcon { get; set; } = string.Empty;
}

/// <summary>A behavior flag on a <see cref="PvpSeasonDivisionEntity"/> (e.g. "Repeatable").</summary>
[Table("pvp_season_division_flags")]
public class PvpSeasonDivisionFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("division_id")]
    public int DivisionId { get; set; } // FK to PvpSeasonDivisionEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>A tier within a <see cref="PvpSeasonDivisionEntity"/>.</summary>
[Table("pvp_season_division_tiers")]
public class PvpSeasonDivisionTierEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("division_id")]
    public int DivisionId { get; set; } // FK to PvpSeasonDivisionEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("points")]
    public int Points { get; set; }
}

/// <summary>A leaderboard rank display entry within a <see cref="PvpSeasonEntity"/>.</summary>
[Table("pvp_season_ranks")]
public class PvpSeasonRankEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("season_id")]
    public string SeasonId { get; set; } = string.Empty; // FK to PvpSeasonEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Column("overlay")]
    public string Overlay { get; set; } = string.Empty;

    [NotNull, Column("overlay_small")]
    public string OverlaySmall { get; set; } = string.Empty;
}

/// <summary>A rating threshold tier within a <see cref="PvpSeasonRankEntity"/>.</summary>
[Table("pvp_season_rank_tiers")]
public class PvpSeasonRankTierEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("season_rank_id")]
    public int SeasonRankId { get; set; } // FK to PvpSeasonRankEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("rating")]
    public int Rating { get; set; }
}

/// <summary>One of a <see cref="PvpSeasonEntity"/>'s (up to) three leaderboard configurations: ladder, guild, or legendary.</summary>
[Table("pvp_season_leaderboards")]
public class PvpSeasonLeaderboardEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed(Name = "ux_pvp_season_leaderboards_season_id_slot", Order = 1, Unique = true)]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty; // FK to PvpSeasonEntity

    [NotNull]
    [Indexed(Name = "ux_pvp_season_leaderboards_season_id_slot", Order = 2, Unique = true)]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty; // "Ladder", "Guild", or "Legendary"

    [NotNull, Column("settings_name")]
    public string SettingsName { get; set; } = string.Empty;

    [Column("settings_duration")]
    public int? SettingsDuration { get; set; }

    [NotNull, Column("settings_scoring")]
    public string SettingsScoring { get; set; } = string.Empty;

    [NotNull, Indexed, Column("scorings_id")]
    public string ScoringsId { get; set; } = string.Empty;

    [NotNull, Column("scorings_type")]
    public string ScoringsType { get; set; } = string.Empty;

    [NotNull, Column("scorings_description")]
    public string ScoringsDescription { get; set; } = string.Empty;

    [NotNull, Column("scorings_name")]
    public string ScoringsName { get; set; } = string.Empty;

    [NotNull, Column("scorings_ordering")]
    public string ScoringsOrdering { get; set; } = string.Empty;
}

/// <summary>A display tier within a <see cref="PvpSeasonLeaderboardEntity"/>'s settings.</summary>
[Table("pvp_season_leaderboard_tiers")]
public class PvpSeasonLeaderboardTierEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("leaderboard_id")]
    public int LeaderboardId { get; set; } // FK to PvpSeasonLeaderboardEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("color")]
    public string Color { get; set; } = string.Empty;

    [NotNull, Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("range_min")] public int RangeMin { get; set; }
    [NotNull, Column("range_max")] public int RangeMax { get; set; }
}
