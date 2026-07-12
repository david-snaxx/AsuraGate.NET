using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class RecipeRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public RecipeRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Recipe?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<RecipeEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var professionEntities = await _database.Connection.Table<RecipeProfessionEntity>().Where(profession => profession.RecipeId == id).ToListAsync();
        var flagEntities = await _database.Connection.Table<RecipeFlagEntity>().Where(flag => flag.RecipeId == id).ToListAsync();
        var ingredientEntities = await _database.Connection.Table<RecipeIngredientEntity>().Where(ingredient => ingredient.RecipeId == id).ToListAsync();
        var guildIngredientEntities = await _database.Connection.Table<RecipeGuildIngredientEntity>().Where(ingredient => ingredient.RecipeId == id).ToListAsync();
        return RecipeMapper.ToModel(entity, professionEntities, flagEntities, ingredientEntities, guildIngredientEntities);
    }

    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<RecipeEntity>().ToListAsync();
        var professionEntities = await _database.Connection.Table<RecipeProfessionEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<RecipeFlagEntity>().ToListAsync();
        var ingredientEntities = await _database.Connection.Table<RecipeIngredientEntity>().ToListAsync();
        var guildIngredientEntities = await _database.Connection.Table<RecipeGuildIngredientEntity>().ToListAsync();

        return entities.Select(entity => RecipeMapper.ToModel(
            entity,
            professionEntities.Where(profession => profession.RecipeId == entity.Id),
            flagEntities.Where(flag => flag.RecipeId == entity.Id),
            ingredientEntities.Where(ingredient => ingredient.RecipeId == entity.Id),
            guildIngredientEntities.Where(ingredient => ingredient.RecipeId == entity.Id)));
    }

    public Task UpsertAsync(Recipe recipe) => UpsertAllAsync([recipe]);

    public Task UpsertAllAsync(IEnumerable<Recipe> recipes) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var recipe in recipes)
        {
            connection.InsertOrReplace(RecipeMapper.ToRecipeEntity(recipe));
            connection.Table<RecipeProfessionEntity>().Delete(profession => profession.RecipeId == recipe.Id);
            connection.InsertAll(RecipeMapper.ToProfessionEntities(recipe));
            connection.Table<RecipeFlagEntity>().Delete(flag => flag.RecipeId == recipe.Id);
            connection.InsertAll(RecipeMapper.ToFlagEntities(recipe));
            connection.Table<RecipeIngredientEntity>().Delete(ingredient => ingredient.RecipeId == recipe.Id);
            connection.InsertAll(RecipeMapper.ToIngredientEntities(recipe));
            connection.Table<RecipeGuildIngredientEntity>().Delete(ingredient => ingredient.RecipeId == recipe.Id);
            connection.InsertAll(RecipeMapper.ToGuildIngredientEntities(recipe));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<RecipeProfessionEntity>().Delete(profession => profession.RecipeId == id);
        connection.Table<RecipeFlagEntity>().Delete(flag => flag.RecipeId == id);
        connection.Table<RecipeIngredientEntity>().Delete(ingredient => ingredient.RecipeId == id);
        connection.Table<RecipeGuildIngredientEntity>().Delete(ingredient => ingredient.RecipeId == id);
        connection.Delete<RecipeEntity>(id);
    });
}
