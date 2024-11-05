using NerdStore.Vendas.Domain.Entities;
using NerdStore.Vendas.Domain.Factories.CreatorFactoriesAbstract;

namespace NerdStore.Vendas.Domain.Factories.ConcretFactories;

public class PedidoConcretFactory : IPedidoAbstractFactory
{
    public Pedido CriarPedidoRascunho(Guid clienteId)
    {
        var pedido = new Pedido(clienteId);
        pedido.TornarRascunho();
        return pedido;
    }
}