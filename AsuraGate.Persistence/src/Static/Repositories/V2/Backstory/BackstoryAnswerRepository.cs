using AsuraGate.Persistence.Static.Entities.V2.Backstory;
using AsuraGate.Persistence.Static.Mappers.V2.Backstory;
using AsuraGate.Spec.Models.V2.Backstory;

namespace AsuraGate.Persistence.Static.Repositories.V2.Backstory;

public class BackstoryAnswerRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<BackstoryAnswer, BackstoryAnswerEntity, string>(
        database, BackstoryAnswerMapper.ToEntity, BackstoryAnswerMapper.ToModel);
