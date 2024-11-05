using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Vendas.Domain.Entities;
using NerdStore.Vendas.Domain.Entities.Enums;
using NerdStore.Vendas.Domain.Repositories.Interfaces;

namespace NerdStore.Vendas.Data.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly VendasContext _context;
    
    public PedidoRepository(VendasContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;
    
    public Task<Pedido> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId)
    {
        throw new NotImplementedException();
    }

    public async Task<Pedido?> ObterPedidoRascunhoPorClienteId(Guid clienteId)
    {
        var pedido =
            await _context.Pedidos.FirstOrDefaultAsync(p =>
                p.ClienteId == clienteId && p.Status == EPedidoStatus.Rascunho);

        if (pedido is null) return pedido;

        await _context.Entry(pedido)
            .Collection(i => i.PedidoItems).LoadAsync();

        if (pedido.VoucherId != null)
        {
            await _context.Entry(pedido)
                .Reference(v => v.Vouchers).LoadAsync();
        }

        return pedido;


    }

    public void Adicionar(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
    }

    public void Atualizar(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
    }

    public Task<PedidoItem> ObterItemPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
    {
        throw new NotImplementedException();
    }

    public void AdicionarItem(PedidoItem pedidoItem)
    {
        throw new NotImplementedException();
    }

    public void AtualizarItem(PedidoItem pedidoItem)
    {
        throw new NotImplementedException();
    }

    public void RemoverItem(PedidoItem pedidoItem)
    {
        throw new NotImplementedException();
    }

    public Task<Voucher> ObterVoucherPorCodigo(string codigo)
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}