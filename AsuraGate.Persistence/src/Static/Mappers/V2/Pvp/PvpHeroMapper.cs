using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Static.Mappers.V2.Pvp;

public static class PvpHeroMapper
{
    public static PvpHeroEntity ToEntity(PvpHero model) => new PvpHeroEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static PvpHero? ToModel(PvpHeroEntity entity) => MapperUtils.DeserializeJson<PvpHero>(entity.Data);
}
