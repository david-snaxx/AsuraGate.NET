using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Guild;

/// <summary>
/// Polymorphic entry in a guild's activity log, discriminated by action type.
/// Possible subtypes include:
/// <see cref="GuildLogEntryJoined"/>, <see cref="GuildLogEntryInvited"/>, <see cref="GuildLogEntryKick"/>,
/// <see cref="GuildLogEntryRankChange"/>, <see cref="GuildLogEntryTreasury"/>, <see cref="GuildLogEntryStash"/>,
/// <see cref="GuildLogEntryMotd"/>, <see cref="GuildLogEntryUpgrade"/>, <see cref="GuildLogEntryInfluence"/>,
/// <see cref="GuildLogEntryMission"/>.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(GuildLogEntryJoined), "joined")]
[JsonDerivedType(typeof(GuildLogEntryInvited), "invited")]
[JsonDerivedType(typeof(GuildLogEntryKick), "kick")]
[JsonDerivedType(typeof(GuildLogEntryRankChange), "rank_change")]
[JsonDerivedType(typeof(GuildLogEntryTreasury), "treasury")]
[JsonDerivedType(typeof(GuildLogEntryStash), "stash")]
[JsonDerivedType(typeof(GuildLogEntryMotd), "motd")]
[JsonDerivedType(typeof(GuildLogEntryUpgrade), "upgrade")]
[JsonDerivedType(typeof(GuildLogEntryInfluence), "influence")]
[JsonDerivedType(typeof(GuildLogEntryMission), "mission")]
public abstract record GuildLogEntry
{
    /// <summary>Unique log entry ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Timestamp when this event occurred.</summary>
    [JsonPropertyName("time")]
    public required DateTime Time { get; init; }

    /// <summary>Account name of the member who triggered this event; null for system-generated events.</summary>
    [JsonPropertyName("user")]
    public string? User { get; init; }
}

/// <summary>A <see cref="GuildLogEntry"/> recording a player joining the guild.</summary>
public record GuildLogEntryJoined : GuildLogEntry;

/// <summary>A <see cref="GuildLogEntry"/> recording a player being invited to the guild.</summary>
public record GuildLogEntryInvited : GuildLogEntry
{
    /// <summary>Account name of the guild member who sent the invitation.</summary>
    [JsonPropertyName("invited_by")]
    public required string InvitedBy { get; init; }
}

/// <summary>A <see cref="GuildLogEntry"/> recording a member being kicked from the guild.</summary>
public record GuildLogEntryKick : GuildLogEntry
{
    /// <summary>Account name of the officer or leader who performed the kick.</summary>
    [JsonPropertyName("kicked_by")]
    public required string KickedBy { get; init; }
}

/// <summary>A <see cref="GuildLogEntry"/> recording a member's guild rank being changed.</summary>
public record GuildLogEntryRankChange : GuildLogEntry
{
    /// <summary>Account name of the officer or leader who made the change.</summary>
    [JsonPropertyName("changed_by")]
    public required string ChangedBy { get; init; }

    /// <summary>Name of the rank the member previously held.</summary>
    [JsonPropertyName("old_rank")]
    public required string OldRank { get; init; }

    /// <summary>Name of the rank the member was promoted or demoted to.</summary>
    [JsonPropertyName("new_rank")]
    public required string NewRank { get; init; }
}

/// <summary>A <see cref="GuildLogEntry"/> recording items deposited into the guild treasury.</summary>
public record GuildLogEntryTreasury : GuildLogEntry
{
    /// <summary>ID of the item deposited; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }

    /// <summary>Number of items deposited.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}

/// <summary>A <see cref="GuildLogEntry"/> recording a stash deposit or withdrawal of items or coins.</summary>
public record GuildLogEntryStash : GuildLogEntry
{
    /// <summary>Operation type: "deposit" or "withdraw".</summary>
    [JsonPropertyName("operation")]
    public required string Operation { get; init; }

    /// <summary>ID of the item deposited or withdrawn; resolvable to an <see cref="Item"/>; null for coin-only operations.</summary>
    [JsonPropertyName("item_id")]
    public int? ItemId { get; init; }

    /// <summary>Number of items deposited or withdrawn; null for coin-only operations.</summary>
    [JsonPropertyName("count")]
    public int? Count { get; init; }

    /// <summary>Amount of coins (in copper) deposited or withdrawn; null for item-only operations.</summary>
    [JsonPropertyName("coins")]
    public int? Coins { get; init; }
}

/// <summary>A <see cref="GuildLogEntry"/> recording a change to the guild's message of the day.</summary>
public record GuildLogEntryMotd : GuildLogEntry
{
    /// <summary>The new message of the day text that was set.</summary>
    [JsonPropertyName("motd")]
    public required string Motd { get; init; }
}

/// <summary>A <see cref="GuildLogEntry"/> recording a guild upgrade being queued, cancelled, sped up, or completed.</summary>
public record GuildLogEntryUpgrade : GuildLogEntry
{
    /// <summary>Action taken: "queued", "cancelled", "completed", or "sped_up".</summary>
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    /// <summary>Guild upgrade ID that was acted upon; resolvable to a <see cref="GuildUpgrade"/>.</summary>
    [JsonPropertyName("upgrade_id")]
    public required int UpgradeId { get; init; }

    /// <summary>Recipe ID used if the upgrade required a specific crafting recipe; null otherwise.</summary>
    [JsonPropertyName("recipe_id")]
    public int? RecipeId { get; init; }

    /// <summary>Item ID contributed toward the upgrade; resolvable to an <see cref="Item"/>; null for non-item actions.</summary>
    [JsonPropertyName("item_id")]
    public int? ItemId { get; init; }

    /// <summary>Quantity of the item contributed; null for non-item actions.</summary>
    [JsonPropertyName("count")]
    public int? Count { get; init; }
}

/// <summary>A <see cref="GuildLogEntry"/> recording influence gained from a group activity.</summary>
public record GuildLogEntryInfluence : GuildLogEntry
{
    /// <summary>Activity type that generated the influence (e.g., "Dungeon", "PvpGame").</summary>
    [JsonPropertyName("activity")]
    public required string Activity { get; init; }

    /// <summary>Total number of guild members who participated in this activity.</summary>
    [JsonPropertyName("total_participants")]
    public required int TotalParticipants { get; init; }

    /// <summary>Account names of guild members who participated.</summary>
    [JsonPropertyName("participants")]
    public string[] Participants { get; init; } = [];
}

/// <summary>A <see cref="GuildLogEntry"/> recording a guild mission being started or completed.</summary>
public record GuildLogEntryMission : GuildLogEntry
{
    /// <summary>Mission state: "start" when the mission was activated, "success" when completed.</summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    /// <summary>Amount of influence rewarded upon completion; null if the mission has not yet been completed.</summary>
    [JsonPropertyName("influence")]
    public int? Influence { get; init; }
}
