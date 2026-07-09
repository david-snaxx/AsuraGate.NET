using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Character;

public class CharacterBuildTabRequest :
    IGetsSingle<CommerceTransaction, int>,
    IGetsBulk<CommerceTransaction, int>,
    IGetsAll<CommerceTransaction>,
    IGetsIds<int>
{
    public string EndpointUrl { get; }
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
    
    public CharacterBuildTabRequest(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName))
            throw new ArgumentException("Character name cannot be null or empty.", nameof(characterName));
        EndpointUrl = Gw2ApiEndpointUrl.CharactersBuildTab.Replace("{id}", Uri.EscapeDataString(characterName));
    }
}
