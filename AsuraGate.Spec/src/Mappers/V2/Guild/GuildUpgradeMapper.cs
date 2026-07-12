using AsuraGate.Spec.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Spec.Mappers.V2.Guild;

public static class GuildUpgradeMapper
{
    public static GuildUpgradeEntity ToGuildUpgradeEntity(GuildUpgrade upgrade) => new GuildUpgradeEntity()
    {
        Id = upgrade.Id,
        Name = upgrade.Name,
        Description = upgrade.Description,
        Type = upgrade.Type,
        Icon = upgrade.Icon,
        BuildTime = upgrade.BuildTime,
        RequiredLevel = upgrade.RequiredLevel,
        Experience = upgrade.Experience,
        BagMaxItems = upgrade.BagMaxItems,
        BagMaxCoins = upgrade.BagMaxCoins
    };

    public static IEnumerable<GuildUpgradePrerequisiteEntity> ToPrerequisiteEntities(GuildUpgrade upgrade) =>
        upgrade.Prerequisites.Select(prerequisiteId => new GuildUpgradePrerequisiteEntity() { GuildUpgradeId = upgrade.Id, PrerequisiteUpgradeId = prerequisiteId });

    public static IEnumerable<GuildUpgradeCostEntity> ToCostEntities(GuildUpgrade upgrade) =>
        upgrade.Costs.Select((cost, index) => new GuildUpgradeCostEntity()
        {
            GuildUpgradeId = upgrade.Id,
            OrderIndex = index,
            Type = cost.Type,
            Name = cost.Name,
            Count = cost.Count,
            ItemId = cost.ItemId
        });

    public static GuildUpgrade ToModel(
        GuildUpgradeEntity entity,
        IEnumerable<GuildUpgradePrerequisiteEntity> prerequisiteEntities,
        IEnumerable<GuildUpgradeCostEntity> costEntities) => new GuildUpgrade()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Type = entity.Type,
        Icon = entity.Icon,
        BuildTime = entity.BuildTime,
        RequiredLevel = entity.RequiredLevel,
        Experience = entity.Experience,
        Prerequisites = prerequisiteEntities.Select(prerequisite => prerequisite.PrerequisiteUpgradeId).ToArray(),
        Costs = costEntities.OrderBy(cost => cost.OrderIndex).Select(cost => new UpgradeCost()
        {
            Type = cost.Type,
            Name = cost.Name,
            Count = cost.Count,
            ItemId = cost.ItemId
        }).ToArray(),
        BagMaxItems = entity.BagMaxItems,
        BagMaxCoins = entity.BagMaxCoins
    };
}
