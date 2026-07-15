using AsuraGate.Persistence.Entities.V2.Wvw;
using AsuraGate.Persistence.Mappers.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Repositories.V2.Wvw;

public class WvwAbilityRepository : StaticRepository<WvwAbility, WvwAbilityEntity, int>
{
    public WvwAbilityRepository(Gw2ApiPersistenceDatabase database)
        : base(database, WvwAbilityMapper.ToEntity, WvwAbilityMapper.ToModel)
    {
    }
}
