using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Title"/>.
/// </summary>
[Table("titles")]
public class TitleEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [Indexed, Column("achievement")]
    public int? Achievement { get; set; }

    [Indexed, Column("ap_required")]
    public int? ApRequired { get; set; }
}

/// <summary>Achievements that can unlock a <see cref="TitleEntity"/>.</summary>
[Table("title_achievements")]
public class TitleAchievementEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("title_id")]
    public int TitleId { get; set; } // FK to TitleEntity

    [NotNull, Indexed, Column("achievement_id")]
    public int AchievementId { get; set; } // FK to AchievementEntity
}
