using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountMastery"/>. Callers must supply
/// <see cref="AccountId"/> - not on the model.
/// </summary>
[Table("account_masteries")]
public class AccountMasteryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("mastery_id")]
    public int MasteryId { get; set; }

    [NotNull]
    [Column("level")]
    public int Level { get; set; }
}
