using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Static.Mappers.V2.Pvp;

public static class PvpAmuletMapper
{
    public static PvpAmuletEntity ToEntity(PvpAmulet model) => new PvpAmuletEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static PvpAmulet? ToModel(PvpAmuletEntity entity) => MapperUtils.DeserializeJson<PvpAmulet>(entity.Data);
}
