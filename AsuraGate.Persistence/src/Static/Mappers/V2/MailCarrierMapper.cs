using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class MailCarrierMapper
{
    public static MailCarrierEntity ToEntity(MailCarrier model) => new MailCarrierEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static MailCarrier? ToModel(MailCarrierEntity entity) => MapperUtils.DeserializeJson<MailCarrier>(entity.Data);
}
