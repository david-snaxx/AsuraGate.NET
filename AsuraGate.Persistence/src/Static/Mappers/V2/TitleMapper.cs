using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class TitleMapper
{
    public static TitleEntity ToEntity(Title model) => new TitleEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Title ToModel(TitleEntity entity) => JsonSerializer.Deserialize<Title>(entity.Data)!;
}
