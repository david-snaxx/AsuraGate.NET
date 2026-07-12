using AsuraGate.Spec.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Spec.Mappers.V2.Guild;

public static class GuildPermissionMapper
{
    public static GuildPermissionEntity ToGuildPermissionEntity(GuildPermission permission) => new GuildPermissionEntity()
    {
        Id = permission.Id,
        Name = permission.Name,
        Description = permission.Description
    };

    public static GuildPermission ToModel(GuildPermissionEntity entity) => new GuildPermission()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description
    };
}
