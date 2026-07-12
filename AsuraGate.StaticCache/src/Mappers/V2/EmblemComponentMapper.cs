using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class EmblemComponentMapper
{
    public static EmblemComponentEntity ToEmblemComponentEntity(EmblemComponent emblemComponent) => new EmblemComponentEntity()
    {
        Id = emblemComponent.Id
    };

    public static IEnumerable<EmblemComponentLayerEntity> ToLayerEntities(EmblemComponent emblemComponent) =>
        emblemComponent.Layers.Select((layer, index) => new EmblemComponentLayerEntity()
        {
            EmblemComponentId = emblemComponent.Id,
            OrderIndex = index,
            Layer = layer
        });

    public static EmblemComponent ToModel(EmblemComponentEntity entity, IEnumerable<EmblemComponentLayerEntity> layerEntities) => new EmblemComponent()
    {
        Id = entity.Id,
        Layers = layerEntities.OrderBy(layer => layer.OrderIndex).Select(layer => layer.Layer).ToArray()
    };
}
