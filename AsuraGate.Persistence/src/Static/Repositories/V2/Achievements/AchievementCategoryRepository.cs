using AsuraGate.Persistence.Static.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Persistence.Static.Repositories.V2.Achievements;

public class AchievementCategoryRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<AchievementCategory, AchievementCategoryEntity, int>(database, model => model.Id);
