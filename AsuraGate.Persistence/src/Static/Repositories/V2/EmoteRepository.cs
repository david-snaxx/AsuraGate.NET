using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class EmoteRepository : StaticRepository<Emote, EmoteEntity, string>
{
    public EmoteRepository(Gw2ApiPersistenceDatabase database)
        : base(database, EmoteMapper.ToEntity, EmoteMapper.ToModel)
    {
    }
}
