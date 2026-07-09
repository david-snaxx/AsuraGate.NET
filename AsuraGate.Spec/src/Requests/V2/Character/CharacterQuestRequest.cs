using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Character;

public class CharacterQuestRequest :
    IGetsIds<int>
{
    public string EndpointUrl { get; }
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
    
    public CharacterQuestRequest(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName))
            throw new ArgumentException("Character name cannot be null or empty.", nameof(characterName));
        EndpointUrl = Gw2ApiEndpointUrl.CharactersQuests.Replace("{id}", Uri.EscapeDataString(characterName));
    }
}
