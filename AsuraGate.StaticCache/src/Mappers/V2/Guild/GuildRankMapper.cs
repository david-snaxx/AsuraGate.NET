using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities.V2.Guild;

namespace AsuraGate.StaticCache.Mappers.V2.Guild;

public static class GuildRankMapper
{
    public static GuildRankEntity ToEntity(string guildId, GuildRank rank) => new GuildRankEntity()
    {
        GuildId = guildId,
        RankId = rank.Id,
        Order = rank.Order,
        Icon = rank.Icon
    };

    public static IEnumerable<GuildRankPermissionEntity> ToPermissionEntities(string guildId, GuildRank rank) =>
        rank.Permissions.Select(permissionId => new GuildRankPermissionEntity() { GuildId = guildId, RankId = rank.Id, PermissionId = permissionId });

    public static GuildRank ToModel(GuildRankEntity entity, IEnumerable<GuildRankPermissionEntity> permissionEntities) => new GuildRank()
    {
        Id = entity.RankId,
        Order = entity.Order,
        Permissions = permissionEntities.Select(permission => permission.PermissionId).ToArray(),
        Icon = entity.Icon
    };
}
