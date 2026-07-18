using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class RaidMapper
{
    public static RaidEntity ToEntity(Raid model) => new RaidEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Raid? ToModel(RaidEntity entity) => MapperUtils.DeserializeJson<Raid>(entity.Data);
}
