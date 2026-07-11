using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildRank"/>. Rank ids are only unique within a
/// guild, so this uses a DB-assigned id plus a compound unique index on (guild, rank id).
/// </summary>
[Table("guild_ranks")]
public class GuildRankEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_guild_ranks_guild_id_rank_id", Order = 1, Unique = true)]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty; // FK to GuildEntity

    [NotNull]
    [Indexed(Name = "ux_guild_ranks_guild_id_rank_id", Order = 2, Unique = true)]
    [Column("rank_id")]
    public string RankId { get; set; } = string.Empty; // api "id" value, e.g. "Leader"

    [NotNull, Column("order")]
    public int Order { get; set; }

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>A permission granted to a <see cref="GuildRankEntity"/>.</summary>
[Table("guild_rank_permissions")]
public class GuildRankPermissionEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("guild_rank_id")]
    public int GuildRankId { get; set; } // FK to GuildRankEntity

    [NotNull, Indexed, Column("permission_id")]
    public string PermissionId { get; set; } = string.Empty; // FK to GuildPermissionEntity
}
