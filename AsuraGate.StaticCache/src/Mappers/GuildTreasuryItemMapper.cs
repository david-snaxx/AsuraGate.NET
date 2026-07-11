using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildTreasuryItem"/> to <see cref="GuildTreasuryItemEntity"/>. Uses a DB-assigned id (not
/// provided by the API), so <see cref="ToNeedEntities"/> takes the already-persisted item row id.
/// </summary>
public static class GuildTreasuryItemMapper
{
    public static GuildTreasuryItemEntity ToEntity(GuildTreasuryItem item, string guildId) => new GuildTreasuryItemEntity()
    {
        GuildId = guildId,
        ItemId = item.ItemId,
        Count = item.Count,
    };

    public static IReadOnlyList<GuildTreasuryItemNeedEntity> ToNeedEntities(GuildTreasuryItem item, int guildTreasuryItemId) =>
        item.NeededBy.Select(need => new GuildTreasuryItemNeedEntity() { GuildTreasuryItemId = guildTreasuryItemId, UpgradeId = need.UpgradeId, Count = need.Count }).ToList();

    public static UpgradeNeed ToNeedModel(GuildTreasuryItemNeedEntity entity) => new UpgradeNeed() { UpgradeId = entity.UpgradeId, Count = entity.Count };

    public static GuildTreasuryItem ToModel(GuildTreasuryItemEntity entity, IEnumerable<UpgradeNeed> neededBy) => new GuildTreasuryItem()
    {
        ItemId = entity.ItemId,
        Count = entity.Count,
        NeededBy = neededBy.ToArray(),
    };
}
