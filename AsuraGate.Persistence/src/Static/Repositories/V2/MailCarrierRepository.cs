using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class MailCarrierRepository : StaticRepository<MailCarrier, MailCarrierEntity, int>
{
    public MailCarrierRepository(Gw2ApiPersistenceDatabase database)
        : base(database, MailCarrierMapper.ToEntity, MailCarrierMapper.ToModel)
    {
    }
}
