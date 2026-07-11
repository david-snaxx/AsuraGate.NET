using AsuraGate.Spec.Models.V2.Backstory;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="BackstoryAnswer"/> to <see cref="BackstoryAnswerEntity"/>.
/// </summary>
public static class BackstoryAnswerMapper
{
    public static BackstoryAnswerEntity ToEntity(BackstoryAnswer answer) => new BackstoryAnswerEntity()
    {
        Id = answer.Id,
        Title = answer.Title,
        Description = answer.Description,
        Journal = answer.Journal,
        QuestionId = answer.Question,
    };

    public static IReadOnlyList<BackstoryAnswerProfessionEntity> ToProfessionEntities(BackstoryAnswer answer) =>
        answer.Professions.Select(profession => new BackstoryAnswerProfessionEntity() { BackstoryAnswerId = answer.Id, Profession = profession }).ToList();

    public static IReadOnlyList<BackstoryAnswerRaceEntity> ToRaceEntities(BackstoryAnswer answer) =>
        answer.Races.Select(race => new BackstoryAnswerRaceEntity() { BackstoryAnswerId = answer.Id, Race = race }).ToList();

    public static BackstoryAnswer ToModel(BackstoryAnswerEntity entity, IEnumerable<string> professions, IEnumerable<string> races) => new BackstoryAnswer()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        Journal = entity.Journal,
        Question = entity.QuestionId,
        Professions = professions.ToArray(),
        Races = races.ToArray(),
    };
}
