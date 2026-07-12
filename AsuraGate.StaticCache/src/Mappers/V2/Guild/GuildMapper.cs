using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities.V2.Guild;

namespace AsuraGate.StaticCache.Mappers.V2.Guild;

public static class GuildMapper
{
    public static GuildEntity ToGuildEntity(Spec.Models.V2.Guild.Guild guild) => new GuildEntity()
    {
        Id = guild.Id,
        Name = guild.Name,
        Tag = guild.Tag,
        HasEmblem = guild.Emblem is not null,
        EmblemBackgroundId = guild.Emblem?.Background.Id,
        EmblemForegroundId = guild.Emblem?.Foreground.Id,
        Level = guild.Level,
        Motd = guild.Motd,
        Influence = guild.Influence,
        Aetherium = guild.Aetherium,
        Favor = guild.Favor,
        Resonance = guild.Resonance,
        MemberCount = guild.MemberCount,
        MemberCapacity = guild.MemberCapacity
    };

    public static IEnumerable<GuildEmblemFlagEntity> ToEmblemFlagEntities(Spec.Models.V2.Guild.Guild guild) =>
        (guild.Emblem?.Flags ?? []).Select(flag => new GuildEmblemFlagEntity() { GuildId = guild.Id, Flag = flag });

    public static IEnumerable<GuildEmblemLayerColorEntity> ToEmblemLayerColorEntities(Spec.Models.V2.Guild.Guild guild)
    {
        if (guild.Emblem is null)
        {
            return [];
        }

        var background = guild.Emblem.Background.Colors.Select((colorId, index) => new GuildEmblemLayerColorEntity()
        {
            GuildId = guild.Id,
            IsForeground = false,
            OrderIndex = index,
            ColorId = colorId
        });

        var foreground = guild.Emblem.Foreground.Colors.Select((colorId, index) => new GuildEmblemLayerColorEntity()
        {
            GuildId = guild.Id,
            IsForeground = true,
            OrderIndex = index,
            ColorId = colorId
        });

        return background.Concat(foreground);
    }

    public static Spec.Models.V2.Guild.Guild ToModel(
        GuildEntity entity,
        IEnumerable<GuildEmblemFlagEntity> emblemFlagEntities,
        IEnumerable<GuildEmblemLayerColorEntity> emblemLayerColorEntities)
    {
        GuildEmblem? emblem = null;
        if (entity.HasEmblem)
        {
            var colors = emblemLayerColorEntities.ToList();
            emblem = new GuildEmblem()
            {
                Background = new EmblemLayer()
                {
                    Id = entity.EmblemBackgroundId ?? 0,
                    Colors = colors.Where(color => !color.IsForeground).OrderBy(color => color.OrderIndex).Select(color => color.ColorId).ToArray()
                },
                Foreground = new EmblemLayer()
                {
                    Id = entity.EmblemForegroundId ?? 0,
                    Colors = colors.Where(color => color.IsForeground).OrderBy(color => color.OrderIndex).Select(color => color.ColorId).ToArray()
                },
                Flags = emblemFlagEntities.Select(flag => flag.Flag).ToArray()
            };
        }

        return new Spec.Models.V2.Guild.Guild()
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
            MemberCapacity = entity.MemberCapacity
        };
    }
}
