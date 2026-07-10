using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Character;

public sealed class CharacterEquipmentTabRequest :
    IGetsSingle<CharacterEquipmentTab, int>,
    IGetsBulk<CharacterEquipmentTab, int>,
    IGetsAll<CharacterEquipmentTab>,
    IGetsIds<int>
{
    public string EndpointUrl { get; }
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
    
    public CharacterEquipmentTabRequest(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName))
            throw new ArgumentException("Character name cannot be null or empty.", nameof(characterName));
        EndpointUrl = Gw2ApiEndpointUrl.CharactersEquipmentTab.Replace("{id}", Uri.EscapeDataString(characterName));
    }
}
