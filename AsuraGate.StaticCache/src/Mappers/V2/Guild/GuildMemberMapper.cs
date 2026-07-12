using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities.V2.Guild;

namespace AsuraGate.StaticCache.Mappers.V2.Guild;

public static class GuildMemberMapper
{
    public static GuildMemberEntity ToEntity(string guildId, GuildMember member) => new GuildMemberEntity()
    {
        GuildId = guildId,
        Name = member.Name,
        Rank = member.Rank,
        Joined = member.Joined,
        WvwMember = member.WvwMember
    };

    public static GuildMember ToModel(GuildMemberEntity entity) => new GuildMember()
    {
        Name = entity.Name,
        Rank = entity.Rank,
        Joined = entity.Joined,
        WvwMember = entity.WvwMember
    };
}
