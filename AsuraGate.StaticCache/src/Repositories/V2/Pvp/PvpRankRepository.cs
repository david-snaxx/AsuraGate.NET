using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities.V2.Pvp;
using AsuraGate.StaticCache.Mappers.V2.Pvp;

namespace AsuraGate.StaticCache.Repositories.V2.Pvp;

public class PvpRankRepository :
    IStaticCacheRepository<PvpRank, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public PvpRankRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<PvpRank?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<PvpRankEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var levelEntities = await _database.Connection.Table<PvpRankLevelEntity>().Where(level => level.PvpRankId == id).ToListAsync();
        return PvpRankMapper.ToModel(entity, levelEntities);
    }

    public async Task<IEnumerable<PvpRank>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<PvpRankEntity>().ToListAsync();
        var levelEntities = await _database.Connection.Table<PvpRankLevelEntity>().ToListAsync();

        return entities.Select(entity => PvpRankMapper.ToModel(entity, levelEntities.Where(level => level.PvpRankId == entity.Id)));
    }

    public Task UpsertAsync(PvpRank rank) => UpsertAllAsync([rank]);

    public Task UpsertAllAsync(IEnumerable<PvpRank> ranks) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var rank in ranks)
        {
            connection.InsertOrReplace(PvpRankMapper.ToPvpRankEntity(rank));
            connection.Table<PvpRankLevelEntity>().Delete(level => level.PvpRankId == rank.Id);
            connection.InsertAll(PvpRankMapper.ToLevelEntities(rank));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<PvpRankLevelEntity>().Delete(level => level.PvpRankId == id);
        connection.Delete<PvpRankEntity>(id);
    });
}
