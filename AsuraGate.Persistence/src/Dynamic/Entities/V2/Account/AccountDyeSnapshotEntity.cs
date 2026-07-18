using SQLite;

namespace AsuraGate.Persistence.Dynamic.Entities.V2.Account;

[Table("account_dye_snapshots")]
public class AccountDyeSnapshotEntity : ISnapshotEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("timestamp")]
    public DateTime Timestamp { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
