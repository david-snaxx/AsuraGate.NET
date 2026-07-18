using AsuraGate.Persistence.Static.Entities.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Persistence.Static.Repositories.V2.Guild;

public class GuildPermissionRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<GuildPermission, GuildPermissionEntity, string>(database, model => model.Id);
