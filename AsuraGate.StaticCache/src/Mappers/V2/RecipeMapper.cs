using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class RecipeMapper
{
    public static RecipeEntity ToRecipeEntity(Recipe recipe) => new RecipeEntity()
    {
        Id = recipe.Id,
        Type = recipe.Type,
        OutputItemId = recipe.OutputItemId,
        OutputItemCount = recipe.OutputItemCount,
        TimeToCraftMs = recipe.TimeToCraftMs,
        MinRating = recipe.MinRating,
        OutputUpgradeId = recipe.OutputUpgradeId,
        ChatLink = recipe.ChatLink
    };

    public static IEnumerable<RecipeProfessionEntity> ToProfessionEntities(Recipe recipe) =>
        recipe.Professions.Select(profession => new RecipeProfessionEntity()
        {
            RecipeId = recipe.Id,
            Profession = profession
        });

    public static IEnumerable<RecipeFlagEntity> ToFlagEntities(Recipe recipe) =>
        recipe.Flags.Select(flag => new RecipeFlagEntity()
        {
            RecipeId = recipe.Id,
            Flag = flag
        });

    public static IEnumerable<RecipeIngredientEntity> ToIngredientEntities(Recipe recipe) =>
        recipe.Ingredients.Select(ingredient => new RecipeIngredientEntity()
        {
            RecipeId = recipe.Id,
            ItemId = ingredient.ItemId,
            Count = ingredient.Count
        });

    public static IEnumerable<RecipeGuildIngredientEntity> ToGuildIngredientEntities(Recipe recipe) =>
        recipe.GuildIngredients.Select(ingredient => new RecipeGuildIngredientEntity()
        {
            RecipeId = recipe.Id,
            UpgradeId = ingredient.UpgradeId,
            Count = ingredient.Count
        });

    public static Recipe ToModel(
        RecipeEntity entity,
        IEnumerable<RecipeProfessionEntity> professionEntities,
        IEnumerable<RecipeFlagEntity> flagEntities,
        IEnumerable<RecipeIngredientEntity> ingredientEntities,
        IEnumerable<RecipeGuildIngredientEntity> guildIngredientEntities) => new Recipe()
    {
        Id = entity.Id,
        Type = entity.Type,
        OutputItemId = entity.OutputItemId,
        OutputItemCount = entity.OutputItemCount,
        TimeToCraftMs = entity.TimeToCraftMs,
        Professions = professionEntities.Select(profession => profession.Profession).ToArray(),
        MinRating = entity.MinRating,
        Flags = flagEntities.Select(flag => flag.Flag).ToArray(),
        Ingredients = ingredientEntities.Select(ingredient => new RecipeIngredient()
        {
            ItemId = ingredient.ItemId,
            Count = ingredient.Count
        }).ToArray(),
        GuildIngredients = guildIngredientEntities.Select(ingredient => new GuildIngredient()
        {
            UpgradeId = ingredient.UpgradeId,
            Count = ingredient.Count
        }).ToArray(),
        OutputUpgradeId = entity.OutputUpgradeId,
        ChatLink = entity.ChatLink
    };
}
