using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountWvwDetails"/> - a singleton per
/// account (no id on the model), PK is <see cref="AccountId"/> directly. Distinct from the smaller
/// <c>AccountWvw</c> record embedded in <c>Account.Wvw</c> (which lacks <c>Rating</c>) - these are two
/// separate model types despite the similar name and purpose.
/// </summary>
[Table("account_wvw_details")]
public class AccountWvwDetailsEntity
{
    [PrimaryKey]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("team_id")]
    public int TeamId { get; set; }

    [NotNull]
    [Column("rank")]
    public int Rank { get; set; }

    [Column("rating")]
    public int? Rating { get; set; }
}
