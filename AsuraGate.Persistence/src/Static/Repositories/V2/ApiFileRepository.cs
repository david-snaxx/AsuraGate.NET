using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class ApiFileRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<ApiFile, ApiFileEntity, string>(
        database, ApiFileMapper.ToEntity, ApiFileMapper.ToModel);
