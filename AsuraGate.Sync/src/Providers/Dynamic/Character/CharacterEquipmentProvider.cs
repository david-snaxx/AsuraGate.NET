using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Spec.Requests.V2.Character;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Character;

public class CharacterEquipmentProvider(CharacterEquipmentRepository repository, CharacterEquipmentRequest request, Gw2ApiGateway gateway, string key, ILogger? logger = null)
    : KeyedSnapshotProvider<CharacterEquipment, CharacterEquipmentRepository, CharacterEquipmentRequest>(repository, request, gateway, key, logger);
