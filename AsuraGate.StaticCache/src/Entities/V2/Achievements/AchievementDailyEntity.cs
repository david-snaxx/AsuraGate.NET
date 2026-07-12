using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Achievements;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.AchievementDaily"/> - a singleton
/// (today's dailies, no Id on the model), so this row uses a fixed constant primary key.
/// </summary>
[Table("achievement_dailies")]
public class AchievementDailyEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; } = 1;
}

/// <summary>A single daily achievement entry; <see cref="Mode"/> is "pve"/"pvp"/"wvw"/"fractals"/"special".</summary>
[Table("achievement_daily_entries")]
public class AchievementDailyEntryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("mode")]
    public string Mode { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("achievement_id")]
    public int AchievementId { get; set; }

    [NotNull]
    [Column("level_min")]
    public int LevelMin { get; set; }

    [NotNull]
    [Column("level_max")]
    public int LevelMax { get; set; }

    [Column("required_access_product")]
    public string? RequiredAccessProduct { get; set; }

    [Column("required_access_condition")]
    public string? RequiredAccessCondition { get; set; }
}
