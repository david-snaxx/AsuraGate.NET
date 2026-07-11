using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.Guild"/>. Most fields beyond identity are only
/// populated with a guild-scoped token and are nullable to reflect that.
/// </summary>
[Table("guilds")]
public class GuildEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Indexed, Column("tag")]
    public string Tag { get; set; } = string.Empty;

    // Emblem is optional as a whole; EmblemBackgroundId null means no emblem is set.
    [Indexed, Column("emblem_background_id")]
    public int? EmblemBackgroundId { get; set; } // FK to EmblemComponentEntity

    [Indexed, Column("emblem_foreground_id")]
    public int? EmblemForegroundId { get; set; } // FK to EmblemComponentEntity

    [Indexed, Column("level")]
    public int? Level { get; set; }

    [Column("motd")]
    public string? Motd { get; set; }

    [Column("influence")]
    public int? Influence { get; set; }

    [Column("aetherium")]
    public int? Aetherium { get; set; }

    [Column("favor")]
    public int? Favor { get; set; }

    [Column("resonance")]
    public int? Resonance { get; set; }

    [Column("member_count")]
    public int? MemberCount { get; set; }

    [Column("member_capacity")]
    public int? MemberCapacity { get; set; }
}

/// <summary>A transformation flag on a <see cref="GuildEntity"/>'s emblem (e.g. "FlipBackgroundHorizontal").</summary>
[Table("guild_emblem_flags")]
public class GuildEmblemFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>A dye color applied to one channel of a <see cref="GuildEntity"/>'s emblem layer.</summary>
[Table("guild_emblem_colors")]
public class GuildEmblemColorEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull, Indexed, Column("layer")]
    public string Layer { get; set; } = string.Empty; // "Background" or "Foreground"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("dye_id")]
    public int DyeId { get; set; } // FK to DyeEntity
}
