using AsuraGate.Spec.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Spec.Mappers.V2.Guild;

public static class GuildStashSectionMapper
{
    public static GuildStashSectionEntity ToEntity(string guildId, int sectionOrderIndex, GuildStashSection section) => new GuildStashSectionEntity()
    {
        GuildId = guildId,
        OrderIndex = sectionOrderIndex,
        UpgradeId = section.UpgradeId,
        Size = section.Size,
        Coins = section.Coins,
        Note = section.Note
    };

    public static IEnumerable<GuildStashItemEntity> ToItemEntities(string guildId, int sectionOrderIndex, GuildStashSection section) =>
        section.Inventory.Select((slot, index) => new GuildStashItemEntity()
        {
            GuildId = guildId,
            SectionOrderIndex = sectionOrderIndex,
            SlotIndex = index,
            ItemId = slot?.Id,
            Count = slot?.Count
        });

    public static GuildStashSection ToModel(GuildStashSectionEntity entity, IEnumerable<GuildStashItemEntity> itemEntities) => new GuildStashSection()
    {
        UpgradeId = entity.UpgradeId,
        Size = entity.Size,
        Coins = entity.Coins,
        Note = entity.Note,
        Inventory = itemEntities.OrderBy(item => item.SlotIndex).Select(item =>
            item.ItemId is null ? null : new GuildStashItem() { Id = item.ItemId.Value, Count = item.Count ?? 0 }).ToArray()
    };
}
