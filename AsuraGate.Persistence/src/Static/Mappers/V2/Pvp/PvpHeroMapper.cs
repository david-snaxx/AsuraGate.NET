using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Pvp;
using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Static.Mappers.V2.Pvp;

public static class PvpHeroMapper
{
    public static PvpHeroEntity ToEntity(PvpHero model) => new PvpHeroEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static PvpHero ToModel(PvpHeroEntity entity) => JsonSerializer.Deserialize<PvpHero>(entity.Data)!;
}
