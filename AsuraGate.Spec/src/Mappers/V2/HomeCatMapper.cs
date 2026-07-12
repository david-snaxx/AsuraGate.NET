using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class HomeCatMapper
{
    public static HomeCatEntity ToHomeCatEntity(HomeCat homeCat) => new HomeCatEntity()
    {
        Id = homeCat.Id,
        Hint = homeCat.Hint
    };

    public static HomeCat ToModel(HomeCatEntity entity) => new HomeCat()
    {
        Id = entity.Id,
        Hint = entity.Hint
    };
}
