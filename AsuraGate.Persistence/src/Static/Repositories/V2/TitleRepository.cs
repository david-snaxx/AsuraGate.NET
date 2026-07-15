using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class TitleRepository : StaticRepository<Title, TitleEntity, int>
{
    public TitleRepository(Gw2ApiPersistenceDatabase database)
        : base(database, TitleMapper.ToEntity, TitleMapper.ToModel)
    {
    }
}
