using MediatR;
using NerdStore.Core.Commands;
using NerdStore.Core.Handlers.Interfaces;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Handlers;

public class MediatrHandler : IMediatrHandler
{
    private readonly IMediator _mediator;
    
    public MediatrHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task PublicarEvento<T>(T evento) where T : Event
    {
        await _mediator.Publish(evento);
    }

    public Task<bool> EnviarComando<T>(T comando) where T : Command
    {
        return _mediator.Send(comando);
    }
}