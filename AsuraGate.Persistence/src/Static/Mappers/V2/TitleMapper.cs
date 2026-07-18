using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class TitleMapper
{
    public static TitleEntity ToEntity(Title model) => new TitleEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Title? ToModel(TitleEntity entity) => MapperUtils.DeserializeJson<Title>(entity.Data);
}
