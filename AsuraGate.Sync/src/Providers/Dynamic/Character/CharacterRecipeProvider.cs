using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Character.V2;
using AsuraGate.Spec.Requests.V2.Character;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Character;

public class CharacterRecipeProvider(CharacterRecipeRepository repository, CharacterRecipesRequest request, Gw2ApiGateway gateway, string key, ILogger? logger = null)
    : KeyedIdListSnapshotProvider<int, CharacterRecipeRepository, CharacterRecipesRequest>(repository, request, gateway, key, logger);
