using System.Text.Json;
using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Mappers.V2;

public static class MailCarrierMapper
{
    public static MailCarrierEntity ToEntity(MailCarrier model) => new MailCarrierEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static MailCarrier ToModel(MailCarrierEntity entity) => JsonSerializer.Deserialize<MailCarrier>(entity.Data)!;
}
