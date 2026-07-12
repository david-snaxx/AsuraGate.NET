using AsuraGate.Spec.Models.V2.Backstory;
using AsuraGate.StaticCache.Entities.V2.Backstory;

namespace AsuraGate.StaticCache.Mappers.V2.Backstory;

public static class BackstoryQuestionMapper
{
    public static BackstoryQuestionEntity ToBackstoryQuestionEntity(BackstoryQuestion question) => new BackstoryQuestionEntity()
    {
        Id = question.Id,
        Title = question.Title,
        Description = question.Description,
        Order = question.Order
    };

    public static IEnumerable<BackstoryQuestionAnswerEntity> ToAnswerEntities(BackstoryQuestion question) =>
        question.Answers.Select(answerId => new BackstoryQuestionAnswerEntity() { BackstoryQuestionId = question.Id, AnswerId = answerId });

    public static IEnumerable<BackstoryQuestionRaceEntity> ToRaceEntities(BackstoryQuestion question) =>
        question.Races.Select(race => new BackstoryQuestionRaceEntity() { BackstoryQuestionId = question.Id, Race = race });

    public static IEnumerable<BackstoryQuestionProfessionEntity> ToProfessionEntities(BackstoryQuestion question) =>
        question.Professions.Select(profession => new BackstoryQuestionProfessionEntity() { BackstoryQuestionId = question.Id, Profession = profession });

    public static BackstoryQuestion ToModel(
        BackstoryQuestionEntity entity,
        IEnumerable<BackstoryQuestionAnswerEntity> answerEntities,
        IEnumerable<BackstoryQuestionRaceEntity> raceEntities,
        IEnumerable<BackstoryQuestionProfessionEntity> professionEntities) => new BackstoryQuestion()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        Answers = answerEntities.Select(answer => answer.AnswerId).ToArray(),
        Order = entity.Order,
        Races = raceEntities.Select(race => race.Race).ToArray(),
        Professions = professionEntities.Select(profession => profession.Profession).ToArray()
    };
}
