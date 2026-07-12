using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.EmblemComponent"/>. Shared by both
/// /v2/emblem/background and /v2/emblem/foreground, which return the same shape but each restart
/// their own id sequence - callers must supply which <see cref="Slot"/> ("background"/"foreground")
/// a given component came from, since <c>ComponentId</c> alone isn't unique across both.
/// </summary>
[Table("emblem_components")]
public class EmblemComponentEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;

    [NotNull]
    [Column("component_id")]
    public int ComponentId { get; set; }
}

/// <summary>Layer image URL within an <see cref="EmblemComponentEntity"/>.</summary>
[Table("emblem_component_layers")]
public class EmblemComponentLayerEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;

    [NotNull]
    [Column("component_id")]
    public int ComponentId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("layer")]
    public string Layer { get; set; } = string.Empty;
}
