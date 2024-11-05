using NerdStore.Vendas.Application.DTOs;

namespace NerdStore.Vendas.Application.Queries.Interfaces;

public interface IPedidoQueries
{
    Task<CarrinhoDto> ObterCarrinhoCliente(Guid clienteId);
    Task<IEnumerable<PedidoDto>> ObterPedidosCliente(Guid clienteId);
}