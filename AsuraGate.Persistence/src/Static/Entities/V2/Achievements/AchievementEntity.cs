using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Achievements;

[Table("achievements")]
public class AchievementEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
