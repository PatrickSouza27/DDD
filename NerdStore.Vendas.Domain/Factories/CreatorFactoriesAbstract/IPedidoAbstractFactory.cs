using NerdStore.Vendas.Domain.Entities;

namespace NerdStore.Vendas.Domain.Factories.CreatorFactoriesAbstract;

public interface IPedidoAbstractFactory
{ 
    Pedido CriarPedidoRascunho(Guid clienteId);
}