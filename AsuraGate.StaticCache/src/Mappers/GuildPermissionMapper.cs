using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="GuildPermission"/> to <see cref="GuildPermissionEntity"/>.
/// </summary>
public static class GuildPermissionMapper
{
    public static GuildPermissionEntity ToEntity(GuildPermission permission) => new GuildPermissionEntity()
    {
        Id = permission.Id,
        Name = permission.Name,
        Description = permission.Description,
    };

    public static GuildPermission ToModel(GuildPermissionEntity entity) => new GuildPermission()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
    };
}
