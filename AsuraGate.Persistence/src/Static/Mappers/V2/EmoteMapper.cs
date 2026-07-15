using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class EmoteMapper
{
    public static EmoteEntity ToEntity(Emote model) => new EmoteEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Emote ToModel(EmoteEntity entity) => JsonSerializer.Deserialize<Emote>(entity.Data)!;
}
