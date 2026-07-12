using AsuraGate.Spec.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Spec.Mappers.V2.Pvp;

public static class PvpSeasonMapper
{
    public static PvpSeasonEntity ToPvpSeasonEntity(PvpSeason season) => new PvpSeasonEntity()
    {
        Id = season.Id,
        Name = season.Name,
        Start = season.Start,
        End = season.End,
        Active = season.Active
    };

    public static IEnumerable<PvpSeasonDivisionEntity> ToDivisionEntities(PvpSeason season) =>
        season.Divisions.Select((division, index) => new PvpSeasonDivisionEntity()
        {
            SeasonId = season.Id,
            OrderIndex = index,
            Name = division.Name,
            LargeIcon = division.LargeIcon,
            SmallIcon = division.SmallIcon,
            PipIcon = division.PipIcon
        });

    public static IEnumerable<PvpSeasonDivisionFlagEntity> ToDivisionFlagEntities(PvpSeason season) =>
        season.Divisions.SelectMany((division, index) => division.Flags.Select(flag => new PvpSeasonDivisionFlagEntity()
        {
            SeasonId = season.Id,
            DivisionOrderIndex = index,
            Flag = flag
        }));

    public static IEnumerable<PvpSeasonDivisionTierEntity> ToDivisionTierEntities(PvpSeason season) =>
        season.Divisions.SelectMany((division, divisionIndex) => division.Tiers.Select((tier, tierIndex) => new PvpSeasonDivisionTierEntity()
        {
            SeasonId = season.Id,
            DivisionOrderIndex = divisionIndex,
            OrderIndex = tierIndex,
            Points = tier.Points
        }));

    public static IEnumerable<PvpSeasonRankEntity> ToRankEntities(PvpSeason season) =>
        season.Ranks.Select((rank, index) => new PvpSeasonRankEntity()
        {
            SeasonId = season.Id,
            OrderIndex = index,
            Name = rank.Name,
            Description = rank.Description,
            Icon = rank.Icon,
            Overlay = rank.Overlay,
            OverlaySmall = rank.OverlaySmall
        });

    public static IEnumerable<PvpSeasonRankTierEntity> ToRankTierEntities(PvpSeason season) =>
        season.Ranks.SelectMany((rank, rankIndex) => rank.Tiers.Select((tier, tierIndex) => new PvpSeasonRankTierEntity()
        {
            SeasonId = season.Id,
            RankOrderIndex = rankIndex,
            OrderIndex = tierIndex,
            Rating = tier.Rating
        }));

    private static PvpSeasonLeaderboardConfigEntity? ToConfigEntity(string seasonId, int leaderboardIndex, string slotType, PvpLeaderboardEntry? entry)
    {
        if (entry is null)
        {
            return null;
        }

        return new PvpSeasonLeaderboardConfigEntity()
        {
            SeasonId = seasonId,
            LeaderboardOrderIndex = leaderboardIndex,
            SlotType = slotType,
            SettingsName = entry.Settings.Name,
            SettingsDuration = entry.Settings.Duration,
            SettingsScoring = entry.Settings.Scoring,
            ScoringId = entry.Scorings.Id,
            ScoringType = entry.Scorings.Type,
            ScoringDescription = entry.Scorings.Description,
            ScoringName = entry.Scorings.Name,
            ScoringOrdering = entry.Scorings.Ordering
        };
    }

    public static IEnumerable<PvpSeasonLeaderboardConfigEntity> ToLeaderboardConfigEntities(PvpSeason season) =>
        season.Leaderboards.SelectMany((leaderboard, index) => new[]
        {
            ToConfigEntity(season.Id, index, "ladder", leaderboard.Ladder),
            ToConfigEntity(season.Id, index, "guild", leaderboard.Guild),
            ToConfigEntity(season.Id, index, "legendary", leaderboard.Legendary)
        }).Where(config => config is not null)!;

    public static IEnumerable<PvpSeasonLeaderboardConfigTierEntity> ToLeaderboardConfigTierEntities(PvpSeason season)
    {
        IEnumerable<PvpSeasonLeaderboardConfigTierEntity> TiersFor(int leaderboardIndex, string slotType, PvpLeaderboardEntry? entry) =>
            entry?.Settings.Tiers.Select((tier, index) => new PvpSeasonLeaderboardConfigTierEntity()
            {
                SeasonId = season.Id,
                LeaderboardOrderIndex = leaderboardIndex,
                SlotType = slotType,
                OrderIndex = index,
                Color = tier.Color,
                Type = tier.Type,
                Name = tier.Name,
                RangeMin = tier.Range[0],
                RangeMax = tier.Range[1]
            }) ?? [];

        return season.Leaderboards.SelectMany((leaderboard, index) =>
            TiersFor(index, "ladder", leaderboard.Ladder)
                .Concat(TiersFor(index, "guild", leaderboard.Guild))
                .Concat(TiersFor(index, "legendary", leaderboard.Legendary)));
    }

    public static PvpSeason ToModel(
        PvpSeasonEntity entity,
        IEnumerable<PvpSeasonDivisionEntity> divisionEntities,
        IEnumerable<PvpSeasonDivisionFlagEntity> divisionFlagEntities,
        IEnumerable<PvpSeasonDivisionTierEntity> divisionTierEntities,
        IEnumerable<PvpSeasonRankEntity> rankEntities,
        IEnumerable<PvpSeasonRankTierEntity> rankTierEntities,
        IEnumerable<PvpSeasonLeaderboardConfigEntity> leaderboardConfigEntities,
        IEnumerable<PvpSeasonLeaderboardConfigTierEntity> leaderboardConfigTierEntities)
    {
        var divisionFlags = divisionFlagEntities.ToList();
        var divisionTiers = divisionTierEntities.ToList();
        var rankTiers = rankTierEntities.ToList();
        var configs = leaderboardConfigEntities.ToList();
        var configTiers = leaderboardConfigTierEntities.ToList();

        PvpLeaderboardEntry? BuildConfig(int leaderboardIndex, string slotType)
        {
            var config = configs.FirstOrDefault(c => c.LeaderboardOrderIndex == leaderboardIndex && c.SlotType == slotType);
            if (config is null)
            {
                return null;
            }

            return new PvpLeaderboardEntry()
            {
                Settings = new PvpLeaderboardSettings()
                {
                    Name = config.SettingsName,
                    Duration = config.SettingsDuration,
                    Scoring = config.SettingsScoring,
                    Tiers = configTiers
                        .Where(tier => tier.LeaderboardOrderIndex == leaderboardIndex && tier.SlotType == slotType)
                        .OrderBy(tier => tier.OrderIndex)
                        .Select(tier => new PvpSettingsTier() { Color = tier.Color, Type = tier.Type, Name = tier.Name, Range = [tier.RangeMin, tier.RangeMax] })
                        .ToArray()
                },
                Scorings = new PvpLeaderboardScorings()
                {
                    Id = config.ScoringId,
                    Type = config.ScoringType,
                    Description = config.ScoringDescription,
                    Name = config.ScoringName,
                    Ordering = config.ScoringOrdering
                }
            };
        }

        return new PvpSeason()
        {
            Id = entity.Id,
            Name = entity.Name,
            Start = entity.Start,
            End = entity.End,
            Active = entity.Active,
            Divisions = divisionEntities.OrderBy(division => division.OrderIndex).Select(division => new PvpSeasonDivision()
            {
                Name = division.Name,
                Flags = divisionFlags.Where(flag => flag.DivisionOrderIndex == division.OrderIndex).Select(flag => flag.Flag).ToArray(),
                LargeIcon = division.LargeIcon,
                SmallIcon = division.SmallIcon,
                PipIcon = division.PipIcon,
                Tiers = divisionTiers
                    .Where(tier => tier.DivisionOrderIndex == division.OrderIndex)
                    .OrderBy(tier => tier.OrderIndex)
                    .Select(tier => new PvpDivisionTier() { Points = tier.Points })
                    .ToArray()
            }).ToArray(),
            Ranks = rankEntities.OrderBy(rank => rank.OrderIndex).Select(rank => new PvpSeasonRank()
            {
                Name = rank.Name,
                Description = rank.Description,
                Icon = rank.Icon,
                Overlay = rank.Overlay,
                OverlaySmall = rank.OverlaySmall,
                Tiers = rankTiers
                    .Where(tier => tier.RankOrderIndex == rank.OrderIndex)
                    .OrderBy(tier => tier.OrderIndex)
                    .Select(tier => new PvpRankTier() { Rating = tier.Rating })
                    .ToArray()
            }).ToArray(),
            Leaderboards = configs.Select(config => config.LeaderboardOrderIndex).Distinct().OrderBy(index => index).Select(index => new PvpSeasonLeaderboard()
            {
                Ladder = BuildConfig(index, "ladder"),
                Guild = BuildConfig(index, "guild"),
                Legendary = BuildConfig(index, "legendary")
            }).ToArray()
        };
    }
}
