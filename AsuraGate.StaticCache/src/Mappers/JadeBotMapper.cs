using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="JadeBot"/> to <see cref="JadeBotEntity"/>.
/// </summary>
public static class JadeBotMapper
{
    public static JadeBotEntity ToEntity(JadeBot jadeBot) => new JadeBotEntity()
    {
        Id = jadeBot.Id,
        Name = jadeBot.Name,
        Description = jadeBot.Description,
        UnlockItem = jadeBot.UnlockItem,
    };

    public static JadeBot ToModel(JadeBotEntity entity) => new JadeBot()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        UnlockItem = entity.UnlockItem,
    };
}
