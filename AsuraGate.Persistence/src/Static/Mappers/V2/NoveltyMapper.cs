using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class NoveltyMapper
{
    public static NoveltyEntity ToEntity(Novelty model) => new NoveltyEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Novelty ToModel(NoveltyEntity entity) => JsonSerializer.Deserialize<Novelty>(entity.Data)!;
}
