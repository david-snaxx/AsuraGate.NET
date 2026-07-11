using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="PvpSeason"/> to <see cref="PvpSeasonEntity"/>. Divisions, ranks, and leaderboards all use
/// DB-assigned ids (not provided by the API), so their child collection mappers take the already-persisted
/// parent id as a parameter — callers must insert bottom-up.
/// </summary>
public static class PvpSeasonMapper
{
    public static PvpSeasonEntity ToEntity(PvpSeason season) => new PvpSeasonEntity()
    {
        Id = season.Id,
        Name = season.Name,
        Start = season.Start,
        End = season.End,
        Active = season.Active,
    };

    public static PvpSeasonDivisionEntity ToDivisionEntity(PvpSeasonDivision division, string seasonId, int orderIndex) => new PvpSeasonDivisionEntity()
    {
        SeasonId = seasonId,
        OrderIndex = orderIndex,
        Name = division.Name,
        LargeIcon = division.LargeIcon,
        SmallIcon = division.SmallIcon,
        PipIcon = division.PipIcon,
    };

    public static IReadOnlyList<PvpSeasonDivisionFlagEntity> ToDivisionFlagEntities(PvpSeasonDivision division, int divisionId) =>
        division.Flags.Select(flag => new PvpSeasonDivisionFlagEntity() { DivisionId = divisionId, Flag = flag }).ToList();

    public static IReadOnlyList<PvpSeasonDivisionTierEntity> ToDivisionTierEntities(PvpSeasonDivision division, int divisionId) =>
        division.Tiers.Select((tier, index) => new PvpSeasonDivisionTierEntity() { DivisionId = divisionId, OrderIndex = index, Points = tier.Points }).ToList();

    public static PvpSeasonDivision ToDivisionModel(PvpSeasonDivisionEntity entity, IEnumerable<string> flags, IEnumerable<PvpDivisionTier> tiers) => new PvpSeasonDivision()
    {
        Name = entity.Name,
        Flags = flags.ToArray(),
        LargeIcon = entity.LargeIcon,
        SmallIcon = entity.SmallIcon,
        PipIcon = entity.PipIcon,
        Tiers = tiers.ToArray(),
    };

    public static PvpDivisionTier ToDivisionTierModel(PvpSeasonDivisionTierEntity entity) => new PvpDivisionTier() { Points = entity.Points };

    public static PvpSeasonRankEntity ToRankEntity(PvpSeasonRank rank, string seasonId, int orderIndex) => new PvpSeasonRankEntity()
    {
        SeasonId = seasonId,
        OrderIndex = orderIndex,
        Name = rank.Name,
        Description = rank.Description,
        Icon = rank.Icon,
        Overlay = rank.Overlay,
        OverlaySmall = rank.OverlaySmall,
    };

    public static IReadOnlyList<PvpSeasonRankTierEntity> ToRankTierEntities(PvpSeasonRank rank, int seasonRankId) =>
        rank.Tiers.Select((tier, index) => new PvpSeasonRankTierEntity() { SeasonRankId = seasonRankId, OrderIndex = index, Rating = tier.Rating }).ToList();

    public static PvpSeasonRank ToRankModel(PvpSeasonRankEntity entity, IEnumerable<PvpRankTier> tiers) => new PvpSeasonRank()
    {
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Overlay = entity.Overlay,
        OverlaySmall = entity.OverlaySmall,
        Tiers = tiers.ToArray(),
    };

    public static PvpRankTier ToRankTierModel(PvpSeasonRankTierEntity entity) => new PvpRankTier() { Rating = entity.Rating };

    public static PvpSeasonLeaderboardEntity? ToLeaderboardEntity(PvpLeaderboardEntry? entry, string seasonId, string slot)
    {
        if (entry is null) return null;
        return new PvpSeasonLeaderboardEntity()
        {
            SeasonId = seasonId,
            Slot = slot,
            SettingsName = entry.Settings.Name,
            SettingsDuration = entry.Settings.Duration,
            SettingsScoring = entry.Settings.Scoring,
            ScoringsId = entry.Scorings.Id,
            ScoringsType = entry.Scorings.Type,
            ScoringsDescription = entry.Scorings.Description,
            ScoringsName = entry.Scorings.Name,
            ScoringsOrdering = entry.Scorings.Ordering,
        };
    }

    public static IReadOnlyList<PvpSeasonLeaderboardTierEntity> ToLeaderboardTierEntities(PvpLeaderboardEntry entry, int leaderboardId) =>
        entry.Settings.Tiers.Select((tier, index) => new PvpSeasonLeaderboardTierEntity()
        {
            LeaderboardId = leaderboardId,
            OrderIndex = index,
            Color = tier.Color,
            Type = tier.Type,
            Name = tier.Name,
            RangeMin = tier.Range.ElementAtOrDefault(0),
            RangeMax = tier.Range.ElementAtOrDefault(1),
        }).ToList();

    public static PvpLeaderboardEntry ToLeaderboardModel(PvpSeasonLeaderboardEntity entity, IEnumerable<PvpSettingsTier> tiers) => new PvpLeaderboardEntry()
    {
        Settings = new PvpLeaderboardSettings()
        {
            Name = entity.SettingsName,
            Duration = entity.SettingsDuration,
            Scoring = entity.SettingsScoring,
            Tiers = tiers.ToArray(),
        },
        Scorings = new PvpLeaderboardScorings()
        {
            Id = entity.ScoringsId,
            Type = entity.ScoringsType,
            Description = entity.ScoringsDescription,
            Name = entity.ScoringsName,
            Ordering = entity.ScoringsOrdering,
        },
    };

    public static PvpSettingsTier ToLeaderboardTierModel(PvpSeasonLeaderboardTierEntity entity) => new PvpSettingsTier()
    {
        Color = entity.Color,
        Type = entity.Type,
        Name = entity.Name,
        Range = [entity.RangeMin, entity.RangeMax],
    };

    public static PvpSeason ToModel(
        PvpSeasonEntity entity,
        IEnumerable<PvpSeasonDivision> divisions,
        IEnumerable<PvpSeasonRank> ranks,
        PvpLeaderboardEntry? ladder,
        PvpLeaderboardEntry? guild,
        PvpLeaderboardEntry? legendary) => new PvpSeason()
    {
        Id = entity.Id,
        Name = entity.Name,
        Start = entity.Start,
        End = entity.End,
        Active = entity.Active,
        Divisions = divisions.ToArray(),
        Ranks = ranks.ToArray(),
        Leaderboards = [new PvpSeasonLeaderboard() { Ladder = ladder, Guild = guild, Legendary = legendary }],
    };
}
