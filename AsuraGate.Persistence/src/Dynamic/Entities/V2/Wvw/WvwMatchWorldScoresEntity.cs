using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Wvw;

[Table("wvw_match_world_scores")]
public class WvwMatchWorldScoresEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
