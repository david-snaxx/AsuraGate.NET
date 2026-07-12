using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Pvp;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpSeason"/>.
/// </summary>
[Table("pvp_seasons")]
public class PvpSeasonEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("start")]
    public string Start { get; set; } = string.Empty;

    [NotNull]
    [Column("end")]
    public string End { get; set; } = string.Empty;

    [NotNull]
    [Column("active")]
    public bool Active { get; set; }
}

/// <summary>A division within a <see cref="PvpSeasonEntity"/>.</summary>
[Table("pvp_season_divisions")]
public class PvpSeasonDivisionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("large_icon")]
    public string LargeIcon { get; set; } = string.Empty;

    [NotNull]
    [Column("small_icon")]
    public string SmallIcon { get; set; } = string.Empty;

    [NotNull]
    [Column("pip_icon")]
    public string PipIcon { get; set; } = string.Empty;
}

/// <summary>Behavior flag on a <see cref="PvpSeasonDivisionEntity"/>. Carries the division's OrderIndex down instead of chaining its surrogate id.</summary>
[Table("pvp_season_division_flags")]
public class PvpSeasonDivisionFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("division_order_index")]
    public int DivisionOrderIndex { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>A pip tier within a <see cref="PvpSeasonDivisionEntity"/>.</summary>
[Table("pvp_season_division_tiers")]
public class PvpSeasonDivisionTierEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("division_order_index")]
    public int DivisionOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("points")]
    public int Points { get; set; }
}

/// <summary>A leaderboard display rank within a <see cref="PvpSeasonEntity"/>.</summary>
[Table("pvp_season_ranks")]
public class PvpSeasonRankEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull]
    [Column("overlay")]
    public string Overlay { get; set; } = string.Empty;

    [NotNull]
    [Column("overlay_small")]
    public string OverlaySmall { get; set; } = string.Empty;
}

/// <summary>A rating tier within a <see cref="PvpSeasonRankEntity"/>.</summary>
[Table("pvp_season_rank_tiers")]
public class PvpSeasonRankTierEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("rank_order_index")]
    public int RankOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("rating")]
    public int Rating { get; set; }
}

/// <summary>
/// A leaderboard configuration slot ("ladder", "guild", or "legendary") within one of a
/// <see cref="PvpSeasonEntity"/>'s <c>Leaderboards</c> entries. <see cref="SlotType"/> works the same
/// way a dictionary key would (there's no dictionary here, just 3 fixed named optional properties on
/// the model, but the storage shape is identical).
/// </summary>
[Table("pvp_season_leaderboard_configs")]
public class PvpSeasonLeaderboardConfigEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("leaderboard_order_index")]
    public int LeaderboardOrderIndex { get; set; }

    [NotNull]
    [Indexed]
    [Column("slot_type")]
    public string SlotType { get; set; } = string.Empty;

    [NotNull]
    [Column("settings_name")]
    public string SettingsName { get; set; } = string.Empty;

    [Column("settings_duration")]
    public int? SettingsDuration { get; set; }

    [NotNull]
    [Column("settings_scoring")]
    public string SettingsScoring { get; set; } = string.Empty;

    [NotNull]
    [Column("scoring_id")]
    public string ScoringId { get; set; } = string.Empty;

    [NotNull]
    [Column("scoring_type")]
    public string ScoringType { get; set; } = string.Empty;

    [NotNull]
    [Column("scoring_description")]
    public string ScoringDescription { get; set; } = string.Empty;

    [NotNull]
    [Column("scoring_name")]
    public string ScoringName { get; set; } = string.Empty;

    [NotNull]
    [Column("scoring_ordering")]
    public string ScoringOrdering { get; set; } = string.Empty;
}

/// <summary>A display tier within a <see cref="PvpSeasonLeaderboardConfigEntity"/>'s settings.</summary>
[Table("pvp_season_leaderboard_config_tiers")]
public class PvpSeasonLeaderboardConfigTierEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("leaderboard_order_index")]
    public int LeaderboardOrderIndex { get; set; }

    [NotNull]
    [Indexed]
    [Column("slot_type")]
    public string SlotType { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("color")]
    public string Color { get; set; } = string.Empty;

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("range_min")]
    public int RangeMin { get; set; }

    [NotNull]
    [Column("range_max")]
    public int RangeMax { get; set; }
}
