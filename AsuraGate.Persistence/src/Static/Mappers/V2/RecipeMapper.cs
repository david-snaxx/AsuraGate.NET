using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class RecipeMapper
{
    public static RecipeEntity ToEntity(Recipe model) => new RecipeEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Recipe ToModel(RecipeEntity entity) => JsonSerializer.Deserialize<Recipe>(entity.Data)!;
}
