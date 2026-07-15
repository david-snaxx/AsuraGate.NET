using AsuraGate.Persistence.Static.Entities.V2.Guild;
using AsuraGate.Persistence.Static.Mappers.V2.Guild;
using AsuraGate.Spec.Models.V2.Guild;

namespace AsuraGate.Persistence.Static.Repositories.V2.Guild;

public class GuildUpgradeRepository : StaticRepository<GuildUpgrade, GuildUpgradeEntity, int>
{
    public GuildUpgradeRepository(Gw2ApiPersistenceDatabase database)
        : base(database, GuildUpgradeMapper.ToEntity, GuildUpgradeMapper.ToModel)
    {
    }
}
