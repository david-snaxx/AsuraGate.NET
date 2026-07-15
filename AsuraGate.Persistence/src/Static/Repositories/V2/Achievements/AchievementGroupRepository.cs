using AsuraGate.Persistence.Entities.V2.Achievements;
using AsuraGate.Persistence.Mappers.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Repositories.V2.Achievements;

public class AchievementGroupRepository : StaticRepository<AchievementGroup, AchievementGroupEntity, string>
{
    public AchievementGroupRepository(Gw2ApiPersistenceDatabase database)
        : base(database, AchievementGroupMapper.ToEntity, AchievementGroupMapper.ToModel)
    {
    }
}
