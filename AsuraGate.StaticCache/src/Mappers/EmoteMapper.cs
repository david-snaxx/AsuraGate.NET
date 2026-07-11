using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Emote"/> to <see cref="EmoteEntity"/>.
/// </summary>
public static class EmoteMapper
{
    public static EmoteEntity ToEntity(Emote emote) => new EmoteEntity()
    {
        Id = emote.Id,
    };

    public static IReadOnlyList<EmoteCommandEntity> ToCommandEntities(Emote emote) =>
        emote.Commands.Select(command => new EmoteCommandEntity() { EmoteId = emote.Id, Command = command }).ToList();

    public static IReadOnlyList<EmoteUnlockItemEntity> ToUnlockItemEntities(Emote emote) =>
        emote.UnlockItems.Select(itemId => new EmoteUnlockItemEntity() { EmoteId = emote.Id, ItemId = itemId }).ToList();

    public static Emote ToModel(EmoteEntity entity, IEnumerable<string> commands, IEnumerable<int> unlockItems) => new Emote()
    {
        Id = entity.Id,
        Commands = commands.ToArray(),
        UnlockItems = unlockItems.ToArray(),
    };
}
