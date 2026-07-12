using SQLite;

namespace AsuraGate.Spec.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.Account"/>. <c>Wvw</c> is a fixed 1:1
/// optional object, flattened onto this row.
/// </summary>
[Table("accounts")]
public class AccountEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("age")]
    public int Age { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("world")]
    public int World { get; set; }

    [NotNull]
    [Column("created")]
    public DateTime Created { get; set; }

    [NotNull]
    [Column("commander")]
    public bool Commander { get; set; }

    [Column("fractal_level")]
    public int? FractalLevel { get; set; }

    [Column("daily_ap")]
    public int? DailyAp { get; set; }

    [Column("monthly_ap")]
    public int? MonthlyAp { get; set; }

    [Column("wvw_rank")]
    public int? WvwRank { get; set; }

    [Column("wvw_team_id")]
    public int? WvwTeamId { get; set; }

    [Column("wvw_team_rank")]
    public int? WvwTeamRank { get; set; }

    [NotNull]
    [Column("last_modified")]
    public DateTime LastModified { get; set; }

    [Column("build_storage_slots")]
    public int? BuildStorageSlots { get; set; }
}

/// <summary>
/// A guild ID an <see cref="AccountEntity"/> belongs to. <c>GuildLeader</c> is a subset of <c>Guilds</c>
/// on the model (not a separate exclusive list) - a leader guild sets both <see cref="IsMember"/> and
/// <see cref="IsLeader"/> true on the same row, rather than one row per list.
/// </summary>
[Table("account_guilds")]
public class AccountGuildEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("is_member")]
    public bool IsMember { get; set; }

    [NotNull]
    [Column("is_leader")]
    public bool IsLeader { get; set; }
}

/// <summary>An expansion access flag on an <see cref="AccountEntity"/>.</summary>
[Table("account_access")]
public class AccountAccessEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("access")]
    public string Access { get; set; } = string.Empty;
}
