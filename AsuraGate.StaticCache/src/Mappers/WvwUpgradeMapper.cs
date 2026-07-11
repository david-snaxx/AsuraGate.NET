using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwUpgrade"/> to <see cref="WvwUpgradeEntity"/>. <see cref="WvwUpgradeTierEntity"/> uses a
/// DB-assigned id (not provided by the API), so <see cref="ToItemEntities"/> takes the already-persisted tier id.
/// </summary>
public static class WvwUpgradeMapper
{
    public static WvwUpgradeEntity ToEntity(WvwUpgrade upgrade) => new WvwUpgradeEntity() { Id = upgrade.Id };

    public static IReadOnlyList<WvwUpgradeTierEntity> ToTierEntities(WvwUpgrade upgrade) =>
        upgrade.Tiers.Select((tier, index) => new WvwUpgradeTierEntity()
        {
            WvwUpgradeId = upgrade.Id,
            OrderIndex = index,
            Name = tier.Name,
            YaksRequired = tier.YaksRequired,
        }).ToList();

    public static IReadOnlyList<WvwUpgradeItemEntity> ToItemEntities(WvwUpgradeTier tier, int wvwUpgradeTierId) =>
        tier.Upgrades.Select((item, index) => new WvwUpgradeItemEntity()
        {
            WvwUpgradeTierId = wvwUpgradeTierId,
            OrderIndex = index,
            Name = item.Name,
            Description = item.Description,
            Icon = item.Icon,
        }).ToList();

    public static WvwUpgradeItem ToItemModel(WvwUpgradeItemEntity entity) => new WvwUpgradeItem()
    {
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
    };

    public static WvwUpgradeTier ToTierModel(WvwUpgradeTierEntity entity, IEnumerable<WvwUpgradeItem> upgrades) => new WvwUpgradeTier()
    {
        Name = entity.Name,
        YaksRequired = entity.YaksRequired,
        Upgrades = upgrades.ToArray(),
    };

    public static WvwUpgrade ToModel(WvwUpgradeEntity entity, IEnumerable<WvwUpgradeTier> tiers) => new WvwUpgrade()
    {
        Id = entity.Id,
        Tiers = tiers.ToArray(),
    };
}
