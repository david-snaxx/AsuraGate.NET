using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwMatchWorldOverview"/> to <see cref="WvwMatchWorldOverviewEntity"/>.
/// </summary>
public static class WvwMatchWorldOverviewMapper
{
    public static WvwMatchWorldOverviewEntity ToEntity(WvwMatchWorldOverview overview) => new WvwMatchWorldOverviewEntity()
    {
        Id = overview.Id,
        WorldRed = overview.Worlds.Red,
        WorldBlue = overview.Worlds.Blue,
        WorldGreen = overview.Worlds.Green,
        StartTime = overview.StartTime,
        EndTime = overview.EndTime,
    };

    public static IReadOnlyList<WvwMatchWorldOverviewAllWorldEntity> ToAllWorldEntities(WvwMatchWorldOverview overview) =>
        overview.AllWorlds.Red.Select((worldId, index) => new WvwMatchWorldOverviewAllWorldEntity() { OverviewId = overview.Id, Team = "Red", OrderIndex = index, WorldId = worldId })
            .Concat(overview.AllWorlds.Blue.Select((worldId, index) => new WvwMatchWorldOverviewAllWorldEntity() { OverviewId = overview.Id, Team = "Blue", OrderIndex = index, WorldId = worldId }))
            .Concat(overview.AllWorlds.Green.Select((worldId, index) => new WvwMatchWorldOverviewAllWorldEntity() { OverviewId = overview.Id, Team = "Green", OrderIndex = index, WorldId = worldId }))
            .ToList();

    public static WvwMultiTeamValues ToAllWorldsModel(IEnumerable<WvwMatchWorldOverviewAllWorldEntity> entities)
    {
        var list = entities.ToList();
        return new WvwMultiTeamValues()
        {
            Red = list.Where(e => e.Team == "Red").OrderBy(e => e.OrderIndex).Select(e => e.WorldId).ToArray(),
            Blue = list.Where(e => e.Team == "Blue").OrderBy(e => e.OrderIndex).Select(e => e.WorldId).ToArray(),
            Green = list.Where(e => e.Team == "Green").OrderBy(e => e.OrderIndex).Select(e => e.WorldId).ToArray(),
        };
    }

    public static WvwMatchWorldOverview ToModel(WvwMatchWorldOverviewEntity entity, WvwMultiTeamValues allWorlds) => new WvwMatchWorldOverview()
    {
        Id = entity.Id,
        Worlds = new WvwTeamValues() { Red = entity.WorldRed, Blue = entity.WorldBlue, Green = entity.WorldGreen },
        AllWorlds = allWorlds,
        StartTime = entity.StartTime,
        EndTime = entity.EndTime,
    };
}
