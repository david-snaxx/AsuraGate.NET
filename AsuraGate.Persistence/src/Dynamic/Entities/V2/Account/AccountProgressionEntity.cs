using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Account;

[Table("account_progressions")]
public class AccountProgressionEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
