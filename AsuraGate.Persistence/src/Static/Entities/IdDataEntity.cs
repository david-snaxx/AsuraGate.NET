using SQLite;

namespace AsuraGate.Persistence.Static.Entities;

/// <summary>
/// Base for the id+data blob entities. Every static entity is shaped identically
/// (an id column and a JSON <c>data</c> blob) - concrete entities just add
/// <c>[Table("...")]</c> and pick the id type.
/// </summary>
public abstract class IdDataEntity<TId> : IIdDataEntity<TId>
{
    [PrimaryKey]
    [Column("id")]
    public TId Id { get; set; } = default!;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
