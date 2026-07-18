using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Character.V2;
using AsuraGate.Spec.Requests.V2.Character;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Character;

public class CharacterHeroPointProvider(CharacterHeroPointRepository repository, CharacterHeroPointsRequest request, Gw2ApiGateway gateway, string key, ILogger? logger = null)
    : KeyedIdListSnapshotProvider<string, CharacterHeroPointRepository, CharacterHeroPointsRequest>(repository, request, gateway, key, logger);
