using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class GliderMapper
{
    public static GliderEntity ToGliderEntity(Glider glider) => new GliderEntity()
    {
        Id = glider.Id,
        Name = glider.Name,
        Description = glider.Description,
        Icon = glider.Icon,
        Order = glider.Order
    };

    public static IEnumerable<GliderUnlockItemEntity> ToUnlockItemEntities(Glider glider) =>
        glider.UnlockItems.Select(itemId => new GliderUnlockItemEntity()
        {
            GliderId = glider.Id,
            ItemId = itemId
        });

    public static IEnumerable<GliderDefaultDyeEntity> ToDefaultDyeEntities(Glider glider) =>
        glider.DefaultDyes.Select((dyeId, index) => new GliderDefaultDyeEntity()
        {
            GliderId = glider.Id,
            OrderIndex = index,
            DyeId = dyeId
        });

    public static Glider ToModel(
        GliderEntity entity,
        IEnumerable<GliderUnlockItemEntity> unlockItemEntities,
        IEnumerable<GliderDefaultDyeEntity> defaultDyeEntities) => new Glider()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Order = entity.Order,
        UnlockItems = unlockItemEntities.Select(item => item.ItemId).ToArray(),
        DefaultDyes = defaultDyeEntities.OrderBy(dye => dye.OrderIndex).Select(dye => dye.DyeId).ToArray()
    };
}
