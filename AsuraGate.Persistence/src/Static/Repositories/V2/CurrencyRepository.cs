using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class CurrencyRepository : StaticRepository<Currency, CurrencyEntity, int>
{
    public CurrencyRepository(Gw2ApiPersistenceDatabase database)
        : base(database, CurrencyMapper.ToEntity, CurrencyMapper.ToModel)
    {
    }
}
