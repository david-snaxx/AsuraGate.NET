using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildLogEntry"/>. One table covers all 10 log
/// entry subtypes; only the columns relevant to <see cref="LogType"/> are populated. Log entry ids are only
/// unique within a guild, so this uses a DB-assigned id plus a compound unique index on (guild, log id).
/// </summary>
[Table("guild_log_entries")]
public class GuildLogEntryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_guild_log_entries_guild_id_log_id", Order = 1, Unique = true)]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull]
    [Indexed(Name = "ux_guild_log_entries_guild_id_log_id", Order = 2, Unique = true)]
    [Column("log_id")]
    public int LogId { get; set; } // api "id" value

    [NotNull, Indexed, Column("time")]
    public DateTime Time { get; set; }

    [Column("user")]
    public string? User { get; set; }

    [NotNull, Indexed, Column("log_type")]
    public string LogType { get; set; } = string.Empty; // "joined", "invited", "kick", "rank_change", ...

    [Column("invited_by")]
    public string? InvitedBy { get; set; }

    [Column("kicked_by")]
    public string? KickedBy { get; set; }

    [Column("changed_by")]
    public string? ChangedBy { get; set; }

    [Column("old_rank")]
    public string? OldRank { get; set; }

    [Column("new_rank")]
    public string? NewRank { get; set; }

    // Treasury.ItemId / Stash.ItemId / Upgrade.ItemId
    [Indexed, Column("item_id")]
    public int? ItemId { get; set; }

    // Treasury.Count / Stash.Count / Upgrade.Count
    [Column("count")]
    public int? Count { get; set; }

    // Stash only
    [Column("operation")]
    public string? Operation { get; set; }

    [Column("coins")]
    public int? Coins { get; set; }

    // Motd only
    [Column("motd")]
    public string? Motd { get; set; }

    // Upgrade only
    [Column("action")]
    public string? Action { get; set; }

    [Indexed, Column("upgrade_id")]
    public int? UpgradeId { get; set; } // FK to GuildUpgradeEntity

    [Column("recipe_id")]
    public int? RecipeId { get; set; } // FK to RecipeEntity

    // Influence only
    [Column("activity")]
    public string? Activity { get; set; }

    [Column("total_participants")]
    public int? TotalParticipants { get; set; }

    // Mission only
    [Indexed, Column("state")]
    public string? State { get; set; }

    [Column("mission_influence")]
    public int? MissionInfluence { get; set; }
}

/// <summary>A participant account name on an "influence" <see cref="GuildLogEntryEntity"/>.</summary>
[Table("guild_log_entry_participants")]
public class GuildLogEntryParticipantEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_log_entry_id")]
    public int GuildLogEntryId { get; set; } // FK to GuildLogEntryEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("participant")]
    public string Participant { get; set; } = string.Empty;
}
