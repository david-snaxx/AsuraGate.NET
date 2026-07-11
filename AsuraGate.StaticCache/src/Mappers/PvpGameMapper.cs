using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="PvpGame"/> to <see cref="PvpGameEntity"/>.
/// </summary>
public static class PvpGameMapper
{
    public static PvpGameEntity ToEntity(PvpGame game) => new PvpGameEntity()
    {
        Id = game.Id,
        MapId = game.MapId,
        Started = game.Started,
        Ended = game.Ended,
        Result = game.Result,
        Team = game.Team,
        Profession = game.Profession,
        ScoresRed = game.Scores.Red,
        ScoresBlue = game.Scores.Blue,
        RatingType = game.RatingType,
        RatingChange = game.RatingChange,
        SeasonId = game.Season,
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
        Scores = new PvpGameScores() { Red = entity.ScoresRed, Blue = entity.ScoresBlue },
        RatingType = entity.RatingType,
        RatingChange = entity.RatingChange,
        Season = entity.SeasonId,
    };
}
