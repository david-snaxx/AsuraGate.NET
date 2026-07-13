using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.Spec.Requests.V2.Achievements;
using AsuraGate.StaticCache.Repositories.V2.Achievements;

namespace AsuraGate.Sync.Providers.V2.Achievements;

public class AchievementGroupProvider : Provider<AchievementGroup, string, AchievementGroupRepository, AchievementGroupRequest>
{
    public AchievementGroupProvider(AchievementGroupRepository repository, AchievementGroupRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
