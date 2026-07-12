using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class ContinentMapper
{
    public static ContinentEntity ToContinentEntity(Continent continent) => new ContinentEntity()
    {
        Id = continent.Id,
        Name = continent.Name,
        ContinentDimsWidth = continent.ContinentDims[0],
        ContinentDimsHeight = continent.ContinentDims[1],
        MinZoom = continent.MinZoom,
        MaxZoom = continent.MaxZoom
    };

    public static IEnumerable<ContinentFloorIdEntity> ToFloorIdEntities(Continent continent) =>
        continent.Floors.Select(floorId => new ContinentFloorIdEntity()
        {
            ContinentId = continent.Id,
            FloorId = floorId
        });

    public static Continent ToModel(ContinentEntity entity, IEnumerable<ContinentFloorIdEntity> floorIdEntities) => new Continent()
    {
        Id = entity.Id,
        Name = entity.Name,
        ContinentDims = [entity.ContinentDimsWidth, entity.ContinentDimsHeight],
        MinZoom = entity.MinZoom,
        MaxZoom = entity.MaxZoom,
        Floors = floorIdEntities.Select(floor => floor.FloorId).ToArray()
    };
}
