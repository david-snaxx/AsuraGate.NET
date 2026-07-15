using AsuraGate.Persistence.Static.Entities.V2.Backstory;
using AsuraGate.Persistence.Static.Mappers.V2.Backstory;
using AsuraGate.Spec.Models.V2.Backstory;

namespace AsuraGate.Persistence.Static.Repositories.V2.Backstory;

public class BackstoryQuestionRepository : StaticRepository<BackstoryQuestion, BackstoryQuestionEntity, int>
{
    public BackstoryQuestionRepository(Gw2ApiPersistenceDatabase database)
        : base(database, BackstoryQuestionMapper.ToEntity, BackstoryQuestionMapper.ToModel)
    {
    }
}
