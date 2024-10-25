using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data;

//se voce quiser agregar apenas por entity, so fazer assim
// public interface IRepository<T> : IDisposable where T : Entity
public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
    
}