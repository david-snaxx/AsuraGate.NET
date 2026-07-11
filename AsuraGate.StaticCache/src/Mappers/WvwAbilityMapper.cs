using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwAbility"/> to <see cref="WvwAbilityEntity"/>.
/// </summary>
public static class WvwAbilityMapper
{
    public static WvwAbilityEntity ToEntity(WvwAbility ability) => new WvwAbilityEntity()
    {
        Id = ability.Id,
        Name = ability.Name,
        Description = ability.Description,
        Icon = ability.Icon,
    };

    public static IReadOnlyList<WvwAbilityRankEntity> ToRankEntities(WvwAbility ability) =>
        ability.Ranks.Select((rank, index) => new WvwAbilityRankEntity() { WvwAbilityId = ability.Id, OrderIndex = index, Cost = rank.Cost, Effect = rank.Effect }).ToList();

    public static WvwAbilityRank ToRankModel(WvwAbilityRankEntity entity) => new WvwAbilityRank() { Cost = entity.Cost, Effect = entity.Effect };

    public static WvwAbility ToModel(WvwAbilityEntity entity, IEnumerable<WvwAbilityRankEntity> ranks) => new WvwAbility()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Ranks = ranks.OrderBy(r => r.OrderIndex).Select(ToRankModel).ToArray(),
    };
}
