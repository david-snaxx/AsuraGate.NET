using AsuraGate.Spec.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Spec.Mappers.V2.Achievements;

public static class AchievementMapper
{
    public static AchievementEntity ToAchievementEntity(Achievement achievement) =>
        new AchievementEntity()
        {
            Id = achievement.Id,
            Icon = achievement.Icon,
            Name = achievement.Name,
            Description = achievement.Description,
            Requirement = achievement.Requirement,
            LockedText = achievement.LockedText,
            Type = achievement.Type,
            PointCap = achievement.PointCap,
            HasFlags = achievement.Flags is not null,
            HasTiers = achievement.Tiers is not null,
            HasPrerequisites = achievement.Prerequisites is not null,
            HasRewards = achievement.Rewards is not null,
            HasBits = achievement.Bits is not null
        };

    public static IEnumerable<AchievementFlagEntity> ToAchievementFlagEntity(Achievement achievement)
    {
        if (achievement.Flags is null)
        {
            return Enumerable.Empty<AchievementFlagEntity>();
        }
        
        return achievement.Flags.Select(flag => new AchievementFlagEntity()
        {
            AchievementId = achievement.Id,
            Flag = flag
        });
    }

    public static IEnumerable<AchievementTierEntity> ToAchievementTierEntity(Achievement achievement)
    {
        if (achievement.Tiers is null)
        {
            return Enumerable.Empty<AchievementTierEntity>();
        }
        
        return achievement.Tiers.Select((tier, index) => new AchievementTierEntity()
        {
            AchievementId = achievement.Id,
            OrderIndex = index,
            Count = tier.Count,
            Points = tier.Points
        });
    }

    public static IEnumerable<AchievementPrerequisiteEntity> ToAchievementPrerequisiteEntity(Achievement achievement)
    {
        if (achievement.Prerequisites is null)
        {
            return Enumerable.Empty<AchievementPrerequisiteEntity>();
        }
        
        return achievement.Prerequisites.Select(prerequisite => new AchievementPrerequisiteEntity()
        {
            AchievementId = achievement.Id,
            PrerequisiteAchievementId = prerequisite
        });
    }

    public static IEnumerable<AchievementRewardEntity> ToAchievementRewardEntities(Achievement achievement)
    {
        if (achievement.Rewards is null)
        {
            return Enumerable.Empty<AchievementRewardEntity>();
        }
        
        return achievement.Rewards.Select((reward, index) => reward switch
        {
            AchievementRewardCoins coins => new AchievementRewardEntity
            {
                AchievementId = achievement.Id,
                OrderIndex = index,
                Type = "Coins",
                Count = coins.Count
            },
            AchievementRewardItem item => new AchievementRewardEntity
            {
                AchievementId = achievement.Id,
                OrderIndex = index,
                Type = "Item",
                ItemId = item.Id,
                Count = item.Count
            },
            AchievementRewardMastery mastery => new AchievementRewardEntity
            {
                AchievementId = achievement.Id,
                OrderIndex = index,
                Type = "Mastery",
                ItemId = mastery.Id,
                Region = mastery.Region
            },
            AchievementRewardTitle title => new AchievementRewardEntity
            {
                AchievementId = achievement.Id,
                OrderIndex = index,
                Type = "Title",
                ItemId = title.Id
            },
            _ => new AchievementRewardEntity
            {
                // A fallback catch-all
                AchievementId = achievement.Id,
                OrderIndex = index,
                Type = "Unknown"
            }
        });
    }

    public static IEnumerable<AchievementBitEntity> ToAchievementBitEntities(Achievement achievement)
    {
        if (achievement.Bits is null)
        {
            return Enumerable.Empty<AchievementBitEntity>();
        }
        
        return achievement.Bits.Select((bit, index) => new AchievementBitEntity()
        {
            AchievementId = achievement.Id,
            OrderIndex = index,
            Type = bit.Type,
            TypeObjectId = bit.Id,
            Text = bit.Text
        });
    }

    public static Achievement ToModel(
        AchievementEntity achievementEntity,
        IEnumerable<AchievementFlagEntity> achievementFlagEntities,
        IEnumerable<AchievementTierEntity> achievementTierEntities,
        IEnumerable<AchievementPrerequisiteEntity> achievementPrerequisiteEntities,
        IEnumerable<AchievementRewardEntity> achievementRewardEntities,
        IEnumerable<AchievementBitEntity> achievementBitEntities) =>
        new Achievement()
        {
            Id = achievementEntity.Id,
            Icon = achievementEntity.Icon,
            Name = achievementEntity.Name,
            Description = achievementEntity.Description,
            Requirement = achievementEntity.Requirement,
            LockedText = achievementEntity.LockedText,
            Type = achievementEntity.Type,
            PointCap = achievementEntity.PointCap,
            Flags = achievementEntity.HasFlags
                ? achievementFlagEntities.Select(flag => flag.Flag).ToArray()
                : null,
            Tiers = achievementEntity.HasTiers
                ? achievementTierEntities.OrderBy(tier => tier.OrderIndex).Select(tier => new AchievementTier()
                {
                    Count = tier.Count,
                    Points = tier.Points
                }).ToArray()
                : null,
            Prerequisites = achievementEntity.HasPrerequisites
                ? achievementPrerequisiteEntities.Select(prerequisite => prerequisite.PrerequisiteAchievementId).ToArray()
                : null,
            Rewards = achievementEntity.HasRewards
                ? achievementRewardEntities.OrderBy(reward => reward.OrderIndex).Select(reward => reward.Type switch
                {
                    // cast the first item to the base abstract class so the compiler knows what we are returning
                    "Coins" => (AchievementReward)new AchievementRewardCoins()
                    {
                        Count = reward.Count ?? 0
                    },
                    "Item" => new AchievementRewardItem()
                    {
                        Id = reward.ItemId ?? 0,
                        Count = reward.Count ?? 0
                    },
                    "Mastery" => new AchievementRewardMastery()
                    {
                        Id = reward.ItemId ?? 0,
                        Region = reward.Region ?? string.Empty
                    },
                    "Title" => new AchievementRewardTitle()
                    {
                        Id = reward.ItemId ?? 0
                    },
                    // default catch-all (throw an exception if the database gives us bad data)
                    _ => throw new NotSupportedException($"Unknown reward type: {reward.Type}")
                }).ToArray()
                : null,
            Bits = achievementEntity.HasBits
                ? achievementBitEntities.OrderBy(bit => bit.OrderIndex).Select(bit => new AchievementBit()
                {
                    Type = bit.Type,
                    Id = bit.TypeObjectId,
                    Text = bit.Text
                }).ToArray()
                : null
        };
}
