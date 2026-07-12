using AsuraGate.Spec.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Spec.Mappers.V2.Pvp;

public static class PvpLeagueLeaderboardEntryMapper
{
    public static PvpLeagueLeaderboardEntryEntity ToEntity(string seasonId, string board, PvpLeagueLeaderboardEntry entry) => new PvpLeagueLeaderboardEntryEntity()
    {
        SeasonId = seasonId,
        Board = board,
        Name = entry.Name,
        Rank = entry.Rank,
        EntryId = entry.Id,
        Team = entry.Team,
        TeamId = entry.TeamId,
        Date = entry.Date
    };

    public static IEnumerable<PvpLeagueLeaderboardScoreEntity> ToScoreEntities(string seasonId, string board, PvpLeagueLeaderboardEntry entry) =>
        entry.Scores.Select(score => new PvpLeagueLeaderboardScoreEntity()
        {
            SeasonId = seasonId,
            Board = board,
            EntryId = entry.Id,
            ScoringId = score.Id,
            Value = score.Value
        });

    public static PvpLeagueLeaderboardEntry ToModel(PvpLeagueLeaderboardEntryEntity entity, IEnumerable<PvpLeagueLeaderboardScoreEntity> scoreEntities) => new PvpLeagueLeaderboardEntry()
    {
        Name = entity.Name,
        Rank = entity.Rank,
        Id = entity.EntryId,
        Team = entity.Team,
        TeamId = entity.TeamId,
        Date = entity.Date,
        Scores = scoreEntities.Select(score => new LeaderboardScore() { Id = score.ScoringId, Value = score.Value }).ToArray()
    };
}
