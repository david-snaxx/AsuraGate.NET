using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.TokenInfo"/>.
/// </summary>
[Table("token_infos")]
public class TokenInfoEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [Column("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    [Column("issued_at")]
    public DateTime? IssuedAt { get; set; }
}

/// <summary>Permission scope granted to a <see cref="TokenInfoEntity"/>.</summary>
[Table("token_info_permissions")]
public class TokenInfoPermissionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("token_info_id")]
    public string TokenInfoId { get; set; } = string.Empty;

    [NotNull]
    [Column("permission")]
    public string Permission { get; set; } = string.Empty;
}

/// <summary>Allowed endpoint URL prefix for a <see cref="TokenInfoEntity"/> subtoken.</summary>
[Table("token_info_urls")]
public class TokenInfoUrlEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("token_info_id")]
    public string TokenInfoId { get; set; } = string.Empty;

    [NotNull]
    [Column("url")]
    public string Url { get; set; } = string.Empty;
}
