using AsuraGate.Spec.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Spec.Mappers.V2.Guild;

/// <summary>
/// Maps <see cref="GuildLogEntry"/>. Every method takes <paramref name="guildId"/> explicitly since the
/// model itself doesn't carry which guild a log entry belongs to.
/// </summary>
public static class GuildLogEntryMapper
{
    public static GuildLogEntryEntity ToEntity(string guildId, GuildLogEntry entry)
    {
        var entity = new GuildLogEntryEntity()
        {
            GuildId = guildId,
            LogEntryId = entry.Id,
            Time = entry.Time,
            User = entry.User
        };

        switch (entry)
        {
            case GuildLogEntryJoined:
                entity.Type = "joined";
                break;
            case GuildLogEntryInvited e:
                entity.Type = "invited";
                entity.InvitedBy = e.InvitedBy;
                break;
            case GuildLogEntryKick e:
                entity.Type = "kick";
                entity.KickedBy = e.KickedBy;
                break;
            case GuildLogEntryRankChange e:
                entity.Type = "rank_change";
                entity.ChangedBy = e.ChangedBy;
                entity.OldRank = e.OldRank;
                entity.NewRank = e.NewRank;
                break;
            case GuildLogEntryTreasury e:
                entity.Type = "treasury";
                entity.ItemId = e.ItemId;
                entity.Count = e.Count;
                break;
            case GuildLogEntryStash e:
                entity.Type = "stash";
                entity.Operation = e.Operation;
                entity.ItemId = e.ItemId;
                entity.Count = e.Count;
                entity.Coins = e.Coins;
                break;
            case GuildLogEntryMotd e:
                entity.Type = "motd";
                entity.Motd = e.Motd;
                break;
            case GuildLogEntryUpgrade e:
                entity.Type = "upgrade";
                entity.Action = e.Action;
                entity.UpgradeId = e.UpgradeId;
                entity.RecipeId = e.RecipeId;
                entity.ItemId = e.ItemId;
                entity.Count = e.Count;
                break;
            case GuildLogEntryInfluence e:
                entity.Type = "influence";
                entity.Activity = e.Activity;
                entity.TotalParticipants = e.TotalParticipants;
                break;
            case GuildLogEntryMission e:
                entity.Type = "mission";
                entity.State = e.State;
                entity.Influence = e.Influence;
                break;
        }

        return entity;
    }

    public static IEnumerable<GuildLogEntryParticipantEntity> ToParticipantEntities(string guildId, GuildLogEntry entry) =>
        entry is GuildLogEntryInfluence influence
            ? influence.Participants.Select((participant, index) => new GuildLogEntryParticipantEntity()
            {
                GuildId = guildId,
                LogEntryId = entry.Id,
                OrderIndex = index,
                Participant = participant
            })
            : [];

    public static GuildLogEntry ToModel(GuildLogEntryEntity entity, IEnumerable<GuildLogEntryParticipantEntity> participantEntities) => entity.Type switch
    {
        "joined" => new GuildLogEntryJoined() { Id = entity.LogEntryId, Time = entity.Time, User = entity.User },
        "invited" => new GuildLogEntryInvited() { Id = entity.LogEntryId, Time = entity.Time, User = entity.User, InvitedBy = entity.InvitedBy ?? string.Empty },
        "kick" => new GuildLogEntryKick() { Id = entity.LogEntryId, Time = entity.Time, User = entity.User, KickedBy = entity.KickedBy ?? string.Empty },
        "rank_change" => new GuildLogEntryRankChange()
        {
            Id = entity.LogEntryId,
            Time = entity.Time,
            User = entity.User,
            ChangedBy = entity.ChangedBy ?? string.Empty,
            OldRank = entity.OldRank ?? string.Empty,
            NewRank = entity.NewRank ?? string.Empty
        },
        "treasury" => new GuildLogEntryTreasury() { Id = entity.LogEntryId, Time = entity.Time, User = entity.User, ItemId = entity.ItemId ?? 0, Count = entity.Count ?? 0 },
        "stash" => new GuildLogEntryStash()
        {
            Id = entity.LogEntryId,
            Time = entity.Time,
            User = entity.User,
            Operation = entity.Operation ?? string.Empty,
            ItemId = entity.ItemId,
            Count = entity.Count,
            Coins = entity.Coins
        },
        "motd" => new GuildLogEntryMotd() { Id = entity.LogEntryId, Time = entity.Time, User = entity.User, Motd = entity.Motd ?? string.Empty },
        "upgrade" => new GuildLogEntryUpgrade()
        {
            Id = entity.LogEntryId,
            Time = entity.Time,
            User = entity.User,
            Action = entity.Action ?? string.Empty,
            UpgradeId = entity.UpgradeId ?? 0,
            RecipeId = entity.RecipeId,
            ItemId = entity.ItemId,
            Count = entity.Count
        },
        "influence" => new GuildLogEntryInfluence()
        {
            Id = entity.LogEntryId,
            Time = entity.Time,
            User = entity.User,
            Activity = entity.Activity ?? string.Empty,
            TotalParticipants = entity.TotalParticipants ?? 0,
            Participants = participantEntities.OrderBy(participant => participant.OrderIndex).Select(participant => participant.Participant).ToArray()
        },
        "mission" => new GuildLogEntryMission() { Id = entity.LogEntryId, Time = entity.Time, User = entity.User, State = entity.State ?? string.Empty, Influence = entity.Influence },
        _ => throw new NotSupportedException($"Unknown guild log entry type: {entity.Type}")
    };
}
