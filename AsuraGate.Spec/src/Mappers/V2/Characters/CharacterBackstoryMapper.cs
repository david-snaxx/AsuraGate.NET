using AsuraGate.Spec.Entities.V2.Characters;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Spec.Mappers.V2.Characters;

public static class CharacterBackstoryMapper
{
    public static IEnumerable<CharacterBackstoryIdEntity> ToEntities(string characterName, CharacterBackstory backstory) =>
        backstory.Ids.Select((answerId, index) => new CharacterBackstoryIdEntity()
        {
            CharacterName = characterName,
            OrderIndex = index,
            AnswerId = answerId
        });

    public static CharacterBackstory ToModel(IEnumerable<CharacterBackstoryIdEntity> entities) => new CharacterBackstory()
    {
        Ids = entities.OrderBy(entity => entity.OrderIndex).Select(entity => entity.AnswerId).ToArray()
    };
}
