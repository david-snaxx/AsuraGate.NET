using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Continent"/> to <see cref="ContinentEntity"/>.
/// </summary>
public static class ContinentMapper
{
    public static ContinentEntity ToEntity(Continent continent) => new ContinentEntity()
    {
        Id = continent.Id,
        Name = continent.Name,
        ContinentDimWidth = continent.ContinentDims.ElementAtOrDefault(0),
        ContinentDimHeight = continent.ContinentDims.ElementAtOrDefault(1),
        MinZoom = continent.MinZoom,
        MaxZoom = continent.MaxZoom,
        // Floors is not persisted; ContinentFloorEntity rows for this continent ARE the floor list.
    };

    public static Continent ToModel(ContinentEntity entity, IEnumerable<int> floorIds) => new Continent()
    {
        Id = entity.Id,
        Name = entity.Name,
        ContinentDims = [entity.ContinentDimWidth, entity.ContinentDimHeight],
        MinZoom = entity.MinZoom,
        MaxZoom = entity.MaxZoom,
        Floors = floorIds.ToArray(),
    };
}
