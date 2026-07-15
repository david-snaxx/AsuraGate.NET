using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Persistence.Mappers.V2.Guild;

public static class GuildUpgradeMapper
{
    public static GuildUpgradeEntity ToEntity(GuildUpgrade model) => new GuildUpgradeEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static GuildUpgrade ToModel(GuildUpgradeEntity entity) => JsonSerializer.Deserialize<GuildUpgrade>(entity.Data)!;
}
