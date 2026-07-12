using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.StaticCache.Entities.V2.Commerce;

namespace AsuraGate.StaticCache.Mappers.V2.Commerce;

public static class CommerceListingMapper
{
    public static CommerceListingEntity ToCommerceListingEntity(CommerceListing listing) => new CommerceListingEntity()
    {
        Id = listing.Id
    };

    public static IEnumerable<CommerceListingEntryEntity> ToEntryEntities(CommerceListing listing)
    {
        var buys = listing.Buys.Select((entry, index) => new CommerceListingEntryEntity()
        {
            CommerceListingId = listing.Id,
            IsBuy = true,
            OrderIndex = index,
            Listings = entry.Listings,
            UnitPrice = entry.UnitPrice,
            Quantity = entry.Quantity
        });

        var sells = listing.Sells.Select((entry, index) => new CommerceListingEntryEntity()
        {
            CommerceListingId = listing.Id,
            IsBuy = false,
            OrderIndex = index,
            Listings = entry.Listings,
            UnitPrice = entry.UnitPrice,
            Quantity = entry.Quantity
        });

        return buys.Concat(sells);
    }

    public static CommerceListing ToModel(CommerceListingEntity entity, IEnumerable<CommerceListingEntryEntity> entryEntities)
    {
        var entries = entryEntities.ToList();
        ListingEntry ToEntry(CommerceListingEntryEntity entry) => new ListingEntry() { Listings = entry.Listings, UnitPrice = entry.UnitPrice, Quantity = entry.Quantity };

        return new CommerceListing()
        {
            Id = entity.Id,
            Buys = entries.Where(entry => entry.IsBuy).OrderBy(entry => entry.OrderIndex).Select(ToEntry).ToArray(),
            Sells = entries.Where(entry => !entry.IsBuy).OrderBy(entry => entry.OrderIndex).Select(ToEntry).ToArray()
        };
    }
}
