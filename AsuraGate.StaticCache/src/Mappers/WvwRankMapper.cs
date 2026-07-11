using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwRank"/> to <see cref="WvwRankEntity"/>.
/// </summary>
public static class WvwRankMapper
{
    public static WvwRankEntity ToEntity(WvwRank rank) => new WvwRankEntity()
    {
        Id = rank.Id,
        Title = rank.Title,
        MinRank = rank.MinRank,
    };

    public static WvwRank ToModel(WvwRankEntity entity) => new WvwRank()
    {
        Id = entity.Id,
        Title = entity.Title,
        MinRank = entity.MinRank,
    };
}
