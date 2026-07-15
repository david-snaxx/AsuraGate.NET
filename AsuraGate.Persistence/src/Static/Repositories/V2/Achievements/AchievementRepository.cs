using AsuraGate.Persistence.Entities.V2.Achievements;
using AsuraGate.Persistence.Mappers.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Repositories.V2.Achievements;

public class AchievementRepository : StaticRepository<Achievement, AchievementEntity, int>
{
    public AchievementRepository(Gw2ApiPersistenceDatabase database)
        : base(database, AchievementMapper.ToEntity, AchievementMapper.ToModel)
    {
    }
}
