using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Character;

public class CharacterRecipesRequest :
    IGetsIds<int>
{
    public string EndpointUrl { get; }
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
    
    public CharacterRecipesRequest(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName))
            throw new ArgumentException("Character name cannot be null or empty.", nameof(characterName));
        EndpointUrl = Gw2ApiEndpointUrl.CharactersRecipe.Replace("{id}", Uri.EscapeDataString(characterName));
    }
}
