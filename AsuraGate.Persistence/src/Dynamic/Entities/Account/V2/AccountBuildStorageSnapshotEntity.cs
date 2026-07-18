using SQLite;

namespace AsuraGate.Persistence.Dynamic.Entities.Account.V2;

[Table("account_build_storage_snapshots")]
public class AccountBuildStorageSnapshotEntity : ISnapshotEntity
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
