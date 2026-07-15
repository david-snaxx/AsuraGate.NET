using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Mappers.V2.Pvp;

public static class PvpAmuletMapper
{
    public static PvpAmuletEntity ToEntity(PvpAmulet model) => new PvpAmuletEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static PvpAmulet ToModel(PvpAmuletEntity entity) => JsonSerializer.Deserialize<PvpAmulet>(entity.Data)!;
}
