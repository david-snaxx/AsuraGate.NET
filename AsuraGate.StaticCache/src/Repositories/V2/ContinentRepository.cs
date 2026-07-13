using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class ContinentRepository :
    IStaticCacheRepository<Continent, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public ContinentRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Continent?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<ContinentEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var floorIdEntities = await _database.Connection.Table<ContinentFloorIdEntity>().Where(floor => floor.ContinentId == id).ToListAsync();
        return ContinentMapper.ToModel(entity, floorIdEntities);
    }

    public async Task<IEnumerable<Continent>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<ContinentEntity>().ToListAsync();
        var floorIdEntities = await _database.Connection.Table<ContinentFloorIdEntity>().ToListAsync();

        return entities.Select(entity => ContinentMapper.ToModel(entity, floorIdEntities.Where(floor => floor.ContinentId == entity.Id)));
    }

    public Task UpsertAsync(Continent continent) => UpsertAllAsync([continent]);

    public Task UpsertAllAsync(IEnumerable<Continent> continents) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var continent in continents)
        {
            connection.InsertOrReplace(ContinentMapper.ToContinentEntity(continent));
            connection.Table<ContinentFloorIdEntity>().Delete(floor => floor.ContinentId == continent.Id);
            connection.InsertAll(ContinentMapper.ToFloorIdEntities(continent));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<ContinentFloorIdEntity>().Delete(floor => floor.ContinentId == id);
        connection.Delete<ContinentEntity>(id);
    });
}
