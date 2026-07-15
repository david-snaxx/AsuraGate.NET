using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Pvp;
using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Static.Mappers.V2.Pvp;

public static class PvpRankMapper
{
    public static PvpRankEntity ToEntity(PvpRank model) => new PvpRankEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static PvpRank ToModel(PvpRankEntity entity) => JsonSerializer.Deserialize<PvpRank>(entity.Data)!;
}
