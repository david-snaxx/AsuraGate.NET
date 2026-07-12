using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities.V2.Guild;

namespace AsuraGate.StaticCache.Mappers.V2.Guild;

public static class GuildStorageItemMapper
{
    public static GuildStorageItemEntity ToEntity(string guildId, GuildStorageItem item) => new GuildStorageItemEntity()
    {
        GuildId = guildId,
        ItemId = item.Id,
        Count = item.Count
    };

    public static GuildStorageItem ToModel(GuildStorageItemEntity entity) => new GuildStorageItem()
    {
        Id = entity.ItemId,
        Count = entity.Count
    };
}
