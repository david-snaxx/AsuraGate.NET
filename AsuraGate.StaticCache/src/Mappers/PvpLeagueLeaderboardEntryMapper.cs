using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="PvpLeagueLeaderboardEntry"/> to <see cref="PvpLeagueLeaderboardEntryEntity"/>. Uses a
/// DB-assigned id (not provided by the API), so <see cref="ToScoreEntities"/> takes the already-persisted row id.
/// </summary>
public static class PvpLeagueLeaderboardEntryMapper
{
    public static PvpLeagueLeaderboardEntryEntity ToEntity(PvpLeagueLeaderboardEntry entry) => new PvpLeagueLeaderboardEntryEntity()
    {
        EntryId = entry.Id,
        Name = entry.Name,
        Rank = entry.Rank,
        Team = entry.Team,
        TeamId = entry.TeamId,
        Date = entry.Date,
    };

    public static IReadOnlyList<PvpLeagueLeaderboardEntryScoreEntity> ToScoreEntities(PvpLeagueLeaderboardEntry entry, int leaderboardEntryId) =>
        entry.Scores.Select(score => new PvpLeagueLeaderboardEntryScoreEntity() { LeaderboardEntryId = leaderboardEntryId, ScoringId = score.Id, Value = score.Value }).ToList();

    public static LeaderboardScore ToScoreModel(PvpLeagueLeaderboardEntryScoreEntity entity) => new LeaderboardScore() { Id = entity.ScoringId, Value = entity.Value };

    public static PvpLeagueLeaderboardEntry ToModel(PvpLeagueLeaderboardEntryEntity entity, IEnumerable<LeaderboardScore> scores) => new PvpLeagueLeaderboardEntry()
    {
        Name = entity.Name,
        Rank = entity.Rank,
        Id = entity.EntryId,
        Team = entity.Team,
        TeamId = entity.TeamId,
        Date = entity.Date,
        Scores = scores.ToArray(),
    };
}
