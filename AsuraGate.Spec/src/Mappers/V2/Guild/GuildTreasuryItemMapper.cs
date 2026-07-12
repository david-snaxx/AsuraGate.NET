using AsuraGate.Spec.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Spec.Mappers.V2.Guild;

public static class GuildTreasuryItemMapper
{
    public static GuildTreasuryItemEntity ToEntity(string guildId, GuildTreasuryItem item) => new GuildTreasuryItemEntity()
    {
        GuildId = guildId,
        ItemId = item.ItemId,
        Count = item.Count
    };

    public static IEnumerable<GuildTreasuryItemNeedEntity> ToNeedEntities(string guildId, GuildTreasuryItem item) =>
        item.NeededBy.Select(need => new GuildTreasuryItemNeedEntity()
        {
            GuildId = guildId,
            ItemId = item.ItemId,
            UpgradeId = need.UpgradeId,
            Count = need.Count
        });

    public static GuildTreasuryItem ToModel(GuildTreasuryItemEntity entity, IEnumerable<GuildTreasuryItemNeedEntity> needEntities) => new GuildTreasuryItem()
    {
        ItemId = entity.ItemId,
        Count = entity.Count,
        NeededBy = needEntities.Select(need => new UpgradeNeed() { UpgradeId = need.UpgradeId, Count = need.Count }).ToArray()
    };
}
