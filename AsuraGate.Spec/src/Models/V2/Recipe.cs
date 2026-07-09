using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a crafting recipe learnable by a character or auto-learned from a discipline.</summary>
public record Recipe
{
    /// <summary>Unique recipe ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Output item category / crafting discipline category (e.g., "Coat", "Sword", "Meal").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>ID of the item produced by this recipe; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("output_item_id")]
    public required int OutputItemId { get; init; }

    /// <summary>Number of output items produced per single craft.</summary>
    [JsonPropertyName("output_item_count")]
    public required int OutputItemCount { get; init; }

    /// <summary>Crafting time in milliseconds.</summary>
    [JsonPropertyName("time_to_craft_ms")]
    public required int TimeToCraftMs { get; init; }

    /// <summary>List of crafting discipline names that can use this recipe (e.g., "Armorsmith", "Chef").</summary>
    [JsonPropertyName("professions")]
    public string[] Professions { get; init; } = [];

    /// <summary>Minimum crafting skill rating required to use this recipe without the "Discovered" flag.</summary>
    [JsonPropertyName("min_rating")]
    public required int MinRating { get; init; }

    /// <summary>Behavior flags (e.g., "AutoLearned" means no discovery needed, "LearnedFromItem" requires consuming an item).</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>List of item ingredients required; see <see cref="RecipeIngredient"/>.</summary>
    [JsonPropertyName("ingredients")]
    public RecipeIngredient[] Ingredients { get; init; } = [];

    /// <summary>List of guild upgrade ingredients required; see <see cref="GuildIngredient"/>.</summary>
    [JsonPropertyName("guild_ingredients")]
    public GuildIngredient[] GuildIngredients { get; init; } = [];

    /// <summary>ID of the guild upgrade produced; null if this is not a guild upgrade recipe.</summary>
    [JsonPropertyName("output_upgrade_id")]
    public int? OutputUpgradeId { get; init; }

    /// <summary>In-game chat link code for sharing this recipe in chat.</summary>
    [JsonPropertyName("chat_link")]
    public required string ChatLink { get; init; }
}

/// <summary>Represents a single item ingredient required by a <see cref="Recipe"/>.</summary>
public record RecipeIngredient
{
    /// <summary>ID of the required item; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("item_id")]
    public int? ItemId { get; init; } = null;

    /// <summary>Number of this item required.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}

/// <summary>Represents a guild upgrade ingredient required by a <see cref="Recipe"/>.</summary>
public record GuildIngredient
{
    /// <summary>ID of the required guild upgrade.</summary>
    [JsonPropertyName("upgrade_id")]
    public required int UpgradeId { get; init; }

    /// <summary>Number of this guild upgrade required.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
