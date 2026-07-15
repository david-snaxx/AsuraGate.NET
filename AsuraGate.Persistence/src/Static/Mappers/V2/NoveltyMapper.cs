using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class NoveltyMapper
{
    public static NoveltyEntity ToEntity(Novelty model) => new NoveltyEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Novelty ToModel(NoveltyEntity entity) => JsonSerializer.Deserialize<Novelty>(entity.Data)!;
}
