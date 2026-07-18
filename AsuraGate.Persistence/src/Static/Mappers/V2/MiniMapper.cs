using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class MiniMapper
{
    public static MiniEntity ToEntity(Mini model) => new MiniEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Mini? ToModel(MiniEntity entity) => MapperUtils.DeserializeJson<Mini>(entity.Data);
}
