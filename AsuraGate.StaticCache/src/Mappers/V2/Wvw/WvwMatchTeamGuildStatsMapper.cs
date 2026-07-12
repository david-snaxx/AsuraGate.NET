using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;

namespace AsuraGate.StaticCache.Mappers.V2.Wvw;

public static class WvwMatchTeamGuildStatsMapper
{
    public static WvwMatchTeamGuildStatsEntity ToEntity(string matchId, string side, WvwMatchTeamGuildStats stats) => new WvwMatchTeamGuildStatsEntity()
    {
        MatchId = matchId,
        Side = side,
        GuildId = stats.GuildId,
        KillsRed = stats.Kills.Red,
        KillsBlue = stats.Kills.Blue,
        KillsGreen = stats.Kills.Green,
        DeathsRed = stats.Deaths.Red,
        DeathsBlue = stats.Deaths.Blue,
        DeathsGreen = stats.Deaths.Green,
        Wilson = stats.Wilson
    };

    public static WvwMatchTeamGuildStats ToModel(WvwMatchTeamGuildStatsEntity entity) => new WvwMatchTeamGuildStats()
    {
        GuildId = entity.GuildId,
        Kills = new WvwTeamValues() { Red = entity.KillsRed, Blue = entity.KillsBlue, Green = entity.KillsGreen },
        Deaths = new WvwTeamValues() { Red = entity.DeathsRed, Blue = entity.DeathsBlue, Green = entity.DeathsGreen },
        Wilson = entity.Wilson
    };
}
