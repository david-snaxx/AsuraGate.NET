using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class JadeBotMapper
{
    public static JadeBotEntity ToJadeBotEntity(JadeBot jadeBot) => new JadeBotEntity()
    {
        Id = jadeBot.Id,
        Name = jadeBot.Name,
        Description = jadeBot.Description,
        UnlockItem = jadeBot.UnlockItem
    };

    public static JadeBot ToModel(JadeBotEntity entity) => new JadeBot()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        UnlockItem = entity.UnlockItem
    };
}
