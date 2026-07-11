using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="EmblemComponent"/> to <see cref="EmblemComponentEntity"/>.
/// </summary>
public static class EmblemComponentMapper
{
    public static EmblemComponentEntity ToEntity(EmblemComponent component) => new EmblemComponentEntity()
    {
        Id = component.Id,
    };

    public static IReadOnlyList<EmblemComponentLayerEntity> ToLayerEntities(EmblemComponent component) =>
        component.Layers.Select((layer, index) => new EmblemComponentLayerEntity()
        {
            EmblemComponentId = component.Id,
            OrderIndex = index,
            LayerUrl = layer,
        }).ToList();

    public static EmblemComponent ToModel(EmblemComponentEntity entity, IEnumerable<EmblemComponentLayerEntity> layers) => new EmblemComponent()
    {
        Id = entity.Id,
        Layers = layers.OrderBy(l => l.OrderIndex).Select(l => l.LayerUrl).ToArray(),
    };
}
