using NerdStore.Vendas.Application.DTOs;
using NerdStore.Vendas.Application.Queries.Interfaces;
using NerdStore.Vendas.Domain.Entities.Enums;
using NerdStore.Vendas.Domain.Repositories.Interfaces;

namespace NerdStore.Vendas.Application.Queries;

public class PedidoQueries : IPedidoQueries
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoQueries(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<CarrinhoDto> ObterCarrinhoCliente(Guid clienteId)
    {
        var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(clienteId);
        
        if (pedido is null) return null;
        
        var carrinho = new CarrinhoDto
        {
            ClienteId = pedido.ClienteId,
            PedidoId = pedido.Id,
            ValorTotal = pedido.ValorTotal,
            ValorDesconto = pedido.Desconto,
            SubTotal = pedido.ValorTotal + pedido.Desconto,
        };
        
        if (pedido.VoucherId != null)
        {
            carrinho.VoucherCodigo = pedido.Vouchers.Codigo;
        }
        
        foreach (var item in pedido.PedidoItems)
        {
            carrinho.Itens.Add(new CarrinhoItemDto
            {
                ProdutoId = item.ProdutoId,
                ProdutoNome = item.ProdutoNome,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario,
                ValorTotal = item.ValorUnitario * item.Quantidade
            });
        }

        return carrinho;

    }

    public async Task<IEnumerable<PedidoDto>> ObterPedidosCliente(Guid clienteId)
    {
        var pedidos = await _pedidoRepository.ObterListaPorClienteId(clienteId);
    
        pedidos = pedidos.Where(p => p.Status is EPedidoStatus.Pago or EPedidoStatus.Cancelado)
            .OrderByDescending(p => p.Codigo);

        var enumerable = pedidos.ToList();

        var pedidosDto = enumerable.Select(pedido => new PedidoDto { Codigo = pedido.Codigo, Valor = pedido.ValorTotal, Status = (int)pedido.Status, DataCadastro = pedido.DataCadastro }).ToList();


        return pedidosDto;

    }
}