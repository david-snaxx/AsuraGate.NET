using AsuraGate.Spec.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Spec.Mappers.V2.Wvw;

public static class WvwTimerMapper
{
    public static WvwTimerEntity ToWvwTimerEntity(WvwTimer timer) => new WvwTimerEntity()
    {
        Na = timer.Na,
        Eu = timer.Eu
    };

    public static WvwTimer ToModel(WvwTimerEntity entity) => new WvwTimer()
    {
        Na = entity.Na,
        Eu = entity.Eu
    };
}
