namespace AsuraGate.Persistence.Entities;

/// <summary>
/// Marks an id+data blob entity so <see cref="Repositories.StaticRepository{TModel,TEntity,TId}"/>
/// can query and delete by id generically, without knowing the concrete entity type.
/// </summary>
public interface IIdDataEntity<TId>
{
    TId Id { get; set; }
}
