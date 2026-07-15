using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Wvw;
using AsuraGate.Persistence.Static.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Static.Mappers.V2.Wvw;

public static class WvwUpgradeMapper
{
    public static WvwUpgradeEntity ToEntity(WvwUpgrade model) => new WvwUpgradeEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static WvwUpgrade ToModel(WvwUpgradeEntity entity) => JsonSerializer.Deserialize<WvwUpgrade>(entity.Data)!;
}
