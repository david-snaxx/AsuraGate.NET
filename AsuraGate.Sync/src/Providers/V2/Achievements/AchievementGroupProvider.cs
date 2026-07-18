using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.Spec.Requests.V2.Achievements;
using AsuraGate.Persistence.Static.Repositories.V2.Achievements;

namespace AsuraGate.Sync.Providers.V2.Achievements;

public class AchievementGroupProvider(
    AchievementGroupRepository repository,
    AchievementGroupRequest request,
    Gw2ApiGateway gateway,
    StaticMetaRepository staticMetaRepository,
    ILogger? logger = null)
    : Provider<AchievementGroup, string, AchievementGroupRepository, AchievementGroupRequest>(repository, request,
        gateway, staticMetaRepository, logger);
