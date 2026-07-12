using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Characters;

/// <summary>
/// An unlocked recipe ID for a character - <see cref="AsuraGate.Spec.Models.V2.Characters.CharacterRecipes"/>
/// has no character name of its own; callers must supply <see cref="CharacterName"/>.
/// </summary>
[Table("character_recipe_ids")]
public class CharacterRecipeIdEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("recipe_id")]
    public int RecipeId { get; set; }
}
