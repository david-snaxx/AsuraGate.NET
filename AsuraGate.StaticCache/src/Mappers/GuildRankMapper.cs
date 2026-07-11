using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildRank"/> to <see cref="GuildRankEntity"/>.
/// </summary>
public static class GuildRankMapper
{
    public static GuildRankEntity ToEntity(GuildRank rank, string guildId) => new GuildRankEntity()
    {
        GuildId = guildId,
        RankId = rank.Id,
        Order = rank.Order,
        Icon = rank.Icon,
    };

    public static IReadOnlyList<GuildRankPermissionEntity> ToPermissionEntities(GuildRank rank, int guildRankId) =>
        rank.Permissions.Select(permissionId => new GuildRankPermissionEntity() { GuildRankId = guildRankId, PermissionId = permissionId }).ToList();

    public static GuildRank ToModel(GuildRankEntity entity, IEnumerable<string> permissions) => new GuildRank()
    {
        Id = entity.RankId,
        Order = entity.Order,
        Permissions = permissions.ToArray(),
        Icon = entity.Icon,
    };
}
