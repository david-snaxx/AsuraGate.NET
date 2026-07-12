using AsuraGate.Spec.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Spec.Mappers.V2.Wvw;

public static class WvwMatchWorldOverviewMapper
{
    public static WvwMatchWorldOverviewEntity ToWvwMatchWorldOverviewEntity(WvwMatchWorldOverview overview) => new WvwMatchWorldOverviewEntity()
    {
        Id = overview.Id,
        WorldsRed = overview.Worlds.Red,
        WorldsBlue = overview.Worlds.Blue,
        WorldsGreen = overview.Worlds.Green,
        StartTime = overview.StartTime,
        EndTime = overview.EndTime
    };

    public static IEnumerable<WvwMatchWorldOverviewAllWorldEntity> ToAllWorldEntities(WvwMatchWorldOverview overview)
    {
        var red = overview.AllWorlds.Red.Select((worldId, index) => new WvwMatchWorldOverviewAllWorldEntity() { MatchId = overview.Id, TeamColor = "red", OrderIndex = index, WorldId = worldId });
        var blue = overview.AllWorlds.Blue.Select((worldId, index) => new WvwMatchWorldOverviewAllWorldEntity() { MatchId = overview.Id, TeamColor = "blue", OrderIndex = index, WorldId = worldId });
        var green = overview.AllWorlds.Green.Select((worldId, index) => new WvwMatchWorldOverviewAllWorldEntity() { MatchId = overview.Id, TeamColor = "green", OrderIndex = index, WorldId = worldId });
        return red.Concat(blue).Concat(green);
    }

    public static WvwMatchWorldOverview ToModel(WvwMatchWorldOverviewEntity entity, IEnumerable<WvwMatchWorldOverviewAllWorldEntity> allWorldEntities)
    {
        var allWorlds = allWorldEntities.ToList();
        int[] WorldIds(string color) => allWorlds.Where(w => w.TeamColor == color).OrderBy(w => w.OrderIndex).Select(w => w.WorldId).ToArray();

        return new WvwMatchWorldOverview()
        {
            Id = entity.Id,
            Worlds = new WvwTeamValues() { Red = entity.WorldsRed, Blue = entity.WorldsBlue, Green = entity.WorldsGreen },
            AllWorlds = new WvwMultiTeamValues() { Red = WorldIds("red"), Blue = WorldIds("blue"), Green = WorldIds("green") },
            StartTime = entity.StartTime,
            EndTime = entity.EndTime
        };
    }
}
