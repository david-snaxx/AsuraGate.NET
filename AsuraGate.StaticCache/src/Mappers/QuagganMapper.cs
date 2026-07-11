using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Quaggan"/> to <see cref="QuagganEntity"/>.
/// </summary>
public static class QuagganMapper
{
    public static QuagganEntity ToEntity(Quaggan quaggan) => new QuagganEntity()
    {
        Id = quaggan.Id,
        Url = quaggan.Url,
    };

    public static Quaggan ToModel(QuagganEntity entity) => new Quaggan()
    {
        Id = entity.Id,
        Url = entity.Url,
    };
}
