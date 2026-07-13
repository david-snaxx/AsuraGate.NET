using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.Spec.Requests.V2.Achievements;
using AsuraGate.StaticCache.Repositories.V2.Achievements;

namespace AsuraGate.Sync.Providers.V2.Achievements;

public class AchievementCategoryProvider : Provider<AchievementCategory, int, AchievementCategoryRepository, AchievementCategoryRequest>
{
    public AchievementCategoryProvider(AchievementCategoryRepository repository, AchievementCategoryRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
