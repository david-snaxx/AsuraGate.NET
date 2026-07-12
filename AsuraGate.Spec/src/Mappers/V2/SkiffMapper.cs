using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class SkiffMapper
{
    public static SkiffEntity ToSkiffEntity(Skiff skiff) => new SkiffEntity()
    {
        Id = skiff.Id,
        Name = skiff.Name,
        Icon = skiff.Icon
    };

    public static IEnumerable<SkiffDyeSlotEntity> ToDyeSlotEntities(Skiff skiff) =>
        skiff.DyeSlots.Select((slot, index) => new SkiffDyeSlotEntity()
        {
            SkiffId = skiff.Id,
            OrderIndex = index,
            DefaultColorId = slot.Default?.ColorId,
            DefaultMaterial = slot.Default?.Material
        });

    public static Skiff ToModel(SkiffEntity entity, IEnumerable<SkiffDyeSlotEntity> dyeSlotEntities) => new Skiff()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        DyeSlots = dyeSlotEntities.OrderBy(slot => slot.OrderIndex).Select(slot => new SkiffDyeSlot()
        {
            Default = slot.DefaultColorId is null ? null : new SkiffDyeSlotDefault()
            {
                ColorId = slot.DefaultColorId.Value,
                Material = slot.DefaultMaterial!
            }
        }).ToArray()
    };
}
