using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;

namespace AsuraGate.StaticCache.Mappers.V2.Wvw;

public static class WvwRankMapper
{
    public static WvwRankEntity ToWvwRankEntity(WvwRank rank) => new WvwRankEntity()
    {
        Id = rank.Id,
        Title = rank.Title,
        MinRank = rank.MinRank
    };

    public static WvwRank ToModel(WvwRankEntity entity) => new WvwRank()
    {
        Id = entity.Id,
        Title = entity.Title,
        MinRank = entity.MinRank
    };
}
