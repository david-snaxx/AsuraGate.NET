using AsuraGate.Spec.Entities.V2.Commerce;
using AsuraGate.Spec.Models.V2.Commerce;

namespace AsuraGate.Spec.Mappers.V2.Commerce;

public static class CommerceTransactionMapper
{
    public static CommerceTransactionEntity ToCommerceTransactionEntity(CommerceTransaction transaction) => new CommerceTransactionEntity()
    {
        Id = transaction.Id,
        ItemId = transaction.ItemId,
        Price = transaction.Price,
        Quantity = transaction.Quantity,
        Created = transaction.Created,
        Purchased = transaction.Purchased
    };

    public static CommerceTransaction ToModel(CommerceTransactionEntity entity) => new CommerceTransaction()
    {
        Id = entity.Id,
        ItemId = entity.ItemId,
        Price = entity.Price,
        Quantity = entity.Quantity,
        Created = entity.Created,
        Purchased = entity.Purchased
    };
}
