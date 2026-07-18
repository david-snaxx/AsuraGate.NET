using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Spec.Requests.V2.Character;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Character;

public class CharacterInventoryProvider(CharacterInventoryRepository repository, CharacterInventoryRequest request, Gw2ApiGateway gateway, string key, ILogger? logger = null)
    : KeyedSnapshotProvider<CharacterInventory, CharacterInventoryRepository, CharacterInventoryRequest>(repository, request, gateway, key, logger);
