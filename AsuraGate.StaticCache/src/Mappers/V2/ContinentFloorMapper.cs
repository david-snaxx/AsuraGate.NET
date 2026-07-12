using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class ContinentFloorMapper
{
    public static ContinentFloorEntity ToContinentFloorEntity(ContinentFloor floor) => new ContinentFloorEntity()
    {
        Id = floor.Id,
        TextureDimsWidth = floor.TextureDims[0],
        TextureDimsHeight = floor.TextureDims[1],
        ClampedViewX1 = floor.ClampedView?[0][0],
        ClampedViewY1 = floor.ClampedView?[0][1],
        ClampedViewX2 = floor.ClampedView?[1][0],
        ClampedViewY2 = floor.ClampedView?[1][1]
    };

    public static IEnumerable<ContinentFloorRegionEntity> ToRegionEntities(ContinentFloor floor) =>
        floor.Regions.Select(pair => new ContinentFloorRegionEntity()
        {
            FloorId = floor.Id,
            RegionKey = pair.Key,
            RegionId = pair.Value.Id,
            Name = pair.Value.Name,
            LabelCoordX = pair.Value.LabelCoord[0],
            LabelCoordY = pair.Value.LabelCoord[1],
            ContinentRectX1 = pair.Value.ContinentRect[0][0],
            ContinentRectY1 = pair.Value.ContinentRect[0][1],
            ContinentRectX2 = pair.Value.ContinentRect[1][0],
            ContinentRectY2 = pair.Value.ContinentRect[1][1]
        });

    public static IEnumerable<ContinentFloorMapEntity> ToMapEntities(ContinentFloor floor) =>
        floor.Regions.SelectMany(regionPair => regionPair.Value.Maps.Select(mapPair => new ContinentFloorMapEntity()
        {
            FloorId = floor.Id,
            RegionKey = regionPair.Key,
            MapKey = mapPair.Key,
            MapId = mapPair.Value.Id,
            Name = mapPair.Value.Name,
            MinLevel = mapPair.Value.MinLevel,
            MaxLevel = mapPair.Value.MaxLevel,
            DefaultFloor = mapPair.Value.DefaultFloor,
            LabelCoordX = mapPair.Value.LabelCoord[0],
            LabelCoordY = mapPair.Value.LabelCoord[1],
            MapRectX1 = mapPair.Value.MapRect[0][0],
            MapRectY1 = mapPair.Value.MapRect[0][1],
            MapRectX2 = mapPair.Value.MapRect[1][0],
            MapRectY2 = mapPair.Value.MapRect[1][1],
            ContinentRectX1 = mapPair.Value.ContinentRect[0][0],
            ContinentRectY1 = mapPair.Value.ContinentRect[0][1],
            ContinentRectX2 = mapPair.Value.ContinentRect[1][0],
            ContinentRectY2 = mapPair.Value.ContinentRect[1][1]
        }));

    private static IEnumerable<(string MapKey, RegionMap Map)> AllMaps(ContinentFloor floor) =>
        floor.Regions.SelectMany(regionPair => regionPair.Value.Maps.Select(mapPair => (mapPair.Key, mapPair.Value)));

    public static IEnumerable<ContinentFloorGodShrineEntity> ToGodShrineEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.GodShrine.Select(shrine => new ContinentFloorGodShrineEntity()
        {
            MapKey = map.MapKey,
            ShrineId = shrine.Id,
            Name = shrine.Name,
            NameContested = shrine.NameContested,
            CoordX = shrine.Coord[0],
            CoordY = shrine.Coord[1],
            PoiId = shrine.PoiId,
            Icon = shrine.Icon,
            IconContested = shrine.IconContested
        }));

    public static IEnumerable<ContinentFloorPointOfInterestEntity> ToPointOfInterestEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.PointsOfInterest.Select(poiPair => new ContinentFloorPointOfInterestEntity()
        {
            MapKey = map.MapKey,
            PoiKey = poiPair.Key,
            PoiId = poiPair.Value.Id,
            Name = poiPair.Value.Name,
            Type = poiPair.Value.Type,
            Floor = poiPair.Value.Floor,
            CoordX = poiPair.Value.Coord[0],
            CoordY = poiPair.Value.Coord[1],
            ChatLink = poiPair.Value.ChatLink,
            Icon = poiPair.Value.Icon
        }));

    public static IEnumerable<ContinentFloorTaskEntity> ToTaskEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.Tasks.Select(taskPair => new ContinentFloorTaskEntity()
        {
            MapKey = map.MapKey,
            TaskKey = taskPair.Key,
            TaskId = taskPair.Value.Id,
            Objective = taskPair.Value.Objective,
            Level = taskPair.Value.Level,
            CoordX = taskPair.Value.Coord[0],
            CoordY = taskPair.Value.Coord[1],
            ChatLink = taskPair.Value.ChatLink
        }));

    public static IEnumerable<ContinentFloorTaskBoundsPointEntity> ToTaskBoundsPointEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.Tasks.SelectMany(taskPair => taskPair.Value.Bounds.Select((point, index) => new ContinentFloorTaskBoundsPointEntity()
        {
            TaskKey = taskPair.Key,
            OrderIndex = index,
            X = point[0],
            Y = point[1]
        })));

    public static IEnumerable<ContinentFloorSkillChallengeEntity> ToSkillChallengeEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.SkillChallenges.Select((challenge, index) => new ContinentFloorSkillChallengeEntity()
        {
            MapKey = map.MapKey,
            OrderIndex = index,
            ChallengeId = challenge.Id,
            CoordX = challenge.Coord[0],
            CoordY = challenge.Coord[1]
        }));

    public static IEnumerable<ContinentFloorSectorEntity> ToSectorEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.Sectors.Select(sectorPair => new ContinentFloorSectorEntity()
        {
            MapKey = map.MapKey,
            SectorKey = sectorPair.Key,
            SectorId = sectorPair.Value.Id,
            Name = sectorPair.Value.Name,
            Level = sectorPair.Value.Level,
            CoordX = sectorPair.Value.Coord[0],
            CoordY = sectorPair.Value.Coord[1],
            ChatLink = sectorPair.Value.ChatLink
        }));

    public static IEnumerable<ContinentFloorSectorBoundsPointEntity> ToSectorBoundsPointEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.Sectors.SelectMany(sectorPair => sectorPair.Value.Bounds.Select((point, index) => new ContinentFloorSectorBoundsPointEntity()
        {
            SectorKey = sectorPair.Key,
            OrderIndex = index,
            X = point[0],
            Y = point[1]
        })));

    public static IEnumerable<ContinentFloorAdventureEntity> ToAdventureEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.Adventures.Select((adventure, index) => new ContinentFloorAdventureEntity()
        {
            MapKey = map.MapKey,
            OrderIndex = index,
            AdventureId = adventure.Id,
            Name = adventure.Name,
            Description = adventure.Description,
            CoordX = adventure.Coord[0],
            CoordY = adventure.Coord[1]
        }));

    public static IEnumerable<ContinentFloorMasteryPointEntity> ToMasteryPointEntities(ContinentFloor floor) =>
        AllMaps(floor).SelectMany(map => map.Map.MasteryPoints.Select((masteryPoint, index) => new ContinentFloorMasteryPointEntity()
        {
            MapKey = map.MapKey,
            OrderIndex = index,
            MasteryPointId = masteryPoint.Id,
            CoordX = masteryPoint.Coord[0],
            CoordY = masteryPoint.Coord[1],
            Region = masteryPoint.Region
        }));

    public static ContinentFloor ToModel(
        ContinentFloorEntity entity,
        IEnumerable<ContinentFloorRegionEntity> regionEntities,
        IEnumerable<ContinentFloorMapEntity> mapEntities,
        IEnumerable<ContinentFloorGodShrineEntity> godShrineEntities,
        IEnumerable<ContinentFloorPointOfInterestEntity> pointOfInterestEntities,
        IEnumerable<ContinentFloorTaskEntity> taskEntities,
        IEnumerable<ContinentFloorTaskBoundsPointEntity> taskBoundsPointEntities,
        IEnumerable<ContinentFloorSkillChallengeEntity> skillChallengeEntities,
        IEnumerable<ContinentFloorSectorEntity> sectorEntities,
        IEnumerable<ContinentFloorSectorBoundsPointEntity> sectorBoundsPointEntities,
        IEnumerable<ContinentFloorAdventureEntity> adventureEntities,
        IEnumerable<ContinentFloorMasteryPointEntity> masteryPointEntities)
    {
        var maps = mapEntities.ToList();
        var godShrines = godShrineEntities.ToList();
        var pointsOfInterest = pointOfInterestEntities.ToList();
        var tasks = taskEntities.ToList();
        var taskBoundsPoints = taskBoundsPointEntities.ToList();
        var skillChallenges = skillChallengeEntities.ToList();
        var sectors = sectorEntities.ToList();
        var sectorBoundsPoints = sectorBoundsPointEntities.ToList();
        var adventures = adventureEntities.ToList();
        var masteryPoints = masteryPointEntities.ToList();

        RegionMap ToRegionMap(ContinentFloorMapEntity map) => new RegionMap()
        {
            Id = map.MapId,
            Name = map.Name,
            MinLevel = map.MinLevel,
            MaxLevel = map.MaxLevel,
            DefaultFloor = map.DefaultFloor,
            LabelCoord = [map.LabelCoordX, map.LabelCoordY],
            MapRect = [[map.MapRectX1, map.MapRectY1], [map.MapRectX2, map.MapRectY2]],
            ContinentRect = [[map.ContinentRectX1, map.ContinentRectY1], [map.ContinentRectX2, map.ContinentRectY2]],
            GodShrine = godShrines.Where(shrine => shrine.MapKey == map.MapKey).Select(shrine => new GodShrine()
            {
                Id = shrine.ShrineId,
                Name = shrine.Name,
                NameContested = shrine.NameContested,
                Coord = [shrine.CoordX, shrine.CoordY],
                PoiId = shrine.PoiId,
                Icon = shrine.Icon,
                IconContested = shrine.IconContested
            }).ToArray(),
            PointsOfInterest = pointsOfInterest.Where(poi => poi.MapKey == map.MapKey).ToDictionary(poi => poi.PoiKey, poi => new PointOfInterest()
            {
                Id = poi.PoiId,
                Name = poi.Name,
                Type = poi.Type,
                Floor = poi.Floor,
                Coord = [poi.CoordX, poi.CoordY],
                ChatLink = poi.ChatLink,
                Icon = poi.Icon
            }),
            Tasks = tasks.Where(task => task.MapKey == map.MapKey).ToDictionary(task => task.TaskKey, task => new RegionTask()
            {
                Id = task.TaskId,
                Objective = task.Objective,
                Level = task.Level,
                Coord = [task.CoordX, task.CoordY],
                Bounds = taskBoundsPoints
                    .Where(point => point.TaskKey == task.TaskKey)
                    .OrderBy(point => point.OrderIndex)
                    .Select(point => new[] { point.X, point.Y })
                    .ToArray(),
                ChatLink = task.ChatLink
            }),
            SkillChallenges = skillChallenges
                .Where(challenge => challenge.MapKey == map.MapKey)
                .OrderBy(challenge => challenge.OrderIndex)
                .Select(challenge => new SkillChallenge() { Id = challenge.ChallengeId, Coord = [challenge.CoordX, challenge.CoordY] })
                .ToArray(),
            Sectors = sectors.Where(sector => sector.MapKey == map.MapKey).ToDictionary(sector => sector.SectorKey, sector => new MapSector()
            {
                Id = sector.SectorId,
                Name = sector.Name,
                Level = sector.Level,
                Coord = [sector.CoordX, sector.CoordY],
                Bounds = sectorBoundsPoints
                    .Where(point => point.SectorKey == sector.SectorKey)
                    .OrderBy(point => point.OrderIndex)
                    .Select(point => new[] { point.X, point.Y })
                    .ToArray(),
                ChatLink = sector.ChatLink
            }),
            Adventures = adventures
                .Where(adventure => adventure.MapKey == map.MapKey)
                .OrderBy(adventure => adventure.OrderIndex)
                .Select(adventure => new MapAdventure()
                {
                    Id = adventure.AdventureId,
                    Name = adventure.Name,
                    Description = adventure.Description,
                    Coord = [adventure.CoordX, adventure.CoordY]
                }).ToArray(),
            MasteryPoints = masteryPoints
                .Where(masteryPoint => masteryPoint.MapKey == map.MapKey)
                .OrderBy(masteryPoint => masteryPoint.OrderIndex)
                .Select(masteryPoint => new MapMasteryPoint()
                {
                    Id = masteryPoint.MasteryPointId,
                    Coord = [masteryPoint.CoordX, masteryPoint.CoordY],
                    Region = masteryPoint.Region
                }).ToArray()
        };

        return new ContinentFloor()
        {
            Id = entity.Id,
            TextureDims = [entity.TextureDimsWidth, entity.TextureDimsHeight],
            ClampedView = entity.ClampedViewX1 is null
                ? null
                : [[entity.ClampedViewX1.Value, entity.ClampedViewY1!.Value], [entity.ClampedViewX2!.Value, entity.ClampedViewY2!.Value]],
            Regions = regionEntities.ToDictionary(region => region.RegionKey, region => new FloorRegion()
            {
                Id = region.RegionId,
                Name = region.Name,
                LabelCoord = [region.LabelCoordX, region.LabelCoordY],
                ContinentRect = [[region.ContinentRectX1, region.ContinentRectY1], [region.ContinentRectX2, region.ContinentRectY2]],
                Maps = maps.Where(map => map.RegionKey == region.RegionKey).ToDictionary(map => map.MapKey, ToRegionMap)
            })
        };
    }
}
