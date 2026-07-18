using AsuraGate.Persistence.Static.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Static.Repositories.V2.Achievements;

public class AchievementGroupRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<AchievementGroup, AchievementGroupEntity, string>(database, model => model.Id);
