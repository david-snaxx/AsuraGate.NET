using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;

namespace AsuraGate.StaticCache.Mappers.V2.Wvw;

public static class WvwUpgradeMapper
{
    public static WvwUpgradeEntity ToWvwUpgradeEntity(WvwUpgrade upgrade) => new WvwUpgradeEntity()
    {
        Id = upgrade.Id
    };

    public static IEnumerable<WvwUpgradeTierEntity> ToTierEntities(WvwUpgrade upgrade) =>
        upgrade.Tiers.Select((tier, index) => new WvwUpgradeTierEntity()
        {
            WvwUpgradeId = upgrade.Id,
            OrderIndex = index,
            Name = tier.Name,
            YaksRequired = tier.YaksRequired
        });

    public static IEnumerable<WvwUpgradeItemEntity> ToItemEntities(WvwUpgrade upgrade) =>
        upgrade.Tiers.SelectMany((tier, tierIndex) => tier.Upgrades.Select((item, itemIndex) => new WvwUpgradeItemEntity()
        {
            WvwUpgradeId = upgrade.Id,
            TierOrderIndex = tierIndex,
            OrderIndex = itemIndex,
            Name = item.Name,
            Description = item.Description,
            Icon = item.Icon
        }));

    public static WvwUpgrade ToModel(WvwUpgradeEntity entity, IEnumerable<WvwUpgradeTierEntity> tierEntities, IEnumerable<WvwUpgradeItemEntity> itemEntities)
    {
        var items = itemEntities.ToList();

        return new WvwUpgrade()
        {
            Id = entity.Id,
            Tiers = tierEntities.OrderBy(tier => tier.OrderIndex).Select(tier => new WvwUpgradeTier()
            {
                Name = tier.Name,
                YaksRequired = tier.YaksRequired,
                Upgrades = items
                    .Where(item => item.TierOrderIndex == tier.OrderIndex)
                    .OrderBy(item => item.OrderIndex)
                    .Select(item => new WvwUpgradeItem() { Name = item.Name, Description = item.Description, Icon = item.Icon })
                    .ToArray()
            }).ToArray()
        };
    }
}
