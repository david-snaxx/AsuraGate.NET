using AsuraGate.Spec.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Spec.Mappers.V2.Wvw;

public static class WvwMatchMapper
{
    public static WvwMatchEntity ToWvwMatchEntity(WvwMatch match) => new WvwMatchEntity()
    {
        Id = match.Id,
        StartTime = match.StartTime,
        EndTime = match.EndTime,
        ScoresRed = match.Scores.Red,
        ScoresBlue = match.Scores.Blue,
        ScoresGreen = match.Scores.Green,
        WorldsRed = match.Worlds.Red,
        WorldsBlue = match.Worlds.Blue,
        WorldsGreen = match.Worlds.Green,
        DeathsRed = match.Deaths.Red,
        DeathsBlue = match.Deaths.Blue,
        DeathsGreen = match.Deaths.Green,
        KillsRed = match.Kills.Red,
        KillsBlue = match.Kills.Blue,
        KillsGreen = match.Kills.Green,
        VictoryPointsRed = match.VictoryPoints.Red,
        VictoryPointsBlue = match.VictoryPoints.Blue,
        VictoryPointsGreen = match.VictoryPoints.Green
    };

    public static IEnumerable<WvwMatchAllWorldEntity> ToAllWorldEntities(WvwMatch match)
    {
        var red = match.AllWorlds.Red.Select((worldId, index) => new WvwMatchAllWorldEntity() { MatchId = match.Id, TeamColor = "red", OrderIndex = index, WorldId = worldId });
        var blue = match.AllWorlds.Blue.Select((worldId, index) => new WvwMatchAllWorldEntity() { MatchId = match.Id, TeamColor = "blue", OrderIndex = index, WorldId = worldId });
        var green = match.AllWorlds.Green.Select((worldId, index) => new WvwMatchAllWorldEntity() { MatchId = match.Id, TeamColor = "green", OrderIndex = index, WorldId = worldId });
        return red.Concat(blue).Concat(green);
    }

    public static IEnumerable<WvwMatchSkirmishEntity> ToSkirmishEntities(WvwMatch match) =>
        match.Skirmishes.Select(skirmish => new WvwMatchSkirmishEntity()
        {
            MatchId = match.Id,
            SkirmishNumber = skirmish.Id,
            ScoresRed = skirmish.Scores.Red,
            ScoresBlue = skirmish.Scores.Blue,
            ScoresGreen = skirmish.Scores.Green
        });

    public static IEnumerable<WvwMatchSkirmishMapScoreEntity> ToSkirmishMapScoreEntities(WvwMatch match) =>
        match.Skirmishes.SelectMany(skirmish => skirmish.MapScores.Select(mapScore => new WvwMatchSkirmishMapScoreEntity()
        {
            MatchId = match.Id,
            SkirmishNumber = skirmish.Id,
            MapType = mapScore.Type,
            ScoresRed = mapScore.Scores.Red,
            ScoresBlue = mapScore.Scores.Blue,
            ScoresGreen = mapScore.Scores.Green
        }));

    public static IEnumerable<WvwMatchMapEntity> ToMapEntities(WvwMatch match) =>
        match.Maps.Select(map => new WvwMatchMapEntity()
        {
            MatchId = match.Id,
            MapId = map.Id,
            Type = map.Type,
            ScoresRed = map.Scores.Red,
            ScoresBlue = map.Scores.Blue,
            ScoresGreen = map.Scores.Green,
            DeathsRed = map.Deaths.Red,
            DeathsBlue = map.Deaths.Blue,
            DeathsGreen = map.Deaths.Green,
            KillsRed = map.Kills.Red,
            KillsBlue = map.Kills.Blue,
            KillsGreen = map.Kills.Green
        });

    public static IEnumerable<WvwMatchMapBonusEntity> ToMapBonusEntities(WvwMatch match) =>
        match.Maps.SelectMany(map => map.Bonuses.Select(bonus => new WvwMatchMapBonusEntity()
        {
            MatchId = match.Id,
            MapId = map.Id,
            Type = bonus.Type,
            Owner = bonus.Owner
        }));

    public static IEnumerable<WvwMatchMapObjectiveEntity> ToMapObjectiveEntities(WvwMatch match) =>
        match.Maps.SelectMany(map => map.Objectives.Select(objective => new WvwMatchMapObjectiveEntity()
        {
            MatchId = match.Id,
            MapId = map.Id,
            ObjectiveId = objective.Id,
            Type = objective.Type,
            Owner = objective.Owner,
            LastFlipped = objective.LastFlipped,
            ClaimedBy = objective.ClaimedBy,
            ClaimedAt = objective.ClaimedAt,
            PointsTick = objective.PointsTick,
            PointsCapture = objective.PointsCapture,
            YaksDelivered = objective.YaksDelivered
        }));

    public static IEnumerable<WvwMatchMapObjectiveGuildUpgradeEntity> ToObjectiveGuildUpgradeEntities(WvwMatch match) =>
        match.Maps.SelectMany(map => map.Objectives.SelectMany(objective => objective.GuildUpgrades.Select(guildUpgradeId => new WvwMatchMapObjectiveGuildUpgradeEntity()
        {
            ObjectiveId = objective.Id,
            GuildUpgradeId = guildUpgradeId
        })));

    public static WvwMatch ToModel(
        WvwMatchEntity entity,
        IEnumerable<WvwMatchAllWorldEntity> allWorldEntities,
        IEnumerable<WvwMatchSkirmishEntity> skirmishEntities,
        IEnumerable<WvwMatchSkirmishMapScoreEntity> skirmishMapScoreEntities,
        IEnumerable<WvwMatchMapEntity> mapEntities,
        IEnumerable<WvwMatchMapBonusEntity> mapBonusEntities,
        IEnumerable<WvwMatchMapObjectiveEntity> mapObjectiveEntities,
        IEnumerable<WvwMatchMapObjectiveGuildUpgradeEntity> objectiveGuildUpgradeEntities)
    {
        var allWorlds = allWorldEntities.ToList();
        var skirmishMapScores = skirmishMapScoreEntities.ToList();
        var mapBonuses = mapBonusEntities.ToList();
        var mapObjectives = mapObjectiveEntities.ToList();
        var objectiveGuildUpgrades = objectiveGuildUpgradeEntities.ToList();

        int[] WorldIds(string color) => allWorlds.Where(w => w.TeamColor == color).OrderBy(w => w.OrderIndex).Select(w => w.WorldId).ToArray();

        return new WvwMatch()
        {
            Id = entity.Id,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
            Worlds = new WvwTeamValues() { Red = entity.WorldsRed, Blue = entity.WorldsBlue, Green = entity.WorldsGreen },
            AllWorlds = new WvwMultiTeamValues() { Red = WorldIds("red"), Blue = WorldIds("blue"), Green = WorldIds("green") },
            Deaths = new WvwTeamValues() { Red = entity.DeathsRed, Blue = entity.DeathsBlue, Green = entity.DeathsGreen },
            Kills = new WvwTeamValues() { Red = entity.KillsRed, Blue = entity.KillsBlue, Green = entity.KillsGreen },
            VictoryPoints = new WvwTeamValues() { Red = entity.VictoryPointsRed, Blue = entity.VictoryPointsBlue, Green = entity.VictoryPointsGreen },
            Skirmishes = skirmishEntities.OrderBy(skirmish => skirmish.SkirmishNumber).Select(skirmish => new WvwSkirmish()
            {
                Id = skirmish.SkirmishNumber,
                Scores = new WvwTeamValues() { Red = skirmish.ScoresRed, Blue = skirmish.ScoresBlue, Green = skirmish.ScoresGreen },
                MapScores = skirmishMapScores.Where(ms => ms.SkirmishNumber == skirmish.SkirmishNumber).Select(mapScore => new WvwMapScore()
                {
                    Type = mapScore.MapType,
                    Scores = new WvwTeamValues() { Red = mapScore.ScoresRed, Blue = mapScore.ScoresBlue, Green = mapScore.ScoresGreen }
                }).ToArray()
            }).ToArray(),
            Maps = mapEntities.Select(map => new WvwMatchMap()
            {
                Id = map.MapId,
                Type = map.Type,
                Scores = new WvwTeamValues() { Red = map.ScoresRed, Blue = map.ScoresBlue, Green = map.ScoresGreen },
                Bonuses = mapBonuses.Where(bonus => bonus.MapId == map.MapId).Select(bonus => new WvwBonus() { Type = bonus.Type, Owner = bonus.Owner }).ToArray(),
                Objectives = mapObjectives.Where(objective => objective.MapId == map.MapId).Select(objective => new WvwMatchObjective()
                {
                    Id = objective.ObjectiveId,
                    Type = objective.Type,
                    Owner = objective.Owner,
                    LastFlipped = objective.LastFlipped,
                    ClaimedBy = objective.ClaimedBy,
                    ClaimedAt = objective.ClaimedAt,
                    PointsTick = objective.PointsTick,
                    PointsCapture = objective.PointsCapture,
                    YaksDelivered = objective.YaksDelivered,
                    GuildUpgrades = objectiveGuildUpgrades.Where(gu => gu.ObjectiveId == objective.ObjectiveId).Select(gu => gu.GuildUpgradeId).ToArray()
                }).ToArray(),
                Deaths = new WvwTeamValues() { Red = map.DeathsRed, Blue = map.DeathsBlue, Green = map.DeathsGreen },
                Kills = new WvwTeamValues() { Red = map.KillsRed, Blue = map.KillsBlue, Green = map.KillsGreen }
            }).ToArray()
        };
    }
}
