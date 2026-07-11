using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildUpgrade"/> to <see cref="GuildUpgradeEntity"/>.
/// </summary>
public static class GuildUpgradeMapper
{
    public static GuildUpgradeEntity ToEntity(GuildUpgrade upgrade) => new GuildUpgradeEntity()
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
        BagMaxCoins = upgrade.BagMaxCoins,
    };

    public static IReadOnlyList<GuildUpgradePrerequisiteEntity> ToPrerequisiteEntities(GuildUpgrade upgrade) =>
        upgrade.Prerequisites.Select(id => new GuildUpgradePrerequisiteEntity() { GuildUpgradeId = upgrade.Id, PrerequisiteUpgradeId = id }).ToList();

    public static IReadOnlyList<GuildUpgradeCostEntity> ToCostEntities(GuildUpgrade upgrade) =>
        upgrade.Costs.Select((cost, index) => new GuildUpgradeCostEntity()
        {
            GuildUpgradeId = upgrade.Id,
            OrderIndex = index,
            CostType = cost.Type,
            Name = cost.Name,
            Count = cost.Count,
            ItemId = cost.ItemId,
        }).ToList();

    public static UpgradeCost ToCostModel(GuildUpgradeCostEntity entity) => new UpgradeCost()
    {
        Type = entity.CostType,
        Name = entity.Name,
        Count = entity.Count,
        ItemId = entity.ItemId,
    };

    public static GuildUpgrade ToModel(GuildUpgradeEntity entity, IEnumerable<int> prerequisites, IEnumerable<UpgradeCost> costs) => new GuildUpgrade()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Type = entity.Type,
        Icon = entity.Icon,
        BuildTime = entity.BuildTime,
        RequiredLevel = entity.RequiredLevel,
        Experience = entity.Experience,
        Prerequisites = prerequisites.ToArray(),
        Costs = costs.ToArray(),
        BagMaxItems = entity.BagMaxItems,
        BagMaxCoins = entity.BagMaxCoins,
    };
}
