using AsuraGate.Persistence.Static.Entities.V2.Achievements;
using AsuraGate.Persistence.Static.Mappers.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Static.Repositories.V2.Achievements;

public class AchievementCategoryRepository : StaticRepository<AchievementCategory, AchievementCategoryEntity, int>
{
    public AchievementCategoryRepository(Gw2ApiPersistenceDatabase database)
        : base(database, AchievementCategoryMapper.ToEntity, AchievementCategoryMapper.ToModel)
    {
    }
}
