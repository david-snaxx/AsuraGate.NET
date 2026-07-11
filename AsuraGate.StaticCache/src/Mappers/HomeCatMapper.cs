using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="HomeCat"/> to <see cref="HomeCatEntity"/>.
/// </summary>
public static class HomeCatMapper
{
    public static HomeCatEntity ToEntity(HomeCat homeCat) => new HomeCatEntity()
    {
        Id = homeCat.Id,
        Hint = homeCat.Hint,
    };

    public static HomeCat ToModel(HomeCatEntity entity) => new HomeCat()
    {
        Id = entity.Id,
        Hint = entity.Hint,
    };
}
