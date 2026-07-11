using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Recipe"/> to <see cref="RecipeEntity"/>.
/// </summary>
public static class RecipeMapper
{
    public static RecipeEntity ToEntity(Recipe recipe) => new RecipeEntity()
    {
        Id = recipe.Id,
        Type = recipe.Type,
        OutputItemId = recipe.OutputItemId,
        OutputItemCount = recipe.OutputItemCount,
        TimeToCraftMs = recipe.TimeToCraftMs,
        MinRating = recipe.MinRating,
        OutputUpgradeId = recipe.OutputUpgradeId,
        ChatLink = recipe.ChatLink,
    };

    public static IReadOnlyList<RecipeProfessionEntity> ToProfessionEntities(Recipe recipe) =>
        recipe.Professions.Select(profession => new RecipeProfessionEntity() { RecipeId = recipe.Id, Profession = profession }).ToList();

    public static IReadOnlyList<RecipeFlagEntity> ToFlagEntities(Recipe recipe) =>
        recipe.Flags.Select(flag => new RecipeFlagEntity() { RecipeId = recipe.Id, Flag = flag }).ToList();

    public static IReadOnlyList<RecipeIngredientEntity> ToIngredientEntities(Recipe recipe) =>
        recipe.Ingredients.Select(ingredient => new RecipeIngredientEntity()
        {
            RecipeId = recipe.Id,
            ItemId = ingredient.ItemId,
            Count = ingredient.Count,
        }).ToList();

    public static RecipeIngredient ToIngredientModel(RecipeIngredientEntity entity) => new RecipeIngredient()
    {
        ItemId = entity.ItemId,
        Count = entity.Count,
    };

    public static IReadOnlyList<RecipeGuildIngredientEntity> ToGuildIngredientEntities(Recipe recipe) =>
        recipe.GuildIngredients.Select(ingredient => new RecipeGuildIngredientEntity()
        {
            RecipeId = recipe.Id,
            UpgradeId = ingredient.UpgradeId,
            Count = ingredient.Count,
        }).ToList();

    public static GuildIngredient ToGuildIngredientModel(RecipeGuildIngredientEntity entity) => new GuildIngredient()
    {
        UpgradeId = entity.UpgradeId,
        Count = entity.Count,
    };

    public static Recipe ToModel(
        RecipeEntity entity,
        IEnumerable<string> professions,
        IEnumerable<string> flags,
        IEnumerable<RecipeIngredient> ingredients,
        IEnumerable<GuildIngredient> guildIngredients) => new Recipe()
    {
        Id = entity.Id,
        Type = entity.Type,
        OutputItemId = entity.OutputItemId,
        OutputItemCount = entity.OutputItemCount,
        TimeToCraftMs = entity.TimeToCraftMs,
        Professions = professions.ToArray(),
        MinRating = entity.MinRating,
        Flags = flags.ToArray(),
        Ingredients = ingredients.ToArray(),
        GuildIngredients = guildIngredients.ToArray(),
        OutputUpgradeId = entity.OutputUpgradeId,
        ChatLink = entity.ChatLink,
    };
}
