using NerdStore.Core.Messages;

namespace NerdStore.Core.Handlers.Interfaces;

public interface IMediatrHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
}