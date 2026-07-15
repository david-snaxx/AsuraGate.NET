using AsuraGate.Persistence.Entities.V2.Guild;
using AsuraGate.Persistence.Mappers.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Persistence.Repositories.V2.Guild;

public class GuildPermissionRepository : StaticRepository<GuildPermission, GuildPermissionEntity, string>
{
    public GuildPermissionRepository(Gw2ApiPersistenceDatabase database)
        : base(database, GuildPermissionMapper.ToEntity, GuildPermissionMapper.ToModel)
    {
    }
}
