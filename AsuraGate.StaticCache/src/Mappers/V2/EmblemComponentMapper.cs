using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class EmblemComponentMapper
{
    public static EmblemComponentEntity ToEmblemComponentEntity(string slot, EmblemComponent emblemComponent) => new EmblemComponentEntity()
    {
        Slot = slot,
        ComponentId = emblemComponent.Id
    };

    public static IEnumerable<EmblemComponentLayerEntity> ToLayerEntities(string slot, EmblemComponent emblemComponent) =>
        emblemComponent.Layers.Select((layer, index) => new EmblemComponentLayerEntity()
        {
            Slot = slot,
            ComponentId = emblemComponent.Id,
            OrderIndex = index,
            Layer = layer
        });

    public static EmblemComponent ToModel(EmblemComponentEntity entity, IEnumerable<EmblemComponentLayerEntity> layerEntities) => new EmblemComponent()
    {
        Id = entity.ComponentId,
        Layers = layerEntities.OrderBy(layer => layer.OrderIndex).Select(layer => layer.Layer).ToArray()
    };
}
