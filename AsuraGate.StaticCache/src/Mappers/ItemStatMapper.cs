using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="ItemStat"/> to <see cref="ItemStatEntity"/>.
/// </summary>
public static class ItemStatMapper
{
    public static ItemStatEntity ToEntity(ItemStat itemStat) => new ItemStatEntity()
    {
        Id = itemStat.Id,
        Name = itemStat.Name,
    };

    public static IReadOnlyList<ItemStatAttributeEntity> ToAttributeEntities(ItemStat itemStat) =>
        itemStat.Attributes.Select(attribute => new ItemStatAttributeEntity()
        {
            ItemStatId = itemStat.Id,
            Attribute = attribute.Attribute,
            Multiplier = attribute.Multiplier,
            Value = attribute.Value,
        }).ToList();

    public static StatAttribute ToAttributeModel(ItemStatAttributeEntity entity) => new StatAttribute()
    {
        Attribute = entity.Attribute,
        Multiplier = entity.Multiplier,
        Value = entity.Value,
    };

    public static ItemStat ToModel(ItemStatEntity entity, IEnumerable<StatAttribute> attributes) => new ItemStat()
    {
        Id = entity.Id,
        Name = entity.Name,
        Attributes = attributes.ToArray(),
    };
}
