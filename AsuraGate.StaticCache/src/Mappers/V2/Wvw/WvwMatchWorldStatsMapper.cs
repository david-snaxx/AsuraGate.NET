using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;

namespace AsuraGate.StaticCache.Mappers.V2.Wvw;

public static class WvwMatchWorldStatsMapper
{
    public static WvwMatchWorldStatsEntity ToWvwMatchWorldStatsEntity(WvwMatchWorldStats stats) => new WvwMatchWorldStatsEntity()
    {
        Id = stats.Id,
        DeathsRed = stats.Deaths.Red,
        DeathsBlue = stats.Deaths.Blue,
        DeathsGreen = stats.Deaths.Green,
        KillsRed = stats.Kills.Red,
        KillsBlue = stats.Kills.Blue,
        KillsGreen = stats.Kills.Green
    };

    public static IEnumerable<WvwMatchWorldStatsMapEntity> ToMapEntities(WvwMatchWorldStats stats) =>
        stats.Maps.Select(map => new WvwMatchWorldStatsMapEntity()
        {
            MatchId = stats.Id,
            MapId = map.Id,
            Type = map.Type,
            DeathsRed = map.Deaths.Red,
            DeathsBlue = map.Deaths.Blue,
            DeathsGreen = map.Deaths.Green,
            KillsRed = map.Kills.Red,
            KillsBlue = map.Kills.Blue,
            KillsGreen = map.Kills.Green
        });

    public static WvwMatchWorldStats ToModel(WvwMatchWorldStatsEntity entity, IEnumerable<WvwMatchWorldStatsMapEntity> mapEntities) => new WvwMatchWorldStats()
    {
        Id = entity.Id,
        Deaths = new WvwTeamValues() { Red = entity.DeathsRed, Blue = entity.DeathsBlue, Green = entity.DeathsGreen },
        Kills = new WvwTeamValues() { Red = entity.KillsRed, Blue = entity.KillsBlue, Green = entity.KillsGreen },
        Maps = mapEntities.Select(map => new WvwStatsMap()
        {
            Id = map.MapId,
            Type = map.Type,
            Deaths = new WvwTeamValues() { Red = map.DeathsRed, Blue = map.DeathsBlue, Green = map.DeathsGreen },
            Kills = new WvwTeamValues() { Red = map.KillsRed, Blue = map.KillsBlue, Green = map.KillsGreen }
        }).ToArray()
    };
}
