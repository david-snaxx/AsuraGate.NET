using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildMember"/>. Like other guild-scoped
/// models, the model itself has no GuildId - callers must supply it when persisting.
/// </summary>
[Table("guild_members")]
public class GuildMemberEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("rank")]
    public string Rank { get; set; } = string.Empty;

    [NotNull]
    [Column("joined")]
    public DateTime Joined { get; set; }

    [NotNull]
    [Column("wvw_member")]
    public bool WvwMember { get; set; }
}
