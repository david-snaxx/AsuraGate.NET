using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2.Achievements;

[Table("achievement_groups")]
public class AchievementGroupEntity : IIdDataEntity<string>
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
