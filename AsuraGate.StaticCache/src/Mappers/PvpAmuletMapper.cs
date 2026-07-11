using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="PvpAmulet"/> to <see cref="PvpAmuletEntity"/>.
/// </summary>
public static class PvpAmuletMapper
{
    public static PvpAmuletEntity ToEntity(PvpAmulet amulet) => new PvpAmuletEntity()
    {
        Id = amulet.Id,
        Name = amulet.Name,
        Icon = amulet.Icon,
    };

    public static IReadOnlyList<PvpAmuletAttributeEntity> ToAttributeEntities(PvpAmulet amulet) =>
        amulet.Attributes.Select(kvp => new PvpAmuletAttributeEntity() { AmuletId = amulet.Id, Attribute = kvp.Key, Value = kvp.Value }).ToList();

    public static PvpAmulet ToModel(PvpAmuletEntity entity, IEnumerable<PvpAmuletAttributeEntity> attributes) => new PvpAmulet()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        Attributes = attributes.ToDictionary(a => a.Attribute, a => a.Value),
    };
}
