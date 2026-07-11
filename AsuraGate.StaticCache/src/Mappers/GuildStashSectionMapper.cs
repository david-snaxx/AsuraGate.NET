using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildStashSection"/> to <see cref="GuildStashSectionEntity"/>. Uses a DB-assigned id (not
/// provided by the API), so <see cref="ToSlotEntities"/> takes the already-persisted section id.
/// </summary>
public static class GuildStashSectionMapper
{
    public static GuildStashSectionEntity ToEntity(GuildStashSection section, string guildId, int orderIndex) => new GuildStashSectionEntity()
    {
        GuildId = guildId,
        OrderIndex = orderIndex,
        UpgradeId = section.UpgradeId,
        Size = section.Size,
        Coins = section.Coins,
        Note = section.Note,
    };

    public static IReadOnlyList<GuildStashSlotEntity> ToSlotEntities(GuildStashSection section, int guildStashSectionId) =>
        section.Inventory.Select((slot, index) => new GuildStashSlotEntity()
        {
            GuildStashSectionId = guildStashSectionId,
            SlotIndex = index,
            ItemId = slot?.Id,
            Count = slot?.Count,
        }).ToList();

    public static GuildStashSection ToModel(GuildStashSectionEntity entity, IEnumerable<GuildStashSlotEntity> slots) => new GuildStashSection()
    {
        UpgradeId = entity.UpgradeId,
        Size = entity.Size,
        Coins = entity.Coins,
        Note = entity.Note,
        Inventory = slots.OrderBy(s => s.SlotIndex)
            .Select(s => s.ItemId is null ? null : new GuildStashItem() { Id = s.ItemId.Value, Count = s.Count ?? 0 })
            .ToArray(),
    };
}
