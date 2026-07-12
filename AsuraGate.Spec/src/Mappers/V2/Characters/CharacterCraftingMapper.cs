using AsuraGate.Spec.Entities.V2.Characters;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Spec.Mappers.V2.Characters;

public static class CharacterCraftingMapper
{
    public static IEnumerable<CharacterCraftingDisciplineEntity> ToEntities(string characterName, CharacterCrafting crafting) =>
        crafting.Crafting.Select(discipline => new CharacterCraftingDisciplineEntity()
        {
            CharacterName = characterName,
            Discipline = discipline.Discipline,
            Rating = discipline.Rating,
            Active = discipline.Active
        });

    public static CharacterCrafting ToModel(IEnumerable<CharacterCraftingDisciplineEntity> entities) => new CharacterCrafting()
    {
        Crafting = entities.Select(entity => new CraftingDiscipline()
        {
            Discipline = entity.Discipline,
            Rating = entity.Rating,
            Active = entity.Active
        }).ToArray()
    };
}
