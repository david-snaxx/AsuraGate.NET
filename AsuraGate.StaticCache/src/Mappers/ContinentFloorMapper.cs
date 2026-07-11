using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="ContinentFloor"/> (and its nested regions/maps/points-of-interest/etc.) to and from their
/// SQLite entities. <see cref="ContinentFloorEntity"/> and its children use a DB-assigned <c>id</c> (not
/// provided by the API) wherever the API doesn't already hand us a globally-unique id, so every "ToXEntities"
/// method here takes the already-persisted parent id as a parameter — callers must insert the parent first,
/// then map+insert its children with the id SQLite assigned.
/// </summary>
public static class ContinentFloorMapper
{
    public static ContinentFloorEntity ToEntity(ContinentFloor continentFloor, int continentId) => new ContinentFloorEntity()
    {
        FloorId = continentFloor.Id,
        ContinentId = continentId,
        TextureDimWidth = continentFloor.TextureDims.ElementAtOrDefault(0),
        TextureDimHeight = continentFloor.TextureDims.ElementAtOrDefault(1),
        ClampedViewX1 = continentFloor.ClampedView?[0][0],
        ClampedViewY1 = continentFloor.ClampedView?[0][1],
        ClampedViewX2 = continentFloor.ClampedView?[1][0],
        ClampedViewY2 = continentFloor.ClampedView?[1][1],
    };

    public static ContinentFloor ToModel(ContinentFloorEntity entity, IEnumerable<FloorRegion> regions) => new ContinentFloor()
    {
        Id = entity.FloorId,
        TextureDims = [entity.TextureDimWidth, entity.TextureDimHeight],
        ClampedView = entity.ClampedViewX1 is null
            ? null
            : [[entity.ClampedViewX1!.Value, entity.ClampedViewY1!.Value], [entity.ClampedViewX2!.Value, entity.ClampedViewY2!.Value]],
        Regions = regions.ToDictionary(r => r.Id.ToString(), r => r),
    };

    public static ContinentFloorRegionEntity ToRegionEntity(FloorRegion region, int continentFloorId) => new ContinentFloorRegionEntity()
    {
        Id = region.Id,
        ContinentFloorId = continentFloorId,
        Name = region.Name ?? string.Empty,
        LabelCoordX = region.LabelCoord.ElementAtOrDefault(0),
        LabelCoordY = region.LabelCoord.ElementAtOrDefault(1),
        ContinentRectX1 = region.ContinentRect.ElementAtOrDefault(0)?.ElementAtOrDefault(0) ?? 0,
        ContinentRectY1 = region.ContinentRect.ElementAtOrDefault(0)?.ElementAtOrDefault(1) ?? 0,
        ContinentRectX2 = region.ContinentRect.ElementAtOrDefault(1)?.ElementAtOrDefault(0) ?? 0,
        ContinentRectY2 = region.ContinentRect.ElementAtOrDefault(1)?.ElementAtOrDefault(1) ?? 0,
    };

    public static FloorRegion ToRegionModel(ContinentFloorRegionEntity entity, IEnumerable<RegionMap> maps) => new FloorRegion()
    {
        Id = entity.Id,
        Name = string.IsNullOrEmpty(entity.Name) ? null : entity.Name,
        LabelCoord = [entity.LabelCoordX, entity.LabelCoordY],
        ContinentRect = [[entity.ContinentRectX1, entity.ContinentRectY1], [entity.ContinentRectX2, entity.ContinentRectY2]],
        Maps = maps.ToDictionary(m => m.Id.ToString(), m => m),
    };

    public static ContinentFloorRegionMapEntity ToMapEntity(RegionMap map, int regionId) => new ContinentFloorRegionMapEntity()
    {
        Id = map.Id,
        RegionId = regionId,
        Name = map.Name,
        MinLevel = map.MinLevel,
        MaxLevel = map.MaxLevel,
        DefaultFloor = map.DefaultFloor,
        LabelCoordX = map.LabelCoord.ElementAtOrDefault(0),
        LabelCoordY = map.LabelCoord.ElementAtOrDefault(1),
        MapRectX1 = map.MapRect.ElementAtOrDefault(0)?.ElementAtOrDefault(0) ?? 0,
        MapRectY1 = map.MapRect.ElementAtOrDefault(0)?.ElementAtOrDefault(1) ?? 0,
        MapRectX2 = map.MapRect.ElementAtOrDefault(1)?.ElementAtOrDefault(0) ?? 0,
        MapRectY2 = map.MapRect.ElementAtOrDefault(1)?.ElementAtOrDefault(1) ?? 0,
        ContinentRectX1 = map.ContinentRect.ElementAtOrDefault(0)?.ElementAtOrDefault(0) ?? 0,
        ContinentRectY1 = map.ContinentRect.ElementAtOrDefault(0)?.ElementAtOrDefault(1) ?? 0,
        ContinentRectX2 = map.ContinentRect.ElementAtOrDefault(1)?.ElementAtOrDefault(0) ?? 0,
        ContinentRectY2 = map.ContinentRect.ElementAtOrDefault(1)?.ElementAtOrDefault(1) ?? 0,
    };

    public static RegionMap ToMapModel(
        ContinentFloorRegionMapEntity entity,
        IEnumerable<GodShrine> godShrines,
        IEnumerable<PointOfInterest> pointsOfInterest,
        IEnumerable<RegionTask> tasks,
        IEnumerable<SkillChallenge> skillChallenges,
        IEnumerable<MapSector> sectors,
        IEnumerable<MapAdventure> adventures,
        IEnumerable<MapMasteryPoint> masteryPoints) => new RegionMap()
    {
        Id = entity.Id,
        Name = entity.Name,
        MinLevel = entity.MinLevel,
        MaxLevel = entity.MaxLevel,
        DefaultFloor = entity.DefaultFloor,
        LabelCoord = [entity.LabelCoordX, entity.LabelCoordY],
        MapRect = [[entity.MapRectX1, entity.MapRectY1], [entity.MapRectX2, entity.MapRectY2]],
        ContinentRect = [[entity.ContinentRectX1, entity.ContinentRectY1], [entity.ContinentRectX2, entity.ContinentRectY2]],
        GodShrine = godShrines.ToArray(),
        PointsOfInterest = pointsOfInterest.ToDictionary(p => p.Id.ToString(), p => p),
        Tasks = tasks.ToDictionary(t => t.Id.ToString(), t => t),
        SkillChallenges = skillChallenges.ToArray(),
        Sectors = sectors.ToDictionary(s => s.Id.ToString(), s => s),
        Adventures = adventures.ToArray(),
        MasteryPoints = masteryPoints.ToArray(),
    };

    public static IReadOnlyList<ContinentFloorRegionMapGodShrineEntity> ToGodShrineEntities(RegionMap map, int regionMapId) =>
        map.GodShrine.Select(shrine => new ContinentFloorRegionMapGodShrineEntity()
        {
            Id = shrine.Id,
            RegionMapId = regionMapId,
            Name = shrine.Name,
            NameContested = shrine.NameContested,
            CoordX = shrine.Coord.ElementAtOrDefault(0),
            CoordY = shrine.Coord.ElementAtOrDefault(1),
            PoiId = shrine.PoiId,
            Icon = shrine.Icon,
            IconContested = shrine.IconContested,
        }).ToList();

    public static GodShrine ToGodShrineModel(ContinentFloorRegionMapGodShrineEntity entity) => new GodShrine()
    {
        Id = entity.Id,
        Name = entity.Name,
        NameContested = entity.NameContested,
        Coord = [entity.CoordX, entity.CoordY],
        PoiId = entity.PoiId,
        Icon = entity.Icon,
        IconContested = entity.IconContested,
    };

    public static IReadOnlyList<ContinentFloorRegionMapPointOfInterestEntity> ToPointOfInterestEntities(RegionMap map, int regionMapId) =>
        map.PointsOfInterest.Values.Select(poi => new ContinentFloorRegionMapPointOfInterestEntity()
        {
            Id = poi.Id,
            RegionMapId = regionMapId,
            Name = poi.Name,
            Type = poi.Type,
            Floor = poi.Floor,
            CoordX = poi.Coord.ElementAtOrDefault(0),
            CoordY = poi.Coord.ElementAtOrDefault(1),
            ChatLink = poi.ChatLink,
            Icon = poi.Icon ?? string.Empty,
        }).ToList();

    public static PointOfInterest ToPointOfInterestModel(ContinentFloorRegionMapPointOfInterestEntity entity) => new PointOfInterest()
    {
        Id = entity.Id,
        Name = entity.Name,
        Type = entity.Type,
        Floor = entity.Floor,
        Coord = [entity.CoordX, entity.CoordY],
        ChatLink = entity.ChatLink,
        Icon = string.IsNullOrEmpty(entity.Icon) ? null : entity.Icon,
    };

    public static IReadOnlyList<ContinentFloorRegionMapTaskEntity> ToTaskEntities(RegionMap map, int regionMapId) =>
        map.Tasks.Values.Select(task => new ContinentFloorRegionMapTaskEntity()
        {
            Id = task.Id,
            RegionMapId = regionMapId,
            Objective = task.Objective,
            Level = task.Level,
            CoordX = task.Coord.ElementAtOrDefault(0),
            CoordY = task.Coord.ElementAtOrDefault(1),
            BoundsJson = System.Text.Json.JsonSerializer.Serialize(task.Bounds),
            ChatLink = task.ChatLink,
        }).ToList();

    public static RegionTask ToTaskModel(ContinentFloorRegionMapTaskEntity entity) => new RegionTask()
    {
        Id = entity.Id,
        Objective = entity.Objective,
        Level = entity.Level,
        Coord = [entity.CoordX, entity.CoordY],
        Bounds = System.Text.Json.JsonSerializer.Deserialize<double[][]>(entity.BoundsJson) ?? [],
        ChatLink = entity.ChatLink,
    };

    public static IReadOnlyList<ContinentFloorRegionMapSkillChallengeEntity> ToSkillChallengeEntities(RegionMap map, int regionMapId) =>
        map.SkillChallenges.Select(challenge => new ContinentFloorRegionMapSkillChallengeEntity()
        {
            SkillChallengeId = challenge.Id ?? string.Empty,
            RegionMapId = regionMapId,
            CoordX = challenge.Coord.ElementAtOrDefault(0),
            CoordY = challenge.Coord.ElementAtOrDefault(1),
        }).ToList();

    public static SkillChallenge ToSkillChallengeModel(ContinentFloorRegionMapSkillChallengeEntity entity) => new SkillChallenge()
    {
        Id = string.IsNullOrEmpty(entity.SkillChallengeId) ? null : entity.SkillChallengeId,
        Coord = [entity.CoordX, entity.CoordY],
    };

    public static IReadOnlyList<ContinentFloorRegionMapSectorEntity> ToSectorEntities(RegionMap map, int regionMapId) =>
        map.Sectors.Values.Select(sector => new ContinentFloorRegionMapSectorEntity()
        {
            Id = sector.Id,
            RegionMapId = regionMapId,
            Name = sector.Name ?? string.Empty,
            Level = sector.Level,
            CoordX = sector.Coord.ElementAtOrDefault(0),
            CoordY = sector.Coord.ElementAtOrDefault(1),
            BoundsJson = System.Text.Json.JsonSerializer.Serialize(sector.Bounds),
            ChatLink = sector.ChatLink,
        }).ToList();

    public static MapSector ToSectorModel(ContinentFloorRegionMapSectorEntity entity) => new MapSector()
    {
        Id = entity.Id,
        Name = string.IsNullOrEmpty(entity.Name) ? null : entity.Name,
        Level = entity.Level,
        Coord = [entity.CoordX, entity.CoordY],
        Bounds = System.Text.Json.JsonSerializer.Deserialize<double[][]>(entity.BoundsJson) ?? [],
        ChatLink = entity.ChatLink,
    };

    public static IReadOnlyList<ContinentFloorRegionMapAdventureEntity> ToAdventureEntities(RegionMap map, int regionMapId) =>
        map.Adventures.Select(adventure => new ContinentFloorRegionMapAdventureEntity()
        {
            Id = adventure.Id,
            RegionMapId = regionMapId,
            Name = adventure.Name,
            Description = adventure.Description,
            CoordX = adventure.Coord.ElementAtOrDefault(0),
            CoordY = adventure.Coord.ElementAtOrDefault(1),
        }).ToList();

    public static MapAdventure ToAdventureModel(ContinentFloorRegionMapAdventureEntity entity) => new MapAdventure()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Coord = [entity.CoordX, entity.CoordY],
    };

    public static IReadOnlyList<ContinentFloorRegionMapMasteryPointEntity> ToMasteryPointEntities(RegionMap map, int regionMapId) =>
        map.MasteryPoints.Select(point => new ContinentFloorRegionMapMasteryPointEntity()
        {
            Id = point.Id,
            RegionMapId = regionMapId,
            CoordX = point.Coord.ElementAtOrDefault(0),
            CoordY = point.Coord.ElementAtOrDefault(1),
            Region = point.Region,
        }).ToList();

    public static MapMasteryPoint ToMasteryPointModel(ContinentFloorRegionMapMasteryPointEntity entity) => new MapMasteryPoint()
    {
        Id = entity.Id,
        Coord = [entity.CoordX, entity.CoordY],
        Region = entity.Region,
    };
}
