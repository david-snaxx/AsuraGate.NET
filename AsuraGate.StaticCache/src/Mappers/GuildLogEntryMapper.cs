using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildLogEntry"/> to <see cref="GuildLogEntryEntity"/>.
/// </summary>
public static class GuildLogEntryMapper
{
    public static GuildLogEntryEntity ToEntity(GuildLogEntry entry, string guildId)
    {
        var entity = new GuildLogEntryEntity()
        {
            GuildId = guildId,
            LogId = entry.Id,
            Time = entry.Time,
            User = entry.User,
        };

        switch (entry)
        {
            case GuildLogEntryJoined:
                entity.LogType = "joined";
                break;
            case GuildLogEntryInvited e:
                entity.LogType = "invited";
                entity.InvitedBy = e.InvitedBy;
                break;
            case GuildLogEntryKick e:
                entity.LogType = "kick";
                entity.KickedBy = e.KickedBy;
                break;
            case GuildLogEntryRankChange e:
                entity.LogType = "rank_change";
                entity.ChangedBy = e.ChangedBy;
                entity.OldRank = e.OldRank;
                entity.NewRank = e.NewRank;
                break;
            case GuildLogEntryTreasury e:
                entity.LogType = "treasury";
                entity.ItemId = e.ItemId;
                entity.Count = e.Count;
                break;
            case GuildLogEntryStash e:
                entity.LogType = "stash";
                entity.Operation = e.Operation;
                entity.ItemId = e.ItemId;
                entity.Count = e.Count;
                entity.Coins = e.Coins;
                break;
            case GuildLogEntryMotd e:
                entity.LogType = "motd";
                entity.Motd = e.Motd;
                break;
            case GuildLogEntryUpgrade e:
                entity.LogType = "upgrade";
                entity.Action = e.Action;
                entity.UpgradeId = e.UpgradeId;
                entity.RecipeId = e.RecipeId;
                entity.ItemId = e.ItemId;
                entity.Count = e.Count;
                break;
            case GuildLogEntryInfluence e:
                entity.LogType = "influence";
                entity.Activity = e.Activity;
                entity.TotalParticipants = e.TotalParticipants;
                break;
            case GuildLogEntryMission e:
                entity.LogType = "mission";
                entity.State = e.State;
                entity.MissionInfluence = e.Influence;
                break;
        }

        return entity;
    }

    public static IReadOnlyList<GuildLogEntryParticipantEntity> ToParticipantEntities(GuildLogEntry entry, int guildLogEntryId) =>
        entry is GuildLogEntryInfluence influence
            ? influence.Participants.Select((name, index) => new GuildLogEntryParticipantEntity() { GuildLogEntryId = guildLogEntryId, OrderIndex = index, Participant = name }).ToList()
            : [];

    public static GuildLogEntry ToModel(GuildLogEntryEntity entity, IEnumerable<string> participants) => entity.LogType switch
    {
        "joined" => new GuildLogEntryJoined() { Id = entity.LogId, Time = entity.Time, User = entity.User },
        "invited" => new GuildLogEntryInvited() { Id = entity.LogId, Time = entity.Time, User = entity.User, InvitedBy = entity.InvitedBy ?? string.Empty },
        "kick" => new GuildLogEntryKick() { Id = entity.LogId, Time = entity.Time, User = entity.User, KickedBy = entity.KickedBy ?? string.Empty },
        "rank_change" => new GuildLogEntryRankChange() { Id = entity.LogId, Time = entity.Time, User = entity.User, ChangedBy = entity.ChangedBy ?? string.Empty, OldRank = entity.OldRank ?? string.Empty, NewRank = entity.NewRank ?? string.Empty },
        "treasury" => new GuildLogEntryTreasury() { Id = entity.LogId, Time = entity.Time, User = entity.User, ItemId = entity.ItemId ?? 0, Count = entity.Count ?? 0 },
        "stash" => new GuildLogEntryStash() { Id = entity.LogId, Time = entity.Time, User = entity.User, Operation = entity.Operation ?? string.Empty, ItemId = entity.ItemId, Count = entity.Count, Coins = entity.Coins },
        "motd" => new GuildLogEntryMotd() { Id = entity.LogId, Time = entity.Time, User = entity.User, Motd = entity.Motd ?? string.Empty },
        "upgrade" => new GuildLogEntryUpgrade() { Id = entity.LogId, Time = entity.Time, User = entity.User, Action = entity.Action ?? string.Empty, UpgradeId = entity.UpgradeId ?? 0, RecipeId = entity.RecipeId, ItemId = entity.ItemId, Count = entity.Count },
        "influence" => new GuildLogEntryInfluence() { Id = entity.LogId, Time = entity.Time, User = entity.User, Activity = entity.Activity ?? string.Empty, TotalParticipants = entity.TotalParticipants ?? 0, Participants = participants.ToArray() },
        "mission" => new GuildLogEntryMission() { Id = entity.LogId, Time = entity.Time, User = entity.User, State = entity.State ?? string.Empty, Influence = entity.MissionInfluence },
        _ => throw new InvalidOperationException($"Unknown guild log entry type '{entity.LogType}'."),
    };
}
