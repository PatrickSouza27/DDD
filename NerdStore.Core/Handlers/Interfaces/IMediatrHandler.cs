using NerdStore.Core.Commands;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Handlers.Interfaces;

public interface IMediatrHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
    
    Task<bool> EnviarComando<T>(T comando) where T : Command;
}