using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildRank"/>. Guild-scoped, no GuildId on
/// the model - callers must supply it. Rank names (<see cref="RankId"/>) are only unique within a guild.
/// </summary>
[Table("guild_ranks")]
public class GuildRankEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("guild_id")]
    public string GuildId { get; set; } = string.Empty;

    [NotNull]
    [Column("rank_id")]
    public string RankId { get; set; } = string.Empty;

    [NotNull]
    [Column("order")]
    public int Order { get; set; }

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>Permission ID granted to a <see cref="GuildRankEntity"/>.</summary>
[Table("guild_rank_permissions")]
public class GuildRankPermissionEntity
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
    [Column("rank_id")]
    public string RankId { get; set; } = string.Empty;

    [NotNull]
    [Column("permission_id")]
    public string PermissionId { get; set; } = string.Empty;
}
