using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Recipe"/>.
/// </summary>
[Table("recipes")]
public class RecipeEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("output_item_id")]
    public int OutputItemId { get; set; }

    [NotNull]
    [Column("output_item_count")]
    public int OutputItemCount { get; set; }

    [NotNull]
    [Column("time_to_craft_ms")]
    public int TimeToCraftMs { get; set; }

    [NotNull]
    [Column("min_rating")]
    public int MinRating { get; set; }

    [Column("output_upgrade_id")]
    public int? OutputUpgradeId { get; set; }

    [NotNull]
    [Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;
}

/// <summary>Crafting discipline that can use a <see cref="RecipeEntity"/>.</summary>
[Table("recipe_professions")]
public class RecipeProfessionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [NotNull]
    [Column("profession")]
    public string Profession { get; set; } = string.Empty;
}

/// <summary>Behavior flag on a <see cref="RecipeEntity"/>.</summary>
[Table("recipe_flags")]
public class RecipeFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Item ingredient required by a <see cref="RecipeEntity"/>.</summary>
[Table("recipe_ingredients")]
public class RecipeIngredientEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }
}

/// <summary>Guild upgrade ingredient required by a <see cref="RecipeEntity"/>.</summary>
[Table("recipe_guild_ingredients")]
public class RecipeGuildIngredientEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [NotNull]
    [Column("upgrade_id")]
    public int UpgradeId { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }
}
