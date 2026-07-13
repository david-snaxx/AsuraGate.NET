using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;
using SQLite;

namespace AsuraGate.StaticCache.Repositories.V2;

public class DyeRepository :
    IStaticCacheRepository<Dye, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public DyeRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Dye?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<DyeEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var categoryEntities = await _database.Connection.Table<DyeCategoryEntity>().Where(category => category.DyeId == id).ToListAsync();
        return DyeMapper.ToModel(entity, categoryEntities);
    }

    public async Task<IEnumerable<Dye>> GetManyAsync(IEnumerable<int> ids)
    {
        var idsList = ids.ToList();
        var entities = await _database.Connection
            .Table<DyeEntity>()
            .Where(dye => idsList.Contains(dye.Id))
            .ToListAsync();
        var categoryEntities = await _database.Connection
            .Table<DyeCategoryEntity>()
            .Where(category => idsList.Contains(category.DyeId))
            .ToListAsync();
        return entities.Select(entity =>
        {
            return DyeMapper.ToModel(entity, categoryEntities.Where(category => category.DyeId == entity.Id));
        });
    }

    public async Task<IEnumerable<Dye>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<DyeEntity>().ToListAsync();
        var categoryEntities = await _database.Connection.Table<DyeCategoryEntity>().ToListAsync();

        return entities.Select(entity => DyeMapper.ToModel(entity, categoryEntities.Where(category => category.DyeId == entity.Id)));
    }

    public async Task<IEnumerable<Dye>> GetByCategoryAsync(string category)
    {
        var matchingCategoryEntities = await _database.Connection.Table<DyeCategoryEntity>().Where(c => c.Category == category).ToListAsync();
        var matchingIds = matchingCategoryEntities.Select(c => c.DyeId).ToList();

        var entities = await _database.Connection.Table<DyeEntity>().Where(dye => matchingIds.Contains(dye.Id)).ToListAsync();
        var categoryEntities = await _database.Connection.Table<DyeCategoryEntity>().Where(c => matchingIds.Contains(c.DyeId)).ToListAsync();

        return entities.Select(entity => DyeMapper.ToModel(entity, categoryEntities.Where(c => c.DyeId == entity.Id)));
    }

    public Task UpsertAsync(Dye dye) => UpsertAllAsync([dye]);

    public Task UpsertAllAsync(IEnumerable<Dye> dyes) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var dye in dyes)
        {
            connection.InsertOrReplace(DyeMapper.ToDyeEntity(dye));
            connection.Table<DyeCategoryEntity>().Delete(category => category.DyeId == dye.Id);
            connection.InsertAll(DyeMapper.ToCategoryEntities(dye));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<DyeCategoryEntity>().Delete(category => category.DyeId == id);
        connection.Delete<DyeEntity>(id);
    });
}
