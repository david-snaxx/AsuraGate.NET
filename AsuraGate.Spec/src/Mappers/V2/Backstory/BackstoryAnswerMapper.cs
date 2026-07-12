using AsuraGate.Spec.Entities.V2.Backstory;
using AsuraGate.Spec.Models.V2.Backstory;

namespace AsuraGate.Spec.Mappers.V2.Backstory;

public static class BackstoryAnswerMapper
{
    public static BackstoryAnswerEntity ToBackstoryAnswerEntity(BackstoryAnswer answer) => new BackstoryAnswerEntity()
    {
        Id = answer.Id,
        Title = answer.Title,
        Description = answer.Description,
        Journal = answer.Journal,
        Question = answer.Question
    };

    public static IEnumerable<BackstoryAnswerProfessionEntity> ToProfessionEntities(BackstoryAnswer answer) =>
        answer.Professions.Select(profession => new BackstoryAnswerProfessionEntity() { BackstoryAnswerId = answer.Id, Profession = profession });

    public static IEnumerable<BackstoryAnswerRaceEntity> ToRaceEntities(BackstoryAnswer answer) =>
        answer.Races.Select(race => new BackstoryAnswerRaceEntity() { BackstoryAnswerId = answer.Id, Race = race });

    public static BackstoryAnswer ToModel(
        BackstoryAnswerEntity entity,
        IEnumerable<BackstoryAnswerProfessionEntity> professionEntities,
        IEnumerable<BackstoryAnswerRaceEntity> raceEntities) => new BackstoryAnswer()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        Journal = entity.Journal,
        Question = entity.Question,
        Professions = professionEntities.Select(profession => profession.Profession).ToArray(),
        Races = raceEntities.Select(race => race.Race).ToArray()
    };
}
