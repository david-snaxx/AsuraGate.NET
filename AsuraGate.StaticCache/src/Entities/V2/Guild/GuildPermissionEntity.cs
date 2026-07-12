using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Guild;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Guild.GuildPermission"/>. Unlike most Guild/*
/// models, this is a static global catalog (not guild-scoped) - no GuildId needed.
/// </summary>
[Table("guild_permissions")]
public class GuildPermissionEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;
}
