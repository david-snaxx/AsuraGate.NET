using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class SkillRepository : StaticRepository<Skill, SkillEntity, int>
{
    public SkillRepository(Gw2ApiPersistenceDatabase database)
        : base(database, SkillMapper.ToEntity, SkillMapper.ToModel)
    {
    }
}
