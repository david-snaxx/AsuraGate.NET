using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.AchievementDaily"/>. The model itself has
/// no id (it's "today's daily set" as a whole), so this is the one table for it: every row is one achievement
/// entry in one of the five game-mode buckets for the current day. A repository refreshing this cache should
/// delete and re-insert the full set rather than trying to diff it.
/// </summary>
[Table("achievement_daily_entries")]
public class AchievementDailyEntryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("category")]
    public string Category { get; set; } = string.Empty; // "Pve", "Pvp", "Wvw", "Fractals", "Special"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("achievement_id")]
    public int AchievementId { get; set; } // FK to AchievementEntity

    [NotNull, Column("level_min")]
    public int LevelMin { get; set; }

    [NotNull, Column("level_max")]
    public int LevelMax { get; set; }

    [Column("required_access_product")]
    public string? RequiredAccessProduct { get; set; }

    [Column("required_access_condition")]
    public string? RequiredAccessCondition { get; set; }
}
