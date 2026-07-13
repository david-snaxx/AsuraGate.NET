using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class EmoteRepository :
    IStaticCacheRepository<Emote, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public EmoteRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Emote?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<EmoteEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var commandEntities = await _database.Connection.Table<EmoteCommandEntity>().Where(command => command.EmoteId == id).ToListAsync();
        var unlockItemEntities = await _database.Connection.Table<EmoteUnlockItemEntity>().Where(item => item.EmoteId == id).ToListAsync();
        return EmoteMapper.ToModel(entity, commandEntities, unlockItemEntities);
    }

    public async Task<IEnumerable<Emote>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<EmoteEntity>().ToListAsync();
        var commandEntities = await _database.Connection.Table<EmoteCommandEntity>().ToListAsync();
        var unlockItemEntities = await _database.Connection.Table<EmoteUnlockItemEntity>().ToListAsync();

        return entities.Select(entity => EmoteMapper.ToModel(
            entity,
            commandEntities.Where(command => command.EmoteId == entity.Id),
            unlockItemEntities.Where(item => item.EmoteId == entity.Id)));
    }

    public Task UpsertAsync(Emote emote) => UpsertAllAsync([emote]);

    public Task UpsertAllAsync(IEnumerable<Emote> emotes) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var emote in emotes)
        {
            connection.InsertOrReplace(EmoteMapper.ToEmoteEntity(emote));
            connection.Table<EmoteCommandEntity>().Delete(command => command.EmoteId == emote.Id);
            connection.InsertAll(EmoteMapper.ToCommandEntities(emote));
            connection.Table<EmoteUnlockItemEntity>().Delete(item => item.EmoteId == emote.Id);
            connection.InsertAll(EmoteMapper.ToUnlockItemEntities(emote));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<EmoteCommandEntity>().Delete(command => command.EmoteId == id);
        connection.Table<EmoteUnlockItemEntity>().Delete(item => item.EmoteId == id);
        connection.Delete<EmoteEntity>(id);
    });
}
