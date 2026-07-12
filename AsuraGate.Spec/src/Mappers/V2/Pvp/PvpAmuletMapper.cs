using AsuraGate.Spec.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Spec.Mappers.V2.Pvp;

public static class PvpAmuletMapper
{
    public static PvpAmuletEntity ToPvpAmuletEntity(PvpAmulet amulet) => new PvpAmuletEntity()
    {
        Id = amulet.Id,
        Name = amulet.Name,
        Icon = amulet.Icon
    };

    public static IEnumerable<PvpAmuletAttributeEntity> ToAttributeEntities(PvpAmulet amulet) =>
        amulet.Attributes.Select(pair => new PvpAmuletAttributeEntity() { PvpAmuletId = amulet.Id, Attribute = pair.Key, Value = pair.Value });

    public static PvpAmulet ToModel(PvpAmuletEntity entity, IEnumerable<PvpAmuletAttributeEntity> attributeEntities) => new PvpAmulet()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        Attributes = attributeEntities.ToDictionary(attribute => attribute.Attribute, attribute => attribute.Value)
    };
}
