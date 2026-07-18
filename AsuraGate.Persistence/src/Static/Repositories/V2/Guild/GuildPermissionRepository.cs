using AsuraGate.Persistence.Static.Entities.V2.Guild;
using AsuraGate.Persistence.Static.Mappers.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Persistence.Static.Repositories.V2.Guild;

public class GuildPermissionRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<GuildPermission, GuildPermissionEntity, string>(
        database, GuildPermissionMapper.ToEntity, GuildPermissionMapper.ToModel);
