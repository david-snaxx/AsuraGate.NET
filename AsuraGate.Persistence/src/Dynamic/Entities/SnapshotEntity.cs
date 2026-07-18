using SQLite;

namespace AsuraGate.Persistence.Dynamic.Entities;

/// <summary>
/// Base for the append-only snapshot entities. Every snapshot entity is shaped identically
/// (an autoincrementing id, a timestamp, and a JSON <c>data</c> blob) - concrete entities just
/// add <c>[Table("...")]</c>.
/// </summary>
public abstract class SnapshotEntity : ISnapshotEntity
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("timestamp")]
    public DateTime Timestamp { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
