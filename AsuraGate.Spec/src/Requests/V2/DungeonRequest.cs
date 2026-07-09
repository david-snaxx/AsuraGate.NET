using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class DungeonRequest :
    IGetsSingle<Dungeon, string>,
    IGetsBulk<Dungeon, string>,
    IGetsAll<Dungeon>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Dungeon;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
