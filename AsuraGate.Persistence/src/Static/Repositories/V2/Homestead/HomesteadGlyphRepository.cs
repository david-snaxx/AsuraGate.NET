using AsuraGate.Persistence.Static.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Static.Repositories.V2.Homestead;

public class HomesteadGlyphRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<HomesteadGlyph, HomesteadGlyphEntity, string>(database, model => model.Id);
