using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2.Achievements;

[Table("achievements")]
public class AchievementEntity : IIdDataEntity<int>
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
