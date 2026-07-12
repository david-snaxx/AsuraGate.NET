using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Title"/>.
/// </summary>
[Table("titles")]
public class TitleEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("achievement")]
    public int? Achievement { get; set; }

    [Column("ap_required")]
    public int? ApRequired { get; set; }
}

/// <summary>Achievement ID that can unlock a <see cref="TitleEntity"/>.</summary>
[Table("title_achievements")]
public class TitleAchievementEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("title_id")]
    public int TitleId { get; set; }

    [NotNull]
    [Column("achievement_id")]
    public int AchievementId { get; set; }
}
