using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwMatchWorldStats"/> to <see cref="WvwMatchWorldStatsEntity"/>.
/// </summary>
public static class WvwMatchWorldStatsMapper
{
    public static WvwMatchWorldStatsEntity ToEntity(WvwMatchWorldStats stats) => new WvwMatchWorldStatsEntity()
    {
        Id = stats.Id,
        DeathsRed = stats.Deaths.Red,
        DeathsBlue = stats.Deaths.Blue,
        DeathsGreen = stats.Deaths.Green,
        KillsRed = stats.Kills.Red,
        KillsBlue = stats.Kills.Blue,
        KillsGreen = stats.Kills.Green,
    };

    public static IReadOnlyList<WvwMatchWorldStatsMapEntity> ToMapEntities(WvwMatchWorldStats stats) =>
        stats.Maps.Select(map => new WvwMatchWorldStatsMapEntity()
        {
            WorldStatsId = stats.Id,
            MapId = map.Id,
            MapType = map.Type,
            DeathsRed = map.Deaths.Red,
            DeathsBlue = map.Deaths.Blue,
            DeathsGreen = map.Deaths.Green,
            KillsRed = map.Kills.Red,
            KillsBlue = map.Kills.Blue,
            KillsGreen = map.Kills.Green,
        }).ToList();

    public static WvwStatsMap ToMapModel(WvwMatchWorldStatsMapEntity entity) => new WvwStatsMap()
    {
        Id = entity.MapId,
        Type = entity.MapType,
        Deaths = new WvwTeamValues() { Red = entity.DeathsRed, Blue = entity.DeathsBlue, Green = entity.DeathsGreen },
        Kills = new WvwTeamValues() { Red = entity.KillsRed, Blue = entity.KillsBlue, Green = entity.KillsGreen },
    };

    public static WvwMatchWorldStats ToModel(WvwMatchWorldStatsEntity entity, IEnumerable<WvwStatsMap> maps) => new WvwMatchWorldStats()
    {
        Id = entity.Id,
        Deaths = new WvwTeamValues() { Red = entity.DeathsRed, Blue = entity.DeathsBlue, Green = entity.DeathsGreen },
        Kills = new WvwTeamValues() { Red = entity.KillsRed, Blue = entity.KillsBlue, Green = entity.KillsGreen },
        Maps = maps.ToArray(),
    };
}
