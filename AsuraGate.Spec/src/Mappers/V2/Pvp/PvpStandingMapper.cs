using AsuraGate.Spec.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Spec.Mappers.V2.Pvp;

public static class PvpStandingMapper
{
    public static PvpStandingEntity ToEntity(string accountId, PvpStanding standing) => new PvpStandingEntity()
    {
        AccountId = accountId,
        SeasonId = standing.SeasonId,
        CurrentTotalPoints = standing.Current.TotalPoints,
        CurrentDivision = standing.Current.Division,
        CurrentTier = standing.Current.Tier,
        CurrentPoints = standing.Current.Points,
        CurrentRepeats = standing.Current.Repeats,
        CurrentRating = standing.Current.Rating,
        CurrentDecay = standing.Current.Decay,
        BestTotalPoints = standing.Best.TotalPoints,
        BestDivision = standing.Best.Division,
        BestTier = standing.Best.Tier,
        BestPoints = standing.Best.Points,
        BestRepeats = standing.Best.Repeats
    };

    public static PvpStanding ToModel(PvpStandingEntity entity) => new PvpStanding()
    {
        Current = new PvpStandingCurrent()
        {
            TotalPoints = entity.CurrentTotalPoints,
            Division = entity.CurrentDivision,
            Tier = entity.CurrentTier,
            Points = entity.CurrentPoints,
            Repeats = entity.CurrentRepeats,
            Rating = entity.CurrentRating,
            Decay = entity.CurrentDecay
        },
        Best = new PvpStandingBest()
        {
            TotalPoints = entity.BestTotalPoints,
            Division = entity.BestDivision,
            Tier = entity.BestTier,
            Points = entity.BestPoints,
            Repeats = entity.BestRepeats
        },
        SeasonId = entity.SeasonId
    };
}
