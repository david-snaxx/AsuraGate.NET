using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Glider"/> to <see cref="GliderEntity"/>.
/// </summary>
public static class GliderMapper
{
    public static GliderEntity ToEntity(Glider glider) => new GliderEntity()
    {
        Id = glider.Id,
        Name = glider.Name,
        Description = glider.Description,
        Icon = glider.Icon,
        Order = glider.Order,
    };

    public static IReadOnlyList<GliderUnlockItemEntity> ToUnlockItemEntities(Glider glider) =>
        glider.UnlockItems.Select(itemId => new GliderUnlockItemEntity() { GliderId = glider.Id, ItemId = itemId }).ToList();

    public static IReadOnlyList<GliderDefaultDyeEntity> ToDefaultDyeEntities(Glider glider) =>
        glider.DefaultDyes.Select((dyeId, index) => new GliderDefaultDyeEntity() { GliderId = glider.Id, OrderIndex = index, DyeId = dyeId }).ToList();

    public static Glider ToModel(GliderEntity entity, IEnumerable<int> unlockItems, IEnumerable<GliderDefaultDyeEntity> defaultDyes) => new Glider()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Order = entity.Order,
        UnlockItems = unlockItems.ToArray(),
        DefaultDyes = defaultDyes.OrderBy(d => d.OrderIndex).Select(d => d.DyeId).ToArray(),
    };
}
