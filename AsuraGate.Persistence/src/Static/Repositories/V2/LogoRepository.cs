using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class LogoRepository : StaticRepository<Logo, LogoEntity, string>
{
    public LogoRepository(Gw2ApiPersistenceDatabase database)
        : base(database, LogoMapper.ToEntity, LogoMapper.ToModel)
    {
    }
}
