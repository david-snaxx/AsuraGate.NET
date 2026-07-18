using AsuraGate.Persistence.Static.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Persistence.Static.Mappers.V2.Guild;

public static class GuildUpgradeMapper
{
    public static GuildUpgradeEntity ToEntity(GuildUpgrade model) => new GuildUpgradeEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static GuildUpgrade? ToModel(GuildUpgradeEntity entity) => MapperUtils.DeserializeJson<GuildUpgrade>(entity.Data);
}
