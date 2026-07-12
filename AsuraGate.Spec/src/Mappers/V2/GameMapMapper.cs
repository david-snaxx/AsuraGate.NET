using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class GameMapMapper
{
    public static GameMapEntity ToGameMapEntity(GameMap gameMap) => new GameMapEntity()
    {
        Id = gameMap.Id,
        Name = gameMap.Name,
        MinLevel = gameMap.MinLevel,
        MaxLevel = gameMap.MaxLevel,
        DefaultFloor = gameMap.DefaultFloor,
        Type = gameMap.Type,
        RegionId = gameMap.RegionId,
        RegionName = gameMap.RegionName,
        ContinentId = gameMap.ContinentId,
        ContinentName = gameMap.ContinentName,
        MapRectX1 = gameMap.MapRect[0][0],
        MapRectY1 = gameMap.MapRect[0][1],
        MapRectX2 = gameMap.MapRect[1][0],
        MapRectY2 = gameMap.MapRect[1][1],
        ContinentRectX1 = gameMap.ContinentRect[0][0],
        ContinentRectY1 = gameMap.ContinentRect[0][1],
        ContinentRectX2 = gameMap.ContinentRect[1][0],
        ContinentRectY2 = gameMap.ContinentRect[1][1]
    };

    public static IEnumerable<GameMapFloorEntity> ToFloorEntities(GameMap gameMap) =>
        gameMap.Floors.Select(floorId => new GameMapFloorEntity()
        {
            GameMapId = gameMap.Id,
            FloorId = floorId
        });

    public static GameMap ToModel(GameMapEntity entity, IEnumerable<GameMapFloorEntity> floorEntities) => new GameMap()
    {
        Id = entity.Id,
        Name = entity.Name,
        MinLevel = entity.MinLevel,
        MaxLevel = entity.MaxLevel,
        DefaultFloor = entity.DefaultFloor,
        Type = entity.Type,
        Floors = floorEntities.Select(floor => floor.FloorId).ToArray(),
        RegionId = entity.RegionId,
        RegionName = entity.RegionName,
        ContinentId = entity.ContinentId,
        ContinentName = entity.ContinentName,
        MapRect = [[entity.MapRectX1, entity.MapRectY1], [entity.MapRectX2, entity.MapRectY2]],
        ContinentRect = [[entity.ContinentRectX1, entity.ContinentRectY1], [entity.ContinentRectX2, entity.ContinentRectY2]]
    };
}
