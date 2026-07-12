using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.EmblemComponent"/>.
/// </summary>
[Table("emblem_components")]
public class EmblemComponentEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }
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
    [Column("emblem_component_id")]
    public int EmblemComponentId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("layer")]
    public string Layer { get; set; } = string.Empty;
}
