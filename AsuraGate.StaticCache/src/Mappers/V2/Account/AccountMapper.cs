using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountMapper
{
    public static AccountEntity ToAccountEntity(Spec.Models.V2.Account.Account account) => new AccountEntity()
    {
        Id = account.Id,
        Age = account.Age,
        Name = account.Name,
        World = account.World,
        Created = account.Created,
        Commander = account.Commander,
        FractalLevel = account.FractalLevel,
        DailyAp = account.DailyAp,
        MonthlyAp = account.MonthlyAp,
        WvwRank = account.WvwRank,
        WvwTeamId = account.Wvw?.TeamId,
        WvwTeamRank = account.Wvw?.Rank,
        LastModified = account.LastModified,
        BuildStorageSlots = account.BuildStorageSlots
    };

    public static IEnumerable<AccountGuildEntity> ToGuildEntities(Spec.Models.V2.Account.Account account)
    {
        var leaderIds = account.GuildLeader.ToHashSet();
        var memberRows = account.Guilds.Select(guildId => new AccountGuildEntity()
        {
            AccountId = account.Id,
            GuildId = guildId,
            IsMember = true,
            IsLeader = leaderIds.Contains(guildId)
        });

        // GuildLeader should always be a subset of Guilds, but guard against it not being one.
        var memberIds = account.Guilds.ToHashSet();
        var leaderOnlyRows = account.GuildLeader.Where(guildId => !memberIds.Contains(guildId)).Select(guildId => new AccountGuildEntity()
        {
            AccountId = account.Id,
            GuildId = guildId,
            IsMember = false,
            IsLeader = true
        });

        return memberRows.Concat(leaderOnlyRows);
    }

    public static IEnumerable<AccountAccessEntity> ToAccessEntities(Spec.Models.V2.Account.Account account) =>
        account.Access.Select(access => new AccountAccessEntity() { AccountId = account.Id, Access = access });

    public static Spec.Models.V2.Account.Account ToModel(
        AccountEntity entity,
        IEnumerable<AccountGuildEntity> guildEntities,
        IEnumerable<AccountAccessEntity> accessEntities)
    {
        var guilds = guildEntities.ToList();

        return new Spec.Models.V2.Account.Account()
        {
            Id = entity.Id,
            Age = entity.Age,
            Name = entity.Name,
            World = entity.World,
            Guilds = guilds.Where(g => g.IsMember).Select(g => g.GuildId).ToArray(),
            GuildLeader = guilds.Where(g => g.IsLeader).Select(g => g.GuildId).ToArray(),
            Created = entity.Created,
            Access = accessEntities.Select(access => access.Access).ToArray(),
            Commander = entity.Commander,
            FractalLevel = entity.FractalLevel,
            DailyAp = entity.DailyAp,
            MonthlyAp = entity.MonthlyAp,
            WvwRank = entity.WvwRank,
            Wvw = entity.WvwTeamId is null ? null : new AccountWvw() { TeamId = entity.WvwTeamId.Value, Rank = entity.WvwTeamRank ?? 0 },
            LastModified = entity.LastModified,
            BuildStorageSlots = entity.BuildStorageSlots
        };
    }
}
