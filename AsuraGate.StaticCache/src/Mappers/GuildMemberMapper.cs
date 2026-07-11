using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildMember"/> to <see cref="GuildMemberEntity"/>.
/// </summary>
public static class GuildMemberMapper
{
    public static GuildMemberEntity ToEntity(GuildMember member, string guildId) => new GuildMemberEntity()
    {
        GuildId = guildId,
        Name = member.Name,
        Rank = member.Rank,
        Joined = member.Joined,
        WvwMember = member.WvwMember,
    };

    public static GuildMember ToModel(GuildMemberEntity entity) => new GuildMember()
    {
        Name = entity.Name,
        Rank = entity.Rank,
        Joined = entity.Joined,
        WvwMember = entity.WvwMember,
    };
}
