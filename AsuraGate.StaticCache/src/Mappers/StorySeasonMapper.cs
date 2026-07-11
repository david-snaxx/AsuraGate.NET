using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="StorySeason"/> to <see cref="StorySeasonEntity"/>.
/// </summary>
public static class StorySeasonMapper
{
    public static StorySeasonEntity ToEntity(StorySeason season) => new StorySeasonEntity()
    {
        Id = season.Id,
        Name = season.Name,
        Order = season.Order,
    };

    public static IReadOnlyList<StorySeasonStoryEntity> ToStoryEntities(StorySeason season) =>
        season.Stories.Select(storyId => new StorySeasonStoryEntity() { StorySeasonId = season.Id, StoryId = storyId }).ToList();

    public static StorySeason ToModel(StorySeasonEntity entity, IEnumerable<int> stories) => new StorySeason()
    {
        Id = entity.Id,
        Name = entity.Name,
        Order = entity.Order,
        Stories = stories.ToArray(),
    };
}
