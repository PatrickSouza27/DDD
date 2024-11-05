using MediatR;

namespace NerdStore.Vendas.Application.Events.Handlers;

public class PedidoEventHandler : 
    INotificationHandler<PedidoRascunhoIniciadoEvent>,
    INotificationHandler<PedidoItemAdicionadoEvent>,
    INotificationHandler<PedidoAtualizadoEvent>
{
    public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}