using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class SkillRequest :
    IGetsSingle<Skill, int>,
    IGetsBulk<Skill, int>,
    IGetsAll<Skill>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Skill;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
