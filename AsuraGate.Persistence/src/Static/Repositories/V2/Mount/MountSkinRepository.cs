using AsuraGate.Persistence.Static.Entities.V2.Mount;
using AsuraGate.Persistence.Static.Mappers.V2.Mount;
using AsuraGate.Spec.Models.V2.Mount;

namespace AsuraGate.Persistence.Static.Repositories.V2.Mount;

public class MountSkinRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<MountSkin, MountSkinEntity, int>(
        database, MountSkinMapper.ToEntity, MountSkinMapper.ToModel);
