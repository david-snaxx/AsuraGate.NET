using SQLite;

namespace AsuraGate.Spec.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountWizardsVaultDaily"/> - a
/// singleton per account (no id on the model), PK is <see cref="AccountId"/> directly.
/// </summary>
[Table("account_wizards_vault_dailies")]
public class AccountWizardsVaultDailyEntity
{
    [PrimaryKey]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("meta_progress_current")]
    public int MetaProgressCurrent { get; set; }

    [NotNull]
    [Column("meta_progress_complete")]
    public int MetaProgressComplete { get; set; }

    [NotNull]
    [Column("meta_reward_item_id")]
    public int MetaRewardItemId { get; set; }

    [NotNull]
    [Column("meta_reward_astral")]
    public int MetaRewardAstral { get; set; }

    [NotNull]
    [Column("meta_reward_claimed")]
    public bool MetaRewardClaimed { get; set; }
}
