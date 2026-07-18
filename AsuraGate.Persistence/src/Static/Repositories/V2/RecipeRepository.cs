using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class RecipeRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Recipe, RecipeEntity, int>(
        database, RecipeMapper.ToEntity, RecipeMapper.ToModel);
