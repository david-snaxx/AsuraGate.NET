using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Persistence.Static.Mappers.V2.Guild;

public static class GuildPermissionMapper
{
    public static GuildPermissionEntity ToEntity(GuildPermission model) => new GuildPermissionEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static GuildPermission ToModel(GuildPermissionEntity entity) => JsonSerializer.Deserialize<GuildPermission>(entity.Data)!;
}
