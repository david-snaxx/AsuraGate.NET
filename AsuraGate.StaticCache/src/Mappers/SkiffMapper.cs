using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Skiff"/> to <see cref="SkiffEntity"/>.
/// </summary>
public static class SkiffMapper
{
    public static SkiffEntity ToEntity(Skiff skiff) => new SkiffEntity()
    {
        Id = skiff.Id,
        Name = skiff.Name,
        Icon = skiff.Icon,
    };

    public static IReadOnlyList<SkiffDyeSlotEntity> ToDyeSlotEntities(Skiff skiff) =>
        skiff.DyeSlots.Select((slot, index) => new SkiffDyeSlotEntity()
        {
            SkiffId = skiff.Id,
            OrderIndex = index,
            DefaultColorId = slot.Default?.ColorId,
            DefaultMaterial = slot.Default?.Material,
        }).ToList();

    public static SkiffDyeSlot ToDyeSlotModel(SkiffDyeSlotEntity entity) => new SkiffDyeSlot()
    {
        Default = entity.DefaultColorId is null ? null : new SkiffDyeSlotDefault()
        {
            ColorId = entity.DefaultColorId.Value,
            Material = entity.DefaultMaterial ?? string.Empty,
        },
    };

    public static Skiff ToModel(SkiffEntity entity, IEnumerable<SkiffDyeSlotEntity> dyeSlots) => new Skiff()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        DyeSlots = dyeSlots.OrderBy(s => s.OrderIndex).Select(ToDyeSlotModel).ToArray(),
    };
}
