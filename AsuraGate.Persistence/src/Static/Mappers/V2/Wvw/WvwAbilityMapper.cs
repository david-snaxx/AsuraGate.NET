using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Wvw;
using AsuraGate.Persistence.Static.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Static.Mappers.V2.Wvw;

public static class WvwAbilityMapper
{
    public static WvwAbilityEntity ToEntity(WvwAbility model) => new WvwAbilityEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static WvwAbility ToModel(WvwAbilityEntity entity) => JsonSerializer.Deserialize<WvwAbility>(entity.Data)!;
}
