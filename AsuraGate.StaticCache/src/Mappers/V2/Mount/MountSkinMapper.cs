using AsuraGate.Spec.Models.V2.Mount;
using AsuraGate.StaticCache.Entities.V2.Mount;

namespace AsuraGate.StaticCache.Mappers.V2.Mount;

public static class MountSkinMapper
{
    public static MountSkinEntity ToMountSkinEntity(MountSkin mountSkin) => new MountSkinEntity()
    {
        Id = mountSkin.Id,
        Name = mountSkin.Name,
        Icon = mountSkin.Icon,
        Mount = mountSkin.Mount,
        MountGuid = mountSkin.MountGuid
    };

    public static IEnumerable<MountSkinDyeSlotEntity> ToDyeSlotEntities(MountSkin mountSkin) =>
        mountSkin.DyeSlots.Select((slot, index) => new MountSkinDyeSlotEntity()
        {
            MountSkinId = mountSkin.Id,
            OrderIndex = index,
            ColorId = slot.ColorId,
            Material = slot.Material
        });

    public static MountSkin ToModel(MountSkinEntity entity, IEnumerable<MountSkinDyeSlotEntity> dyeSlotEntities) => new MountSkin()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        DyeSlots = dyeSlotEntities.OrderBy(slot => slot.OrderIndex).Select(slot => new MountDyeSlot()
        {
            ColorId = slot.ColorId,
            Material = slot.Material
        }).ToArray(),
        Mount = entity.Mount,
        MountGuid = entity.MountGuid
    };
}
