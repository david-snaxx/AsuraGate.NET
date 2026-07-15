using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Achievements;

[Table("achievement_groups")]
public class AchievementGroupEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
