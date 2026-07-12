using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class ItemStatMapper
{
    public static ItemStatEntity ToItemStatEntity(ItemStat itemStat) => new ItemStatEntity()
    {
        Id = itemStat.Id,
        Name = itemStat.Name
    };

    public static IEnumerable<ItemStatAttributeEntity> ToAttributeEntities(ItemStat itemStat) =>
        itemStat.Attributes.Select(attribute => new ItemStatAttributeEntity()
        {
            ItemStatId = itemStat.Id,
            Attribute = attribute.Attribute,
            Multiplier = attribute.Multiplier,
            Value = attribute.Value
        });

    public static ItemStat ToModel(ItemStatEntity entity, IEnumerable<ItemStatAttributeEntity> attributeEntities) => new ItemStat()
    {
        Id = entity.Id,
        Name = entity.Name,
        Attributes = attributeEntities.Select(attribute => new StatAttribute()
        {
            Attribute = attribute.Attribute,
            Multiplier = attribute.Multiplier,
            Value = attribute.Value
        }).ToArray()
    };
}
