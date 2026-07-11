using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Achievement"/> to <see cref="AchievementEntity"/>.
/// </summary>
public static class AchievementMapper
{
    public static AchievementEntity ToEntity(Achievement achievement) => new AchievementEntity()
    {
        Id = achievement.Id,
        Icon = achievement.Icon,
        Name = achievement.Name,
        Description = achievement.Description,
        Requirement = achievement.Requirement,
        LockedText = achievement.LockedText,
        Type = achievement.Type,
        PointCap = achievement.PointCap,
        HasBits = achievement.Bits is not null,
    };

    public static IReadOnlyList<AchievementFlagEntity> ToFlagEntities(Achievement achievement) =>
        achievement.Flags.Select(flag => new AchievementFlagEntity() { AchievementId = achievement.Id, Flag = flag }).ToList();

    public static IReadOnlyList<AchievementTierEntity> ToTierEntities(Achievement achievement) =>
        achievement.Tiers.Select((tier, index) => new AchievementTierEntity()
        {
            AchievementId = achievement.Id,
            OrderIndex = index,
            Count = tier.Count,
            Points = tier.Points,
        }).ToList();

    public static AchievementTier ToTierModel(AchievementTierEntity entity) => new AchievementTier() { Count = entity.Count, Points = entity.Points };

    public static IReadOnlyList<AchievementPrerequisiteEntity> ToPrerequisiteEntities(Achievement achievement) =>
        achievement.Prerequisites.Select(id => new AchievementPrerequisiteEntity() { AchievementId = achievement.Id, PrerequisiteAchievementId = id }).ToList();

    public static IReadOnlyList<AchievementRewardEntity> ToRewardEntities(Achievement achievement) =>
        achievement.Rewards.Select((reward, index) =>
        {
            var entity = new AchievementRewardEntity() { AchievementId = achievement.Id, OrderIndex = index };
            switch (reward)
            {
                case AchievementRewardCoins r:
                    entity.RewardType = "Coins";
                    entity.Count = r.Count;
                    break;
                case AchievementRewardItem r:
                    entity.RewardType = "Item";
                    entity.RefId = r.Id;
                    entity.Count = r.Count;
                    break;
                case AchievementRewardMastery r:
                    entity.RewardType = "Mastery";
                    entity.RefId = r.Id;
                    entity.Region = r.Region;
                    break;
                case AchievementRewardTitle r:
                    entity.RewardType = "Title";
                    entity.RefId = r.Id;
                    break;
            }
            return entity;
        }).ToList();

    public static AchievementReward ToRewardModel(AchievementRewardEntity entity) => entity.RewardType switch
    {
        "Coins" => new AchievementRewardCoins() { Count = entity.Count ?? 0 },
        "Item" => new AchievementRewardItem() { Id = entity.RefId ?? 0, Count = entity.Count ?? 0 },
        "Mastery" => new AchievementRewardMastery() { Id = entity.RefId ?? 0, Region = entity.Region ?? string.Empty },
        "Title" => new AchievementRewardTitle() { Id = entity.RefId ?? 0 },
        _ => throw new InvalidOperationException($"Unknown achievement reward type '{entity.RewardType}'."),
    };

    public static IReadOnlyList<AchievementBitEntity> ToBitEntities(Achievement achievement) =>
        (achievement.Bits ?? []).Select((bit, index) => new AchievementBitEntity()
        {
            AchievementId = achievement.Id,
            OrderIndex = index,
            Type = bit.Type,
            RefId = bit.Id,
            Text = bit.Text,
        }).ToList();

    public static AchievementBit ToBitModel(AchievementBitEntity entity) => new AchievementBit()
    {
        Type = entity.Type,
        Id = entity.RefId,
        Text = entity.Text,
    };

    public static Achievement ToModel(
        AchievementEntity entity,
        IEnumerable<string> flags,
        IEnumerable<AchievementTier> tiers,
        IEnumerable<int> prerequisites,
        IEnumerable<AchievementReward> rewards,
        IEnumerable<AchievementBit> bits) => new Achievement()
    {
        Id = entity.Id,
        Icon = entity.Icon,
        Name = entity.Name,
        Description = entity.Description,
        Requirement = entity.Requirement,
        LockedText = entity.LockedText,
        Type = entity.Type,
        Flags = flags.ToArray(),
        Tiers = tiers.ToArray(),
        Prerequisites = prerequisites.ToArray(),
        Rewards = rewards.ToArray(),
        Bits = entity.HasBits ? bits.ToArray() : null,
        PointCap = entity.PointCap,
    };
}
