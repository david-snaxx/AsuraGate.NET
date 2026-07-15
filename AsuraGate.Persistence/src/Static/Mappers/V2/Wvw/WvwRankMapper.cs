using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Wvw;
using AsuraGate.Persistence.Static.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Static.Mappers.V2.Wvw;

public static class WvwRankMapper
{
    public static WvwRankEntity ToEntity(WvwRank model) => new WvwRankEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static WvwRank ToModel(WvwRankEntity entity) => JsonSerializer.Deserialize<WvwRank>(entity.Data)!;
}
