using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class StoryJournalEntryRepository :
    IStaticCacheRepository<StoryJournalEntry, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public StoryJournalEntryRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<StoryJournalEntry?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<StoryJournalEntryEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var goalEntities = await _database.Connection.Table<StoryGoalEntity>().Where(goal => goal.StoryJournalEntryId == id).ToListAsync();
        return StoryJournalEntryMapper.ToModel(entity, goalEntities);
    }

    public async Task<IEnumerable<StoryJournalEntry>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<StoryJournalEntryEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var goalEntities = await _database.Connection
            .Table<StoryGoalEntity>()
            .Where(goal => idList.Contains(goal.StoryJournalEntryId))
            .ToListAsync();

        return entities.Select(entity => StoryJournalEntryMapper.ToModel(entity, goalEntities.Where(goal => goal.StoryJournalEntryId == entity.Id)));
    }

    public async Task<IEnumerable<StoryJournalEntry>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<StoryJournalEntryEntity>().ToListAsync();
        var goalEntities = await _database.Connection.Table<StoryGoalEntity>().ToListAsync();

        return entities.Select(entity => StoryJournalEntryMapper.ToModel(entity, goalEntities.Where(goal => goal.StoryJournalEntryId == entity.Id)));
    }

    public async Task<IEnumerable<int>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<StoryJournalEntryEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(StoryJournalEntry entry) => UpsertAllAsync([entry]);

    public Task UpsertAllAsync(IEnumerable<StoryJournalEntry> entries) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var entry in entries)
        {
            connection.InsertOrReplace(StoryJournalEntryMapper.ToStoryJournalEntryEntity(entry));
            connection.Table<StoryGoalEntity>().Delete(goal => goal.StoryJournalEntryId == entry.Id);
            connection.InsertAll(StoryJournalEntryMapper.ToGoalEntities(entry));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<StoryGoalEntity>().Delete(goal => goal.StoryJournalEntryId == id);
        connection.Delete<StoryJournalEntryEntity>(id);
    });
}
