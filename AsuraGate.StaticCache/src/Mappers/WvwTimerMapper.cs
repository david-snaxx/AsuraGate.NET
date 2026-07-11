using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WvwTimer"/> to <see cref="WvwTimerEntity"/>.
/// </summary>
public static class WvwTimerMapper
{
    public static WvwTimerEntity ToEntity(WvwTimer timer) => new WvwTimerEntity()
    {
        Na = timer.Na,
        Eu = timer.Eu,
    };

    public static WvwTimer ToModel(WvwTimerEntity entity) => new WvwTimer()
    {
        Na = entity.Na,
        Eu = entity.Eu,
    };
}
