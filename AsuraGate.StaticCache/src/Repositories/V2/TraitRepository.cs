using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class TraitRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public TraitRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Trait?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<TraitEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var factEntities = await _database.Connection.Table<TraitFactEntity>().Where(fact => fact.TraitId == id).ToListAsync();
        var skillEntities = await _database.Connection.Table<TraitSkillEntity>().Where(skill => skill.TraitId == id).ToListAsync();
        var skillFactEntities = await _database.Connection.Table<TraitSkillFactEntity>().Where(fact => fact.TraitId == id).ToListAsync();

        return TraitMapper.ToModel(entity, factEntities, skillEntities, skillFactEntities);
    }

    public async Task<IEnumerable<Trait>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<TraitEntity>().ToListAsync();
        var factEntities = await _database.Connection.Table<TraitFactEntity>().ToListAsync();
        var skillEntities = await _database.Connection.Table<TraitSkillEntity>().ToListAsync();
        var skillFactEntities = await _database.Connection.Table<TraitSkillFactEntity>().ToListAsync();

        return entities.Select(entity => TraitMapper.ToModel(
            entity,
            factEntities.Where(fact => fact.TraitId == entity.Id),
            skillEntities.Where(skill => skill.TraitId == entity.Id),
            skillFactEntities.Where(fact => fact.TraitId == entity.Id)));
    }

    public Task UpsertAsync(Trait trait) => UpsertAllAsync([trait]);

    public Task UpsertAllAsync(IEnumerable<Trait> traits) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var trait in traits)
        {
            connection.InsertOrReplace(TraitMapper.ToTraitEntity(trait));

            connection.Table<TraitFactEntity>().Delete(fact => fact.TraitId == trait.Id);
            connection.InsertAll(TraitMapper.ToFactEntities(trait));

            connection.Table<TraitSkillEntity>().Delete(skill => skill.TraitId == trait.Id);
            connection.InsertAll(TraitMapper.ToSkillEntities(trait));

            connection.Table<TraitSkillFactEntity>().Delete(fact => fact.TraitId == trait.Id);
            connection.InsertAll(TraitMapper.ToSkillFactEntities(trait));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<TraitFactEntity>().Delete(fact => fact.TraitId == id);
        connection.Table<TraitSkillEntity>().Delete(skill => skill.TraitId == id);
        connection.Table<TraitSkillFactEntity>().Delete(fact => fact.TraitId == id);
        connection.Delete<TraitEntity>(id);
    });
}
