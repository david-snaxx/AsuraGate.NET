using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class RecipeMapper
{
    public static RecipeEntity ToEntity(Recipe model) => new RecipeEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static Recipe? ToModel(RecipeEntity entity) => MapperUtils.DeserializeJson<Recipe>(entity.Data);
}
