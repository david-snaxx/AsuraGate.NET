using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class EmblemComponentRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public EmblemComponentRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<EmblemComponent?> GetAsync(string slot, int componentId)
    {
        var entity = await _database.Connection.Table<EmblemComponentEntity>()
            .Where(e => e.Slot == slot && e.ComponentId == componentId)
            .FirstOrDefaultAsync();
        if (entity is null)
        {
            return null;
        }

        var layerEntities = await _database.Connection.Table<EmblemComponentLayerEntity>()
            .Where(layer => layer.Slot == slot && layer.ComponentId == componentId)
            .ToListAsync();
        return EmblemComponentMapper.ToModel(entity, layerEntities);
    }

    public async Task<IEnumerable<EmblemComponent>> GetAllAsync(string slot)
    {
        var entities = await _database.Connection.Table<EmblemComponentEntity>().Where(e => e.Slot == slot).ToListAsync();
        var layerEntities = await _database.Connection.Table<EmblemComponentLayerEntity>().Where(layer => layer.Slot == slot).ToListAsync();

        return entities.Select(entity => EmblemComponentMapper.ToModel(entity, layerEntities.Where(layer => layer.ComponentId == entity.ComponentId)));
    }

    public Task UpsertAsync(string slot, EmblemComponent component) => UpsertAllAsync(slot, [component]);

    public Task UpsertAllAsync(string slot, IEnumerable<EmblemComponent> components) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var component in components)
        {
            connection.Table<EmblemComponentEntity>().Delete(e => e.Slot == slot && e.ComponentId == component.Id);
            connection.Insert(EmblemComponentMapper.ToEmblemComponentEntity(slot, component));
            connection.Table<EmblemComponentLayerEntity>().Delete(layer => layer.Slot == slot && layer.ComponentId == component.Id);
            connection.InsertAll(EmblemComponentMapper.ToLayerEntities(slot, component));
        }
    });

    public Task DeleteAsync(string slot, int componentId) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<EmblemComponentLayerEntity>().Delete(layer => layer.Slot == slot && layer.ComponentId == componentId);
        connection.Table<EmblemComponentEntity>().Delete(e => e.Slot == slot && e.ComponentId == componentId);
    });
}
