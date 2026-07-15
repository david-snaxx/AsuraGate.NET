using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class QuagganMapper
{
    public static QuagganEntity ToEntity(Quaggan model) => new QuagganEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Quaggan ToModel(QuagganEntity entity) => JsonSerializer.Deserialize<Quaggan>(entity.Data)!;
}
