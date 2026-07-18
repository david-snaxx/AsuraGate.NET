using AsuraGate.Persistence.Static.Entities.V2.Mount;
using AsuraGate.Spec.Models.V2.Mount;

namespace AsuraGate.Persistence.Static.Repositories.V2.Mount;

public class MountTypeRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<MountType, MountTypeEntity, string>(database, model => model.Id);
