using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.StaticCache.Entities.V2.Characters;

namespace AsuraGate.StaticCache.Mappers.V2.Characters;

public static class CharacterRecipesMapper
{
    public static IEnumerable<CharacterRecipeIdEntity> ToEntities(string characterName, CharacterRecipes recipes) =>
        recipes.Ids.Select(recipeId => new CharacterRecipeIdEntity() { CharacterName = characterName, RecipeId = recipeId });

    public static CharacterRecipes ToModel(IEnumerable<CharacterRecipeIdEntity> entities) => new CharacterRecipes()
    {
        Ids = entities.Select(entity => entity.RecipeId).ToArray()
    };
}
