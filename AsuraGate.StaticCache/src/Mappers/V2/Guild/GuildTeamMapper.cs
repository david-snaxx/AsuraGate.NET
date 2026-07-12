using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities.V2.Guild;

namespace AsuraGate.StaticCache.Mappers.V2.Guild;

public static class GuildTeamMapper
{
    public static GuildTeamEntity ToGuildTeamEntity(GuildTeam team) => new GuildTeamEntity()
    {
        Id = team.Id,
        Name = team.Name,
        State = team.State,
        AggregateWins = team.Aggregate.Wins,
        AggregateLosses = team.Aggregate.Losses,
        AggregateDesertions = team.Aggregate.Desertions,
        AggregateByes = team.Aggregate.Byes,
        AggregateForfeits = team.Aggregate.Forfeits
    };

    public static IEnumerable<GuildTeamMemberEntity> ToMemberEntities(GuildTeam team) =>
        team.Members.Select(member => new GuildTeamMemberEntity() { GuildTeamId = team.Id, Name = member.Name, Role = member.Role });

    public static IEnumerable<GuildTeamLadderEntity> ToLadderEntities(GuildTeam team) =>
        team.Ladders.Select(pair => new GuildTeamLadderEntity()
        {
            GuildTeamId = team.Id,
            Ladder = pair.Key,
            Wins = pair.Value.Wins,
            Losses = pair.Value.Losses,
            Desertions = pair.Value.Desertions,
            Byes = pair.Value.Byes,
            Forfeits = pair.Value.Forfeits
        });

    public static IEnumerable<GuildTeamGameEntity> ToGameEntities(GuildTeam team) =>
        team.Games.Select(game => new GuildTeamGameEntity()
        {
            Id = game.Id,
            GuildTeamId = team.Id,
            MapId = game.MapId,
            Started = game.Started,
            Ended = game.Ended,
            Result = game.Result,
            Team = game.Team,
            ScoreRed = game.Scores.Red,
            ScoreBlue = game.Scores.Blue,
            RatingType = game.RatingType
        });

    public static IEnumerable<GuildTeamSeasonEntity> ToSeasonEntities(GuildTeam team) =>
        team.Seasons.Select(season => new GuildTeamSeasonEntity()
        {
            GuildTeamId = team.Id,
            SeasonId = season.Id,
            Wins = season.Wins,
            Losses = season.Losses,
            Rating = season.Rating
        });

    public static GuildTeam ToModel(
        GuildTeamEntity entity,
        IEnumerable<GuildTeamMemberEntity> memberEntities,
        IEnumerable<GuildTeamLadderEntity> ladderEntities,
        IEnumerable<GuildTeamGameEntity> gameEntities,
        IEnumerable<GuildTeamSeasonEntity> seasonEntities) => new GuildTeam()
    {
        Id = entity.Id,
        Name = entity.Name,
        State = entity.State,
        Members = memberEntities.Select(member => new TeamMember() { Name = member.Name, Role = member.Role }).ToArray(),
        Aggregate = new PvpStatBreakdown()
        {
            Wins = entity.AggregateWins,
            Losses = entity.AggregateLosses,
            Desertions = entity.AggregateDesertions,
            Byes = entity.AggregateByes,
            Forfeits = entity.AggregateForfeits
        },
        Ladders = ladderEntities.ToDictionary(ladder => ladder.Ladder, ladder => new PvpStatBreakdown()
        {
            Wins = ladder.Wins,
            Losses = ladder.Losses,
            Desertions = ladder.Desertions,
            Byes = ladder.Byes,
            Forfeits = ladder.Forfeits
        }),
        Games = gameEntities.Select(game => new TeamGame()
        {
            Id = game.Id,
            MapId = game.MapId,
            Started = game.Started,
            Ended = game.Ended,
            Result = game.Result,
            Team = game.Team,
            Scores = new TeamGameScores() { Red = game.ScoreRed, Blue = game.ScoreBlue },
            RatingType = game.RatingType
        }).ToArray(),
        Seasons = seasonEntities.Select(season => new TeamSeason()
        {
            Id = season.SeasonId,
            Wins = season.Wins,
            Losses = season.Losses,
            Rating = season.Rating
        }).ToArray()
    };
}
