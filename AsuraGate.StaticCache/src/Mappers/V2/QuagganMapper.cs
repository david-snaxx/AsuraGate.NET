using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class QuagganMapper
{
    public static QuagganEntity ToQuagganEntity(Quaggan quaggan) => new QuagganEntity()
    {
        Id = quaggan.Id,
        Url = quaggan.Url
    };

    public static Quaggan ToModel(QuagganEntity entity) => new Quaggan()
    {
        Id = entity.Id,
        Url = entity.Url
    };
}
