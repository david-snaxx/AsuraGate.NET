using AsuraGate.Persistence.Static.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Static.Mappers.V2.Homestead;

public static class HomesteadDecorationMapper
{
    public static HomesteadDecorationEntity ToEntity(HomesteadDecoration model) => new HomesteadDecorationEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static HomesteadDecoration? ToModel(HomesteadDecorationEntity entity) => MapperUtils.DeserializeJson<HomesteadDecoration>(entity.Data);
}
