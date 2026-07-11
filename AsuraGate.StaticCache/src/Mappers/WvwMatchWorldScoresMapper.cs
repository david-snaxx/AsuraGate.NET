using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwMatchWorldScores"/> to <see cref="WvwMatchWorldScoresEntity"/>. Skirmish rows use a
/// DB-assigned id (not provided by the API), so <see cref="ToSkirmishMapScoreEntities"/> takes the
/// already-persisted skirmish id.
/// </summary>
public static class WvwMatchWorldScoresMapper
{
    public static WvwMatchWorldScoresEntity ToEntity(WvwMatchWorldScores scores) => new WvwMatchWorldScoresEntity()
    {
        Id = scores.Id,
        ScoresRed = scores.Scores.Red,
        ScoresBlue = scores.Scores.Blue,
        ScoresGreen = scores.Scores.Green,
        VictoryPointsRed = scores.VictoryPoints.Red,
        VictoryPointsBlue = scores.VictoryPoints.Blue,
        VictoryPointsGreen = scores.VictoryPoints.Green,
    };

    public static WvwMatchWorldScoresSkirmishEntity ToSkirmishEntity(WvwSkirmish skirmish, string worldScoresId) => new WvwMatchWorldScoresSkirmishEntity()
    {
        WorldScoresId = worldScoresId,
        SkirmishNumber = skirmish.Id,
        ScoresRed = skirmish.Scores.Red,
        ScoresBlue = skirmish.Scores.Blue,
        ScoresGreen = skirmish.Scores.Green,
    };

    public static IReadOnlyList<WvwMatchWorldScoresSkirmishMapScoreEntity> ToSkirmishMapScoreEntities(WvwSkirmish skirmish, int skirmishId) =>
        skirmish.MapScores.Select(mapScore => new WvwMatchWorldScoresSkirmishMapScoreEntity()
        {
            SkirmishId = skirmishId,
            MapType = mapScore.Type,
            ScoresRed = mapScore.Scores.Red,
            ScoresBlue = mapScore.Scores.Blue,
            ScoresGreen = mapScore.Scores.Green,
        }).ToList();

    public static WvwMapScore ToMapScoreModel(WvwMatchWorldScoresSkirmishMapScoreEntity entity) => new WvwMapScore()
    {
        Type = entity.MapType,
        Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
    };

    public static WvwSkirmish ToSkirmishModel(WvwMatchWorldScoresSkirmishEntity entity, IEnumerable<WvwMapScore> mapScores) => new WvwSkirmish()
    {
        Id = entity.SkirmishNumber,
        Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
        MapScores = mapScores.ToArray(),
    };

    public static IReadOnlyList<WvwMatchWorldScoresMapEntity> ToMapEntities(WvwMatchWorldScores scores) =>
        scores.Maps.Select(map => new WvwMatchWorldScoresMapEntity()
        {
            WorldScoresId = scores.Id,
            MapId = map.Id,
            MapType = map.Type,
            ScoresRed = map.Scores.Red,
            ScoresBlue = map.Scores.Blue,
            ScoresGreen = map.Scores.Green,
        }).ToList();

    public static WvwScoresMap ToMapModel(WvwMatchWorldScoresMapEntity entity) => new WvwScoresMap()
    {
        Id = entity.MapId,
        Type = entity.MapType,
        Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
    };

    public static WvwMatchWorldScores ToModel(WvwMatchWorldScoresEntity entity, IEnumerable<WvwSkirmish> skirmishes, IEnumerable<WvwScoresMap> maps) => new WvwMatchWorldScores()
    {
        Id = entity.Id,
        Scores = new WvwTeamValues() { Red = entity.ScoresRed, Blue = entity.ScoresBlue, Green = entity.ScoresGreen },
        VictoryPoints = new WvwTeamValues() { Red = entity.VictoryPointsRed, Blue = entity.VictoryPointsBlue, Green = entity.VictoryPointsGreen },
        Skirmishes = skirmishes.ToArray(),
        Maps = maps.ToArray(),
    };
}
