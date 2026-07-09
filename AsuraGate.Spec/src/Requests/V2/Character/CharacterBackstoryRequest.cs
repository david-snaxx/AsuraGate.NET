using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Character;

public class CharacterBackstoryRequest :
    IGetsSingleNoId<CharacterBackstory>
{
    public string EndpointUrl { get; }
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
    
    public CharacterBackstoryRequest(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName))
            throw new ArgumentException("Character name cannot be null or empty.", nameof(characterName));
        EndpointUrl = Gw2ApiEndpointUrl.CharactersBackstory.Replace("{id}", Uri.EscapeDataString(characterName));
    }
}
