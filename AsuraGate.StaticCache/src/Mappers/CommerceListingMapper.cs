using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="CommerceListing"/> to <see cref="CommerceListingEntity"/>.
/// </summary>
public static class CommerceListingMapper
{
    public static CommerceListingEntity ToEntity(CommerceListing listing) => new CommerceListingEntity() { Id = listing.Id };

    public static IReadOnlyList<CommerceListingEntryEntity> ToEntryEntities(CommerceListing listing) =>
        ToEntryEntities(listing.Buys, listing.Id, "Buy").Concat(ToEntryEntities(listing.Sells, listing.Id, "Sell")).ToList();

    private static IEnumerable<CommerceListingEntryEntity> ToEntryEntities(IEnumerable<ListingEntry> entries, int listingId, string side) =>
        entries.Select((entry, index) => new CommerceListingEntryEntity()
        {
            CommerceListingId = listingId,
            Side = side,
            OrderIndex = index,
            Listings = entry.Listings,
            UnitPrice = entry.UnitPrice,
            Quantity = entry.Quantity,
        });

    public static ListingEntry ToEntryModel(CommerceListingEntryEntity entity) => new ListingEntry()
    {
        Listings = entity.Listings,
        UnitPrice = entity.UnitPrice,
        Quantity = entity.Quantity,
    };

    public static CommerceListing ToModel(CommerceListingEntity entity, IEnumerable<CommerceListingEntryEntity> entries)
    {
        var entryList = entries.OrderBy(e => e.OrderIndex).ToList();
        return new CommerceListing()
        {
            Id = entity.Id,
            Buys = entryList.Where(e => e.Side == "Buy").Select(ToEntryModel).ToArray(),
            Sells = entryList.Where(e => e.Side == "Sell").Select(ToEntryModel).ToArray(),
        };
    }
}
