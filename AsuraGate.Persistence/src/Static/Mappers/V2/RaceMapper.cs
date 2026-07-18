using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class RaceMapper
{
    public static RaceEntity ToEntity(Race model) => new RaceEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Race? ToModel(RaceEntity entity) => MapperUtils.DeserializeJson<Race>(entity.Data);
}
