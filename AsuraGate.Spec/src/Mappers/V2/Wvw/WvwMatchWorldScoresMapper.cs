using AsuraGate.Spec.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Spec.Mappers.V2.Wvw;

public static class WvwMatchWorldScoresMapper
{
    public static WvwMatchWorldScoresEntity ToWvwMatchWorldScoresEntity(WvwMatchWorldScores scores) => new WvwMatchWorldScoresEntity()
    {
        Id = scores.Id,
        ScoresRed = scores.Scores.Red,
        ScoresBlue = scores.Scores.Blue,
        ScoresGreen = scores.Scores.Green,
        VictoryPointsRed = scores.VictoryPoints.Red,
        VictoryPointsBlue = scores.VictoryPoints.Blue,
        VictoryPointsGreen = scores.VictoryPoints.Green
    };

    public static IEnumerable<WvwMatchWorldScoresSkirmishEntity> ToSkirmishEntities(WvwMatchWorldScores scores) =>
        scores.Skirmishes.Select(skirmish => new WvwMatchWorldScoresSkirmishEntity()
        {
            MatchId = scores.Id,
            SkirmishNumber = skirmish.Id,
            ScoresRed = skirmish.Scores.Red,
            ScoresBlue = skirmish.Scores.Blue,
            ScoresGreen = skirmish.Scores.Green
        });

    public static IEnumerable<WvwMatchWorldScoresSkirmishMapEntity> ToSkirmishMapEntities(WvwMatchWorldScores scores) =>
        scores.Skirmishes.SelectMany(skirmish => skirmish.MapScores.Select(mapScore => new WvwMatchWorldScoresSkirmishMapEntity()
        {
            MatchId = scores.Id,
            SkirmishNumber = skirmish.Id,
            MapType = mapScore.Type,
            ScoresRed = mapScore.Scores.Red,
            ScoresBlue = mapScore.Scores.Blue,
            ScoresGreen = mapScore.Scores.Green
        }));

    public static IEnumerable<WvwMatchWorldScoresMapEntity> ToMapEntities(WvwMatchWorldScores scores) =>
        scores.Maps.Select(map => new WvwMatchWorldScoresMapEntity()
        {
            MatchId = scores.Id,
            MapId = map.Id,
            Type = map.Type,
            ScoresRed = map.Scores.Red,
            ScoresBlue = map.Scores.Blue,
            ScoresGreen = map.Scores.Green
        });

    public static WvwMatchWorldScores ToModel(
        WvwMatchWorldScoresEntity entity,
        IEnumerable<WvwMatchWorldScoresSkirmishEntity> skirmishEntities,
        IEnumerable<WvwMatchWorldScoresSkirmishMapEntity> skirmishMapEntities,
        IEnumerable<WvwMatchWorldScoresMapEntity> mapEntities)
    {
        var skirmishMaps = skirmishMapEntities.ToList();

        return new WvwMatchWorldScores()
        {
            Id = entity.Id,
            Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
            VictoryPoints = new WvwTeamValues() { Red = entity.VictoryPointsRed, Blue = entity.VictoryPointsBlue, Green = entity.VictoryPointsGreen },
            Skirmishes = skirmishEntities.OrderBy(skirmish => skirmish.SkirmishNumber).Select(skirmish => new WvwSkirmish()
            {
                Id = skirmish.SkirmishNumber,
                Scores = new WvwTeamValues() { Red = skirmish.ScoresRed, Blue = skirmish.ScoresBlue, Green = skirmish.ScoresGreen },
                MapScores = skirmishMaps.Where(mapScore => mapScore.SkirmishNumber == skirmish.SkirmishNumber).Select(mapScore => new WvwMapScore()
                {
                    Type = mapScore.MapType,
                    Scores = new WvwTeamValues() { Red = mapScore.ScoresRed, Blue = mapScore.ScoresBlue, Green = mapScore.ScoresGreen }
                }).ToArray()
            }).ToArray(),
            Maps = mapEntities.Select(map => new WvwScoresMap()
            {
                Id = map.MapId,
                Type = map.Type,
                Scores = new WvwTeamValues() { Red = map.ScoresRed, Blue = map.ScoresBlue, Green = map.ScoresGreen }
            }).ToArray()
        };
    }
}
