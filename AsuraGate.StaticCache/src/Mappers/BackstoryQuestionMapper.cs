using AsuraGate.Spec.Models.V2.Backstory;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="BackstoryQuestion"/> to <see cref="BackstoryQuestionEntity"/>.
/// </summary>
public static class BackstoryQuestionMapper
{
    public static BackstoryQuestionEntity ToEntity(BackstoryQuestion question) => new BackstoryQuestionEntity()
    {
        Id = question.Id,
        Title = question.Title,
        Description = question.Description,
        Order = question.Order,
    };

    public static IReadOnlyList<BackstoryQuestionAnswerEntity> ToAnswerEntities(BackstoryQuestion question) =>
        question.Answers.Select((answerId, index) => new BackstoryQuestionAnswerEntity()
        {
            BackstoryQuestionId = question.Id,
            OrderIndex = index,
            AnswerId = answerId,
        }).ToList();

    public static IReadOnlyList<BackstoryQuestionRaceEntity> ToRaceEntities(BackstoryQuestion question) =>
        question.Races.Select(race => new BackstoryQuestionRaceEntity() { BackstoryQuestionId = question.Id, Race = race }).ToList();

    public static IReadOnlyList<BackstoryQuestionProfessionEntity> ToProfessionEntities(BackstoryQuestion question) =>
        question.Professions.Select(profession => new BackstoryQuestionProfessionEntity() { BackstoryQuestionId = question.Id, Profession = profession }).ToList();

    public static BackstoryQuestion ToModel(BackstoryQuestionEntity entity, IEnumerable<string> answers, IEnumerable<string> races, IEnumerable<string> professions) => new BackstoryQuestion()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        Answers = answers.ToArray(),
        Order = entity.Order,
        Races = races.ToArray(),
        Professions = professions.ToArray(),
    };
}
