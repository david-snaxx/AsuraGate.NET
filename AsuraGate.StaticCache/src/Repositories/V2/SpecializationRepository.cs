using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class SpecializationRepository :
    IStaticCacheRepository<Specialization, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public SpecializationRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Specialization?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<SpecializationEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var traitEntities = await _database.Connection.Table<SpecializationTraitEntity>().Where(trait => trait.SpecializationId == id).ToListAsync();
        return SpecializationMapper.ToModel(entity, traitEntities);
    }

    public async Task<IEnumerable<Specialization>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<SpecializationEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var traitEntities = await _database.Connection
            .Table<SpecializationTraitEntity>()
            .Where(trait => idList.Contains(trait.SpecializationId))
            .ToListAsync();

        return entities.Select(entity => SpecializationMapper.ToModel(entity, traitEntities.Where(trait => trait.SpecializationId == entity.Id)));
    }

    public async Task<IEnumerable<Specialization>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<SpecializationEntity>().ToListAsync();
        var traitEntities = await _database.Connection.Table<SpecializationTraitEntity>().ToListAsync();

        return entities.Select(entity => SpecializationMapper.ToModel(entity, traitEntities.Where(trait => trait.SpecializationId == entity.Id)));
    }

    public async Task<IEnumerable<int>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<SpecializationEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(Specialization specialization) => UpsertAllAsync([specialization]);

    public Task UpsertAllAsync(IEnumerable<Specialization> specializations) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var specialization in specializations)
        {
            connection.InsertOrReplace(SpecializationMapper.ToSpecializationEntity(specialization));
            connection.Table<SpecializationTraitEntity>().Delete(trait => trait.SpecializationId == specialization.Id);
            connection.InsertAll(SpecializationMapper.ToTraitEntities(specialization));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<SpecializationTraitEntity>().Delete(trait => trait.SpecializationId == id);
        connection.Delete<SpecializationEntity>(id);
    });
}
