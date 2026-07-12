using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountMaterial"/>. Callers must supply
/// <see cref="AccountId"/> - not on the model.
/// </summary>
[Table("account_materials")]
public class AccountMaterialEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Indexed]
    [Column("category")]
    public int Category { get; set; }

    [Column("binding")]
    public string? Binding { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }
}
