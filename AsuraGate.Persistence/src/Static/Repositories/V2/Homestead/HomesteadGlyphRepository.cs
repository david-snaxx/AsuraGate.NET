using AsuraGate.Persistence.Static.Entities.V2.Homestead;
using AsuraGate.Persistence.Static.Mappers.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Static.Repositories.V2.Homestead;

public class HomesteadGlyphRepository : StaticRepository<HomesteadGlyph, HomesteadGlyphEntity, string>
{
    public HomesteadGlyphRepository(Gw2ApiPersistenceDatabase database)
        : base(database, HomesteadGlyphMapper.ToEntity, HomesteadGlyphMapper.ToModel)
    {
    }
}
