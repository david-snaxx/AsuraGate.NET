using AsuraGate.Spec.Models.V2.Characters;
using AsuraGate.StaticCache.Entities.V2.Characters;

namespace AsuraGate.StaticCache.Mappers.V2.Characters;

public static class CharacterTrainingMapper
{
    public static IEnumerable<CharacterTrainingEntity> ToEntities(string characterName, CharacterTraining training) =>
        training.Training.Select(tree => new CharacterTrainingEntity()
        {
            CharacterName = characterName,
            TrainingId = tree.Id,
            Spent = tree.Spent,
            Done = tree.Done
        });

    public static CharacterTraining ToModel(IEnumerable<CharacterTrainingEntity> entities) => new CharacterTraining()
    {
        Training = entities.Select(entity => new TrainingTree() { Id = entity.TrainingId, Spent = entity.Spent, Done = entity.Done }).ToArray()
    };
}
