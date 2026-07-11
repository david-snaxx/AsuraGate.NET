using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Guild"/> to <see cref="GuildEntity"/>.
/// </summary>
public static class GuildMapper
{
    public static GuildEntity ToEntity(Guild guild) => new GuildEntity()
    {
        Id = guild.Id,
        Name = guild.Name,
        Tag = guild.Tag,
        EmblemBackgroundId = guild.Emblem?.Background.Id,
        EmblemForegroundId = guild.Emblem?.Foreground.Id,
        Level = guild.Level,
        Motd = guild.Motd,
        Influence = guild.Influence,
        Aetherium = guild.Aetherium,
        Favor = guild.Favor,
        Resonance = guild.Resonance,
        MemberCount = guild.MemberCount,
        MemberCapacity = guild.MemberCapacity,
    };

    public static IReadOnlyList<GuildEmblemFlagEntity> ToEmblemFlagEntities(Guild guild) =>
        (guild.Emblem?.Flags ?? []).Select(flag => new GuildEmblemFlagEntity() { GuildId = guild.Id, Flag = flag }).ToList();

    public static IReadOnlyList<GuildEmblemColorEntity> ToEmblemColorEntities(Guild guild)
    {
        if (guild.Emblem is null) return [];
        return guild.Emblem.Background.Colors.Select((dyeId, index) => new GuildEmblemColorEntity() { GuildId = guild.Id, Layer = "Background", OrderIndex = index, DyeId = dyeId })
            .Concat(guild.Emblem.Foreground.Colors.Select((dyeId, index) => new GuildEmblemColorEntity() { GuildId = guild.Id, Layer = "Foreground", OrderIndex = index, DyeId = dyeId }))
            .ToList();
    }

    public static Guild ToModel(GuildEntity entity, IEnumerable<string> emblemFlags, IEnumerable<GuildEmblemColorEntity> emblemColors)
    {
        GuildEmblem? emblem = null;
        if (entity.EmblemBackgroundId is not null && entity.EmblemForegroundId is not null)
        {
            var colors = emblemColors.ToList();
            emblem = new GuildEmblem()
            {
                Background = new EmblemLayer()
                {
                    Id = entity.EmblemBackgroundId.Value,
                    Colors = colors.Where(c => c.Layer == "Background").OrderBy(c => c.OrderIndex).Select(c => c.DyeId).ToArray(),
                },
                Foreground = new EmblemLayer()
                {
                    Id = entity.EmblemForegroundId.Value,
                    Colors = colors.Where(c => c.Layer == "Foreground").OrderBy(c => c.OrderIndex).Select(c => c.DyeId).ToArray(),
                },
                Flags = emblemFlags.ToArray(),
            };
        }

        return new Guild()
        {
            Id = entity.Id,
            Name = entity.Name,
            Tag = entity.Tag,
            Emblem = emblem,
            Level = entity.Level,
            Motd = entity.Motd,
            Influence = entity.Influence,
            Aetherium = entity.Aetherium,
            Favor = entity.Favor,
            Resonance = entity.Resonance,
            MemberCount = entity.MemberCount,
            MemberCapacity = entity.MemberCapacity,
        };
    }
}
