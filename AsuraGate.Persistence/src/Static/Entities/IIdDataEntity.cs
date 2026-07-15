using AsuraGate.Persistence.Static.Repositories;

namespace AsuraGate.Persistence.Static.Entities;

/// <summary>
/// Marks an id+data blob entity so <see cref="StaticRepository{TModel,TEntity,TId}"/>
/// can query and delete by id generically, without knowing the concrete entity type.
/// </summary>
public interface IIdDataEntity<TId>
{
    TId Id { get; set; }
}
