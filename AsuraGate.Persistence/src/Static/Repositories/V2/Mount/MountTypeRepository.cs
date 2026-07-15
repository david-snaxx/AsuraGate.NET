using AsuraGate.Persistence.Static.Entities.V2.Mount;
using AsuraGate.Persistence.Static.Mappers.V2.Mount;
using AsuraGate.Spec.Models.V2.Mount;

namespace AsuraGate.Persistence.Static.Repositories.V2.Mount;

public class MountTypeRepository : StaticRepository<MountType, MountTypeEntity, string>
{
    public MountTypeRepository(Gw2ApiPersistenceDatabase database)
        : base(database, MountTypeMapper.ToEntity, MountTypeMapper.ToModel)
    {
    }
}
