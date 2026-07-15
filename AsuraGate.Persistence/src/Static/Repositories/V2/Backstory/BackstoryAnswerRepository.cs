using AsuraGate.Persistence.Entities.V2.Backstory;
using AsuraGate.Persistence.Mappers.V2.Backstory;
using AsuraGate.Spec.Models.V2.Backstory;

namespace AsuraGate.Persistence.Repositories.V2.Backstory;

public class BackstoryAnswerRepository : StaticRepository<BackstoryAnswer, BackstoryAnswerEntity, string>
{
    public BackstoryAnswerRepository(Gw2ApiPersistenceDatabase database)
        : base(database, BackstoryAnswerMapper.ToEntity, BackstoryAnswerMapper.ToModel)
    {
    }
}
