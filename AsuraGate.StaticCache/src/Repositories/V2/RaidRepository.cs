using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class RaidRepository :
    IStaticCacheRepository<Raid, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public RaidRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Raid?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<RaidEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var wingEntities = await _database.Connection.Table<RaidWingEntity>().Where(wing => wing.RaidId == id).ToListAsync();
        var eventEntities = await _database.Connection.Table<RaidEventEntity>().Where(@event => @event.RaidId == id).ToListAsync();
        return RaidMapper.ToModel(entity, wingEntities, eventEntities);
    }

    public async Task<IEnumerable<Raid>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<RaidEntity>().ToListAsync();
        var wingEntities = await _database.Connection.Table<RaidWingEntity>().ToListAsync();
        var eventEntities = await _database.Connection.Table<RaidEventEntity>().ToListAsync();

        return entities.Select(entity => RaidMapper.ToModel(
            entity,
            wingEntities.Where(wing => wing.RaidId == entity.Id),
            eventEntities.Where(@event => @event.RaidId == entity.Id)));
    }

    public Task UpsertAsync(Raid raid) => UpsertAllAsync([raid]);

    public Task UpsertAllAsync(IEnumerable<Raid> raids) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var raid in raids)
        {
            connection.InsertOrReplace(RaidMapper.ToRaidEntity(raid));
            connection.Table<RaidWingEntity>().Delete(wing => wing.RaidId == raid.Id);
            connection.InsertAll(RaidMapper.ToWingEntities(raid));
            connection.Table<RaidEventEntity>().Delete(@event => @event.RaidId == raid.Id);
            connection.InsertAll(RaidMapper.ToEventEntities(raid));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<RaidWingEntity>().Delete(wing => wing.RaidId == id);
        connection.Table<RaidEventEntity>().Delete(@event => @event.RaidId == id);
        connection.Delete<RaidEntity>(id);
    });
}
