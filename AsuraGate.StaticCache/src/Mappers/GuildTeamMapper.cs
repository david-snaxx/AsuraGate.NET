using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildTeam"/> to <see cref="GuildTeamEntity"/>.
/// </summary>
public static class GuildTeamMapper
{
    public static GuildTeamEntity ToEntity(GuildTeam team, string guildId) => new GuildTeamEntity()
    {
        Id = team.Id,
        GuildId = guildId,
        Name = team.Name,
        State = team.State,
        AggregateWins = team.Aggregate.Wins,
        AggregateLosses = team.Aggregate.Losses,
        AggregateDesertions = team.Aggregate.Desertions,
        AggregateByes = team.Aggregate.Byes,
        AggregateForfeits = team.Aggregate.Forfeits,
    };

    public static IReadOnlyList<GuildTeamMemberEntity> ToMemberEntities(GuildTeam team) =>
        team.Members.Select((member, index) => new GuildTeamMemberEntity() { GuildTeamId = team.Id, OrderIndex = index, Name = member.Name, Role = member.Role }).ToList();

    public static TeamMember ToMemberModel(GuildTeamMemberEntity entity) => new TeamMember() { Name = entity.Name, Role = entity.Role };

    public static IReadOnlyList<GuildTeamLadderEntity> ToLadderEntities(GuildTeam team) =>
        team.Ladders.Select(kvp => new GuildTeamLadderEntity()
        {
            GuildTeamId = team.Id,
            Ladder = kvp.Key,
            Wins = kvp.Value.Wins,
            Losses = kvp.Value.Losses,
            Desertions = kvp.Value.Desertions,
            Byes = kvp.Value.Byes,
            Forfeits = kvp.Value.Forfeits,
        }).ToList();

    public static PvpStatBreakdown ToBreakdownModel(GuildTeamLadderEntity entity) => new PvpStatBreakdown()
    {
        Wins = entity.Wins,
        Losses = entity.Losses,
        Desertions = entity.Desertions,
        Byes = entity.Byes,
        Forfeits = entity.Forfeits,
    };

    public static IReadOnlyList<GuildTeamGameEntity> ToGameEntities(GuildTeam team) =>
        team.Games.Select(game => new GuildTeamGameEntity()
        {
            Id = game.Id,
            GuildTeamId = team.Id,
            MapId = game.MapId,
            Started = game.Started,
            Ended = game.Ended,
            Result = game.Result,
            Team = game.Team,
            ScoresRed = game.Scores.Red,
            ScoresBlue = game.Scores.Blue,
            RatingType = game.RatingType,
        }).ToList();

    public static TeamGame ToGameModel(GuildTeamGameEntity entity) => new TeamGame()
    {
        Id = entity.Id,
        MapId = entity.MapId,
        Started = entity.Started,
        Ended = entity.Ended,
        Result = entity.Result,
        Team = entity.Team,
        Scores = new TeamGameScores() { Red = entity.ScoresRed, Blue = entity.ScoresBlue },
        RatingType = entity.RatingType,
    };

    public static IReadOnlyList<GuildTeamSeasonEntity> ToSeasonEntities(GuildTeam team) =>
        team.Seasons.Select(season => new GuildTeamSeasonEntity()
        {
            GuildTeamId = team.Id,
            SeasonId = season.Id,
            Wins = season.Wins,
            Losses = season.Losses,
            Rating = season.Rating,
        }).ToList();

    public static TeamSeason ToSeasonModel(GuildTeamSeasonEntity entity) => new TeamSeason()
    {
        Id = entity.SeasonId,
        Wins = entity.Wins,
        Losses = entity.Losses,
        Rating = entity.Rating,
    };

    public static GuildTeam ToModel(
        GuildTeamEntity entity,
        IEnumerable<TeamMember> members,
        IReadOnlyDictionary<string, PvpStatBreakdown> ladders,
        IEnumerable<TeamGame> games,
        IEnumerable<TeamSeason> seasons) => new GuildTeam()
    {
        Id = entity.Id,
        Name = entity.Name,
        State = entity.State,
        Members = members.ToArray(),
        Aggregate = new PvpStatBreakdown()
        {
            Wins = entity.AggregateWins,
            Losses = entity.AggregateLosses,
            Desertions = entity.AggregateDesertions,
            Byes = entity.AggregateByes,
            Forfeits = entity.AggregateForfeits,
        },
        Ladders = ladders.ToDictionary(l => l.Key, l => l.Value),
        Games = games.ToArray(),
        Seasons = seasons.ToArray(),
    };
}
