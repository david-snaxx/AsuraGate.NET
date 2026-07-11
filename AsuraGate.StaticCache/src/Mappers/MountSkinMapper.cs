using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="MountSkin"/> to <see cref="MountSkinEntity"/>.
/// </summary>
public static class MountSkinMapper
{
    public static MountSkinEntity ToEntity(MountSkin skin) => new MountSkinEntity()
    {
        Id = skin.Id,
        Name = skin.Name,
        Icon = skin.Icon,
        Mount = skin.Mount,
        MountGuid = skin.MountGuid,
    };

    public static IReadOnlyList<MountSkinDyeSlotEntity> ToDyeSlotEntities(MountSkin skin) =>
        skin.DyeSlots.Select((slot, index) => new MountSkinDyeSlotEntity()
        {
            MountSkinId = skin.Id,
            OrderIndex = index,
            ColorId = slot.ColorId,
            Material = slot.Material,
        }).ToList();

    public static MountDyeSlot ToDyeSlotModel(MountSkinDyeSlotEntity entity) => new MountDyeSlot() { ColorId = entity.ColorId, Material = entity.Material };

    public static MountSkin ToModel(MountSkinEntity entity, IEnumerable<MountSkinDyeSlotEntity> dyeSlots) => new MountSkin()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        DyeSlots = dyeSlots.OrderBy(d => d.OrderIndex).Select(ToDyeSlotModel).ToArray(),
        Mount = entity.Mount,
        MountGuid = entity.MountGuid,
    };
}
