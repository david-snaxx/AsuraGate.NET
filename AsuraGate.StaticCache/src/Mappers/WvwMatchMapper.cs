using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwMatch"/> to <see cref="WvwMatchEntity"/>. Skirmishes, maps, and objectives all use
/// DB-assigned ids (not provided by the API), so their child collection mappers take the already-persisted
/// parent id as a parameter — callers must insert bottom-up.
/// </summary>
public static class WvwMatchMapper
{
    public static WvwMatchEntity ToEntity(WvwMatch match) => new WvwMatchEntity()
    {
        Id = match.Id,
        StartTime = match.StartTime,
        EndTime = match.EndTime,
        ScoresRed = match.Scores.Red,
        ScoresBlue = match.Scores.Blue,
        ScoresGreen = match.Scores.Green,
        WorldRed = match.Worlds.Red,
        WorldBlue = match.Worlds.Blue,
        WorldGreen = match.Worlds.Green,
        DeathsRed = match.Deaths.Red,
        DeathsBlue = match.Deaths.Blue,
        DeathsGreen = match.Deaths.Green,
        KillsRed = match.Kills.Red,
        KillsBlue = match.Kills.Blue,
        KillsGreen = match.Kills.Green,
        VictoryPointsRed = match.VictoryPoints.Red,
        VictoryPointsBlue = match.VictoryPoints.Blue,
        VictoryPointsGreen = match.VictoryPoints.Green,
    };

    public static IReadOnlyList<WvwMatchAllWorldEntity> ToAllWorldEntities(WvwMatch match) =>
        ToAllWorldEntities(match.AllWorlds, match.Id);

    public static IReadOnlyList<WvwMatchAllWorldEntity> ToAllWorldEntities(WvwMultiTeamValues allWorlds, string matchId) =>
        allWorlds.Red.Select((worldId, index) => new WvwMatchAllWorldEntity() { MatchId = matchId, Team = "Red", OrderIndex = index, WorldId = worldId })
            .Concat(allWorlds.Blue.Select((worldId, index) => new WvwMatchAllWorldEntity() { MatchId = matchId, Team = "Blue", OrderIndex = index, WorldId = worldId }))
            .Concat(allWorlds.Green.Select((worldId, index) => new WvwMatchAllWorldEntity() { MatchId = matchId, Team = "Green", OrderIndex = index, WorldId = worldId }))
            .ToList();

    public static WvwMultiTeamValues ToAllWorldsModel(IEnumerable<WvwMatchAllWorldEntity> entities)
    {
        var list = entities.ToList();
        return new WvwMultiTeamValues()
        {
            Red = list.Where(e => e.Team == "Red").OrderBy(e => e.OrderIndex).Select(e => e.WorldId).ToArray(),
            Blue = list.Where(e => e.Team == "Blue").OrderBy(e => e.OrderIndex).Select(e => e.WorldId).ToArray(),
            Green = list.Where(e => e.Team == "Green").OrderBy(e => e.OrderIndex).Select(e => e.WorldId).ToArray(),
        };
    }

    public static WvwMatchSkirmishEntity ToSkirmishEntity(WvwSkirmish skirmish, string matchId) => new WvwMatchSkirmishEntity()
    {
        MatchId = matchId,
        SkirmishNumber = skirmish.Id,
        ScoresRed = skirmish.Scores.Red,
        ScoresBlue = skirmish.Scores.Blue,
        ScoresGreen = skirmish.Scores.Green,
    };

    public static IReadOnlyList<WvwMatchSkirmishMapScoreEntity> ToSkirmishMapScoreEntities(WvwSkirmish skirmish, int skirmishId) =>
        skirmish.MapScores.Select(mapScore => new WvwMatchSkirmishMapScoreEntity()
        {
            SkirmishId = skirmishId,
            MapType = mapScore.Type,
            ScoresRed = mapScore.Scores.Red,
            ScoresBlue = mapScore.Scores.Blue,
            ScoresGreen = mapScore.Scores.Green,
        }).ToList();

    public static WvwMapScore ToMapScoreModel(WvwMatchSkirmishMapScoreEntity entity) => new WvwMapScore()
    {
        Type = entity.MapType,
        Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
    };

    public static WvwSkirmish ToSkirmishModel(WvwMatchSkirmishEntity entity, IEnumerable<WvwMapScore> mapScores) => new WvwSkirmish()
    {
        Id = entity.SkirmishNumber,
        Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
        MapScores = mapScores.ToArray(),
    };

    public static WvwMatchMapEntity ToMapEntity(WvwMatchMap map, string matchId) => new WvwMatchMapEntity()
    {
        MatchId = matchId,
        MapId = map.Id,
        MapType = map.Type,
        ScoresRed = map.Scores.Red,
        ScoresBlue = map.Scores.Blue,
        ScoresGreen = map.Scores.Green,
        DeathsRed = map.Deaths.Red,
        DeathsBlue = map.Deaths.Blue,
        DeathsGreen = map.Deaths.Green,
        KillsRed = map.Kills.Red,
        KillsBlue = map.Kills.Blue,
        KillsGreen = map.Kills.Green,
    };

    public static IReadOnlyList<WvwMatchMapBonusEntity> ToMapBonusEntities(WvwMatchMap map, int matchMapId) =>
        map.Bonuses.Select(bonus => new WvwMatchMapBonusEntity() { MatchMapId = matchMapId, BonusType = bonus.Type, Owner = bonus.Owner }).ToList();

    public static WvwBonus ToBonusModel(WvwMatchMapBonusEntity entity) => new WvwBonus() { Type = entity.BonusType, Owner = entity.Owner };

    public static IReadOnlyList<WvwMatchMapObjectiveEntity> ToMapObjectiveEntities(WvwMatchMap map, int matchMapId) =>
        map.Objectives.Select(objective => new WvwMatchMapObjectiveEntity()
        {
            MatchMapId = matchMapId,
            ObjectiveId = objective.Id,
            Type = objective.Type,
            Owner = objective.Owner,
            LastFlipped = objective.LastFlipped,
            ClaimedBy = objective.ClaimedBy,
            ClaimedAt = objective.ClaimedAt,
            PointsTick = objective.PointsTick,
            PointsCapture = objective.PointsCapture,
            YaksDelivered = objective.YaksDelivered,
        }).ToList();

    public static IReadOnlyList<WvwMatchMapObjectiveGuildUpgradeEntity> ToObjectiveGuildUpgradeEntities(WvwMatchObjective objective, int matchMapObjectiveId) =>
        objective.GuildUpgrades.Select(upgradeId => new WvwMatchMapObjectiveGuildUpgradeEntity() { MatchMapObjectiveId = matchMapObjectiveId, GuildUpgradeId = upgradeId }).ToList();

    public static WvwMatchObjective ToObjectiveModel(WvwMatchMapObjectiveEntity entity, IEnumerable<int> guildUpgrades) => new WvwMatchObjective()
    {
        Id = entity.ObjectiveId,
        Type = entity.Type,
        Owner = entity.Owner,
        LastFlipped = entity.LastFlipped,
        ClaimedBy = entity.ClaimedBy,
        ClaimedAt = entity.ClaimedAt,
        PointsTick = entity.PointsTick,
        PointsCapture = entity.PointsCapture,
        YaksDelivered = entity.YaksDelivered,
        GuildUpgrades = guildUpgrades.ToArray(),
    };

    public static WvwMatchMap ToMapModel(WvwMatchMapEntity entity, IEnumerable<WvwBonus> bonuses, IEnumerable<WvwMatchObjective> objectives) => new WvwMatchMap()
    {
        Id = entity.MapId,
        Type = entity.MapType,
        Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
        Bonuses = bonuses.ToArray(),
        Objectives = objectives.ToArray(),
        Deaths = new WvwTeamValues() { Red = entity.DeathsRed, Blue = entity.DeathsBlue, Green = entity.DeathsGreen },
        Kills = new WvwTeamValues() { Red = entity.KillsRed, Blue = entity.KillsBlue, Green = entity.KillsGreen },
    };

    public static WvwMatch ToModel(WvwMatchEntity entity, WvwMultiTeamValues allWorlds, IEnumerable<WvwSkirmish> skirmishes, IEnumerable<WvwMatchMap> maps) => new WvwMatch()
    {
        Id = entity.Id,
        StartTime = entity.StartTime,
        EndTime = entity.EndTime,
        Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
        Worlds = new WvwTeamValues() { Red = entity.WorldRed, Blue = entity.WorldBlue, Green = entity.WorldGreen },
        AllWorlds = allWorlds,
        Deaths = new WvwTeamValues() { Red = entity.DeathsRed, Blue = entity.DeathsBlue, Green = entity.DeathsGreen },
        Kills = new WvwTeamValues() { Red = entity.KillsRed, Blue = entity.KillsBlue, Green = entity.KillsGreen },
        VictoryPoints = new WvwTeamValues() { Red = entity.VictoryPointsRed, Blue = entity.VictoryPointsBlue, Green = entity.VictoryPointsGreen },
        Skirmishes = skirmishes.ToArray(),
        Maps = maps.ToArray(),
    };
}
