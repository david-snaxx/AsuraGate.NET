using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;

namespace AsuraGate.StaticCache.Mappers.V2.Wvw;

public static class WvwAbilityMapper
{
    public static WvwAbilityEntity ToWvwAbilityEntity(WvwAbility ability) => new WvwAbilityEntity()
    {
        Id = ability.Id,
        Name = ability.Name,
        Description = ability.Description,
        Icon = ability.Icon
    };

    public static IEnumerable<WvwAbilityRankEntity> ToRankEntities(WvwAbility ability) =>
        ability.Ranks.Select((rank, index) => new WvwAbilityRankEntity()
        {
            WvwAbilityId = ability.Id,
            OrderIndex = index,
            Cost = rank.Cost,
            Effect = rank.Effect
        });

    public static WvwAbility ToModel(WvwAbilityEntity entity, IEnumerable<WvwAbilityRankEntity> rankEntities) => new WvwAbility()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Ranks = rankEntities.OrderBy(rank => rank.OrderIndex).Select(rank => new WvwAbilityRank() { Cost = rank.Cost, Effect = rank.Effect }).ToArray()
    };
}
