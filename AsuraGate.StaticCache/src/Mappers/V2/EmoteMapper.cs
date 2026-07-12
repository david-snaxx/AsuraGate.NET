using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class EmoteMapper
{
    public static EmoteEntity ToEmoteEntity(Emote emote) => new EmoteEntity()
    {
        Id = emote.Id
    };

    public static IEnumerable<EmoteCommandEntity> ToCommandEntities(Emote emote) =>
        emote.Commands.Select(command => new EmoteCommandEntity()
        {
            EmoteId = emote.Id,
            Command = command
        });

    public static IEnumerable<EmoteUnlockItemEntity> ToUnlockItemEntities(Emote emote) =>
        emote.UnlockItems.Select(itemId => new EmoteUnlockItemEntity()
        {
            EmoteId = emote.Id,
            ItemId = itemId
        });

    public static Emote ToModel(
        EmoteEntity entity,
        IEnumerable<EmoteCommandEntity> commandEntities,
        IEnumerable<EmoteUnlockItemEntity> unlockItemEntities) => new Emote()
    {
        Id = entity.Id,
        Commands = commandEntities.Select(command => command.Command).ToArray(),
        UnlockItems = unlockItemEntities.Select(item => item.ItemId).ToArray()
    };
}
