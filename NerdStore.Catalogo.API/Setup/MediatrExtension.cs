using MediatR;
using NerdStore.Core.Handlers;
using NerdStore.Core.Handlers.Interfaces;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Application.Events.Handlers;

namespace NerdStore.Catalogo.API.Setup;

public static class MediatrExtension
{
    public static void RegisterMediatr(this IServiceCollection services)
    {
        services.AddScoped<IMediatrHandler, MediatrHandler>();
        services.AddMediatR(typeof(MediatrExtension));
        services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
    }
}