using SQLite;

namespace AsuraGate.Spec.Entities.V2.Commerce;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommerceExchange"/>. Judgment call:
/// this model is the result of a live "how much would N gems/coins convert to right now" quote, not
/// reference data - it has no natural identity and a fresh quote invalidates any cached one immediately.
/// Implemented per the uniform pattern anyway (fixed constant PK, like <c>WvwTimer</c>), but caching this
/// at all is questionable - probably not worth wiring into an actual sync/persist path.
/// </summary>
[Table("commerce_exchanges")]
public class CommerceExchangeEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; } = 1;

    [NotNull]
    [Column("coins_per_gem")]
    public int CoinsPerGem { get; set; }

    [NotNull]
    [Column("quantity")]
    public int Quantity { get; set; }
}
