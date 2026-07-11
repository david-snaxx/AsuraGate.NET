using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildMember"/>. The model has no id of its own
/// (the account name identifies a member within one guild), so this uses a DB-assigned id plus a compound
/// unique index on (guild, name).
/// </summary>
[Table("guild_members")]
public class GuildMemberEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_guild_members_guild_id_name", Order = 1, Unique = true)]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull]
    [Indexed(Name = "ux_guild_members_guild_id_name", Order = 2, Unique = true)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Indexed, Column("rank")]
    public string Rank { get; set; } = string.Empty;

    [NotNull, Column("joined")]
    public DateTime Joined { get; set; }

    [NotNull, Indexed, Column("wvw_member")]
    public bool WvwMember { get; set; }
}
