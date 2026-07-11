using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GameMap"/> to <see cref="GameMapEntity"/>.
/// </summary>
public static class GameMapMapper
{
    public static GameMapEntity ToEntity(GameMap map) => new GameMapEntity()
    {
        Id = map.Id,
        Name = map.Name,
        MinLevel = map.MinLevel,
        MaxLevel = map.MaxLevel,
        DefaultFloor = map.DefaultFloor,
        Type = map.Type,
        RegionId = map.RegionId,
        RegionName = map.RegionName,
        ContinentId = map.ContinentId,
        ContinentName = map.ContinentName,
        MapRectX1 = map.MapRect.ElementAtOrDefault(0)?.ElementAtOrDefault(0) ?? 0,
        MapRectY1 = map.MapRect.ElementAtOrDefault(0)?.ElementAtOrDefault(1) ?? 0,
        MapRectX2 = map.MapRect.ElementAtOrDefault(1)?.ElementAtOrDefault(0) ?? 0,
        MapRectY2 = map.MapRect.ElementAtOrDefault(1)?.ElementAtOrDefault(1) ?? 0,
        ContinentRectX1 = map.ContinentRect.ElementAtOrDefault(0)?.ElementAtOrDefault(0) ?? 0,
        ContinentRectY1 = map.ContinentRect.ElementAtOrDefault(0)?.ElementAtOrDefault(1) ?? 0,
        ContinentRectX2 = map.ContinentRect.ElementAtOrDefault(1)?.ElementAtOrDefault(0) ?? 0,
        ContinentRectY2 = map.ContinentRect.ElementAtOrDefault(1)?.ElementAtOrDefault(1) ?? 0,
    };

    public static IReadOnlyList<GameMapFloorEntity> ToFloorEntities(GameMap map) =>
        map.Floors.Select(floor => new GameMapFloorEntity() { GameMapId = map.Id, Floor = floor }).ToList();

    public static GameMap ToModel(GameMapEntity entity, IEnumerable<int> floors) => new GameMap()
    {
        Id = entity.Id,
        Name = entity.Name,
        MinLevel = entity.MinLevel,
        MaxLevel = entity.MaxLevel,
        DefaultFloor = entity.DefaultFloor,
        Type = entity.Type,
        Floors = floors.ToArray(),
        RegionId = entity.RegionId,
        RegionName = entity.RegionName,
        ContinentId = entity.ContinentId,
        ContinentName = entity.ContinentName,
        MapRect = [[entity.MapRectX1, entity.MapRectY1], [entity.MapRectX2, entity.MapRectY2]],
        ContinentRect = [[entity.ContinentRectX1, entity.ContinentRectY1], [entity.ContinentRectX2, entity.ContinentRectY2]],
    };
}
