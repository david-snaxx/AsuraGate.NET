using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Achievements;

/// <summary>Represents a single achievement in the Guild Wars 2 achievement system.</summary>
public record Achievement
{
    /// <summary>Unique achievement ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>URL to the achievement's icon image; null if not provided.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>Display name of the achievement.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Flavor or descriptive text for the achievement; may be empty.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Text describing the requirement to unlock or complete the achievement.</summary>
    [JsonPropertyName("requirement")]
    public required string Requirement { get; init; }

    /// <summary>Text shown when the achievement is locked and not yet accessible.</summary>
    [JsonPropertyName("locked_text")]
    public required string LockedText { get; init; }

    /// <summary>Achievement category type (e.g., "Default", "ItemSet").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Behavior flags (e.g., "Pvp", "Daily", "Weekly", "Repeatable", "Hidden"); empty if not provided.</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>Ordered completion tiers, each awarding points at a progress threshold; empty if not provided.</summary>
    [JsonPropertyName("tiers")]
    public AchievementTier[] Tiers { get; init; } = [];

    /// <summary>Achievement IDs that must be completed before this achievement unlocks; empty if not provided.</summary>
    [JsonPropertyName("prerequisites")]
    public int[] Prerequisites { get; init; } = [];

    /// <summary>Raw JSON elements of type-specific reward data; empty if not provided; use <see cref="GetRewards"/> to deserialize into the correct subtypes.</summary>
    [JsonPropertyName("rewards")]
    public JsonElement[] Rewards { get; init; } = [];

    /// <summary>Discrete collectible or step entries for achievements with bit-based progress; empty if not applicable.</summary>
    [JsonPropertyName("bits")]
    public AchievementBit[] Bits { get; init; } = [];

    /// <summary>Maximum achievement point cap for repeatable achievements; null for non-repeatable achievements.</summary>
    [JsonPropertyName("point_cap")]
    public int? PointCap { get; init; }

    /// <summary>Deserializes each entry in <see cref="Rewards"/> into the correct <see cref="AchievementReward"/> subtype based on its "type" field.</summary>
    public IEnumerable<AchievementReward?> GetRewards() => Rewards.Select(reward => reward.GetProperty("type").GetString() switch
    {
        "Coins" => (AchievementReward?)reward.Deserialize<AchievementRewardCoins>(),
        "Item" => reward.Deserialize<AchievementRewardItem>(),
        "Mastery" => reward.Deserialize<AchievementRewardMastery>(),
        "Title" => reward.Deserialize<AchievementRewardTitle>(),
        _ => null
    });
}

/// <summary>Represents a single completion tier within an <see cref="Achievement"/>.</summary>
public record AchievementTier
{
    /// <summary>Number of completions or progress points required to reach this tier.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }

    /// <summary>Achievement points awarded when this tier is reached.</summary>
    [JsonPropertyName("points")]
    public required int Points { get; init; }
}

/// <summary>
/// Represents a reward granted upon completing an <see cref="Achievement"/>.
/// To check a reward's type you should check for the class name, not the "type" field, for example:
/// <code>if (reward is AchievementRewardCoins coins) { ... }</code>
/// Possible subtypes: <see cref="AchievementRewardCoins"/>, <see cref="AchievementRewardItem"/>,
/// <see cref="AchievementRewardMastery"/>, and <see cref="AchievementRewardTitle"/>.
/// </summary>
public abstract record AchievementReward;

/// <summary>An <see cref="AchievementReward"/> that grants a coin payout.</summary>
public record AchievementRewardCoins : AchievementReward
{
    /// <summary>Discriminator value identifying this reward's kind; always "Coins".</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Amount of coins awarded (in copper; 10000 = 1 gold).</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}

/// <summary>An <see cref="AchievementReward"/> that grants an item.</summary>
public record AchievementRewardItem : AchievementReward
{
    /// <summary>Discriminator value identifying this reward's kind; always "Item".</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Item ID awarded; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Number of the item awarded.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}

/// <summary>An <see cref="AchievementReward"/> that grants a mastery point.</summary>
public record AchievementRewardMastery : AchievementReward
{
    /// <summary>Discriminator value identifying this reward's kind; always "Mastery".</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Mastery point ID awarded.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Mastery region this point applies to (e.g., "CentralTyria", "Maguuma", "Desert", "Tundra").</summary>
    [JsonPropertyName("region")]
    public required string Region { get; init; }
}

/// <summary>An <see cref="AchievementReward"/> that unlocks a character title.</summary>
public record AchievementRewardTitle : AchievementReward
{
    /// <summary>Discriminator value identifying this reward's kind; always "Title".</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Title ID awarded; resolvable to a <see cref="Title"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }
}

/// <summary>Represents a discrete collectible or step entry in the bits list of an <see cref="Achievement"/>.</summary>
public record AchievementBit
{
    /// <summary>Type of this bit entry: "Text" (plain text step), "Item" (item collectible), "Minipet" (miniature collectible), or "Skin" (skin collectible).</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;

    /// <summary>ID of the referenced object; resolvable to an item, miniature, or skin depending on <see cref="Type"/>; null for "Text" bits.</summary>
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    /// <summary>Descriptive text for this bit; null for non-text bit types.</summary>
    [JsonPropertyName("text")]
    public string? Text { get; init; }
}
