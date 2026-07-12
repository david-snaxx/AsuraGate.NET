using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.StaticCache.Entities.V2.Homestead;
using AsuraGate.StaticCache.Mappers.V2.Homestead;

namespace AsuraGate.StaticCache.Repositories.V2.Homestead;

public class HomesteadGlyphRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public HomesteadGlyphRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<HomesteadGlyph?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<HomesteadGlyphEntity>(id);
        return entity is null ? null : HomesteadGlyphMapper.ToModel(entity);
    }

    public async Task<IEnumerable<HomesteadGlyph>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<HomesteadGlyphEntity>().ToListAsync();
        return entities.Select(HomesteadGlyphMapper.ToModel);
    }

    public Task UpsertAsync(HomesteadGlyph glyph) => UpsertAllAsync([glyph]);

    public Task UpsertAllAsync(IEnumerable<HomesteadGlyph> glyphs) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var glyph in glyphs)
        {
            connection.InsertOrReplace(HomesteadGlyphMapper.ToHomesteadGlyphEntity(glyph));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.DeleteAsync<HomesteadGlyphEntity>(id);
}
