using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class StorySeasonMapper
{
    public static StorySeasonEntity ToStorySeasonEntity(StorySeason storySeason) => new StorySeasonEntity()
    {
        Id = storySeason.Id,
        Name = storySeason.Name,
        Order = storySeason.Order
    };

    public static IEnumerable<StorySeasonStoryEntity> ToStoryEntities(StorySeason storySeason) =>
        storySeason.Stories.Select((storyId, index) => new StorySeasonStoryEntity()
        {
            StorySeasonId = storySeason.Id,
            OrderIndex = index,
            StoryId = storyId
        });

    public static StorySeason ToModel(StorySeasonEntity entity, IEnumerable<StorySeasonStoryEntity> storyEntities) => new StorySeason()
    {
        Id = entity.Id,
        Name = entity.Name,
        Order = entity.Order,
        Stories = storyEntities.OrderBy(story => story.OrderIndex).Select(story => story.StoryId).ToArray()
    };
}
