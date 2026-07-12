using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.StaticCache.Entities.V2.Characters;

namespace AsuraGate.StaticCache.Mappers.V2.Characters;

public static class CharacterCoreMapper
{
    public static CharacterCoreEntity ToCharacterCoreEntity(CharacterCore core) => new CharacterCoreEntity()
    {
        Name = core.Name,
        Race = core.Race,
        Gender = core.Gender,
        Profession = core.Profession,
        Level = core.Level,
        Guild = core.Guild,
        Age = core.Age,
        Created = core.Created,
        LastModified = core.LastModified,
        Deaths = core.Deaths,
        Title = core.Title
    };

    public static CharacterCore ToModel(CharacterCoreEntity entity) => new CharacterCore()
    {
        Name = entity.Name,
        Race = entity.Race,
        Gender = entity.Gender,
        Profession = entity.Profession,
        Level = entity.Level,
        Guild = entity.Guild,
        Age = entity.Age,
        Created = entity.Created,
        LastModified = entity.LastModified,
        Deaths = entity.Deaths,
        Title = entity.Title
    };
}
