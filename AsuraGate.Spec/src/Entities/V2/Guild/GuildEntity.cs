using SQLite;

namespace AsuraGate.Spec.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.Guild"/>. The emblem is embedded directly
/// (via <see cref="HasEmblem"/> + background/foreground component ids) since it's a fixed 1:1 nested
/// object, not a list; its per-layer color lists get their own child table.
/// </summary>
[Table("guilds")]
public class GuildEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("tag")]
    public string Tag { get; set; } = string.Empty;

    [NotNull]
    [Column("has_emblem")]
    public bool HasEmblem { get; set; }

    [Column("emblem_background_id")]
    public int? EmblemBackgroundId { get; set; }

    [Column("emblem_foreground_id")]
    public int? EmblemForegroundId { get; set; }

    [Column("level")]
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

/// <summary>Behavior flag on a <see cref="GuildEntity"/>'s emblem.</summary>
[Table("guild_emblem_flags")]
public class GuildEmblemFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Dye color applied to one layer of a <see cref="GuildEntity"/>'s emblem.</summary>
[Table("guild_emblem_layer_colors")]
public class GuildEmblemLayerColorEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("is_foreground")]
    public bool IsForeground { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("color_id")]
    public int ColorId { get; set; }
}
