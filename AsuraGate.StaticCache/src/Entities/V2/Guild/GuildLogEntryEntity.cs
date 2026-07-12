using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildLogEntry"/> - a union of all 10
/// subtypes' fields, the same discriminator-table idea used elsewhere. Unlike Achievement/Item/Skill,
/// this model has no GuildId of its own (the API returns it nested under a specific guild's log), so
/// <see cref="GuildId"/> has no model-side source - callers must supply it separately when persisting.
/// <see cref="LogEntryId"/> holds the model's own Id, which is only unique within one guild's log, so
/// the row's real primary key is a surrogate <see cref="Id"/>.
/// </summary>
[Table("guild_log_entries")]
public class GuildLogEntryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("log_entry_id")]
    public int LogEntryId { get; set; }

    [NotNull]
    [Indexed]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("time")]
    public DateTime Time { get; set; }

    [Column("user")]
    public string? User { get; set; }

    [Column("invited_by")]
    public string? InvitedBy { get; set; } // Invited

    [Column("kicked_by")]
    public string? KickedBy { get; set; } // Kick

    [Column("changed_by")]
    public string? ChangedBy { get; set; } // RankChange

    [Column("old_rank")]
    public string? OldRank { get; set; } // RankChange

    [Column("new_rank")]
    public string? NewRank { get; set; } // RankChange

    [Column("item_id")]
    public int? ItemId { get; set; } // Treasury/Stash/Upgrade

    [Column("count")]
    public int? Count { get; set; } // Treasury/Stash/Upgrade

    [Column("operation")]
    public string? Operation { get; set; } // Stash

    [Column("coins")]
    public int? Coins { get; set; } // Stash

    [Column("motd")]
    public string? Motd { get; set; } // Motd

    [Column("action")]
    public string? Action { get; set; } // Upgrade

    [Column("upgrade_id")]
    public int? UpgradeId { get; set; } // Upgrade

    [Column("recipe_id")]
    public int? RecipeId { get; set; } // Upgrade

    [Column("activity")]
    public string? Activity { get; set; } // Influence

    [Column("total_participants")]
    public int? TotalParticipants { get; set; } // Influence

    [Column("state")]
    public string? State { get; set; } // Mission

    [Column("influence")]
    public int? Influence { get; set; } // Mission
}

/// <summary>A participant account name on a <see cref="GuildLogEntryEntity"/> of type "influence".</summary>
[Table("guild_log_entry_participants")]
public class GuildLogEntryParticipantEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("log_entry_id")]
    public int LogEntryId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("participant")]
    public string Participant { get; set; } = string.Empty;
}
