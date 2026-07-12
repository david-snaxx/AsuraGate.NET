using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities.V2.Pvp;

namespace AsuraGate.StaticCache.Mappers.V2.Pvp;

public static class PvpGameMapper
{
    public static PvpGameEntity ToPvpGameEntity(PvpGame game) => new PvpGameEntity()
    {
        Id = game.Id,
        MapId = game.MapId,
        Started = game.Started,
        Ended = game.Ended,
        Result = game.Result,
        Team = game.Team,
        Profession = game.Profession,
        ScoreRed = game.Scores.Red,
        ScoreBlue = game.Scores.Blue,
        RatingType = game.RatingType,
        RatingChange = game.RatingChange,
        Season = game.Season
    };

    public static PvpGame ToModel(PvpGameEntity entity) => new PvpGame()
    {
        Id = entity.Id,
        MapId = entity.MapId,
        Started = entity.Started,
        Ended = entity.Ended,
        Result = entity.Result,
        Team = entity.Team,
        Profession = entity.Profession,
        Scores = new PvpGameScores() { Red = entity.ScoreRed, Blue = entity.ScoreBlue },
        RatingType = entity.RatingType,
        RatingChange = entity.RatingChange,
        Season = entity.Season
    };
}
