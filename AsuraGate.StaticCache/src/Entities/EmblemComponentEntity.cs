using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.EmblemComponent"/>.
/// </summary>
[Table("emblem_components")]
public class EmblemComponentEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
}

/// <summary>
/// Ordered layer image URLs for an <see cref="EmblemComponentEntity"/> (bottom to top).
/// </summary>
[Table("emblem_component_layers")]
public class EmblemComponentLayerEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("emblem_component_id")]
    public int EmblemComponentId { get; set; } // FK to EmblemComponentEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("layer_url")]
    public string LayerUrl { get; set; } = string.Empty;
}
