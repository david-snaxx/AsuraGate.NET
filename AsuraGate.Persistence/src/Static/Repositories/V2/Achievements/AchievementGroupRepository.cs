using AsuraGate.Persistence.Static.Entities.V2.Achievements;
using AsuraGate.Persistence.Static.Mappers.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Static.Repositories.V2.Achievements;

public class AchievementGroupRepository : StaticRepository<AchievementGroup, AchievementGroupEntity, string>
{
    public AchievementGroupRepository(Gw2ApiPersistenceDatabase database)
        : base(database, AchievementGroupMapper.ToEntity, AchievementGroupMapper.ToModel)
    {
    }
}
