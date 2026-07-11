using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildStorageItem"/> to <see cref="GuildStorageItemEntity"/>.
/// </summary>
public static class GuildStorageItemMapper
{
    public static GuildStorageItemEntity ToEntity(GuildStorageItem item, string guildId) => new GuildStorageItemEntity()
    {
        GuildId = guildId,
        ItemId = item.Id,
        Count = item.Count,
    };

    public static GuildStorageItem ToModel(GuildStorageItemEntity entity) => new GuildStorageItem()
    {
        Id = entity.ItemId,
        Count = entity.Count,
    };
}
