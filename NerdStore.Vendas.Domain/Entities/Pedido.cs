using NerdStore.Core.DomainObjects;
using NerdStore.Vendas.Domain.Entities.Enums;

namespace NerdStore.Vendas.Domain.Entities;

public class Pedido : Entity, IAggregateRoot
{
    public int Codigo { get; set; }
    public Guid ClienteId { get; set; }

    public Guid? VoucherId { get; set; }
    public bool VoucherUtilizado { get; set; }
    public decimal Desconto { get; set; }
    public decimal ValorTotal { get; set; }
    
    public DateTime DataCadastro { get; set; }

    public EPedidoStatus Status { get; set; }
    
    private readonly List<PedidoItem> _pedidoItems;

    public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;

    // EF Relation
    public virtual Voucher? Vouchers { get; private set; }

    protected Pedido() => _pedidoItems = new();
    internal Pedido(Guid clienteId)
    {
        ClienteId = clienteId;
        _pedidoItems = new ();
    }
    
    // public class PedidoFactory
    // {
    //     public static Pedido NovoPedidoRascunho(Guid clientId)
    //     {
    //         var pedido = new Pedido
    //         {
    //             ClientId = clientId
    //         };
    //         
    //         pedido.TornarRascunho();
    //         return pedido;
    //     }
    // }

    internal Pedido(Guid clienteId, bool voucher, decimal desconto, decimal valorTotal)
    {

        ClienteId = clienteId;
        VoucherUtilizado = voucher;
        Desconto = desconto;
        ValorTotal = valorTotal;
        _pedidoItems = new ();
    }
    
    public void CalcularTotalDesconto()
    {
        if (!VoucherUtilizado) return;
        
        decimal desconto = 0;
        var valor = ValorTotal;

        if (Vouchers.TipoDescontoVoucher == ETipoDescontoVoucher.Valor)
        {
            if (Vouchers.ValorDesconto.HasValue)
            {
                desconto = Vouchers.ValorDesconto.Value;
                valor -= desconto;
            }
        }
        else
        {
            if (Vouchers.Percentual.HasValue)
            {
                desconto = (valor * Vouchers.Percentual.Value) / 100;
                valor -= desconto;
            }
        }

        ValorTotal = valor < 0 ? 0 : valor;
        Desconto = desconto;
    }
    
    public void CalcularValorPedido()
    {
        ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
        CalcularTotalDesconto();
    }
    
    public bool PedidoItemExistente(PedidoItem item)
    {
        return _pedidoItems.Any(p => p.ProdutoId == item.ProdutoId);
    }
    
    public void AdicionarItem(PedidoItem item)
    {
        if (!item.EhValido()) return;
        
        item.AssociarPedido(Id);
        
        if (PedidoItemExistente(item))
        {
            var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
            if (itemExistente != null)
            {
                itemExistente.AdicionarUnidades(item.Quantidade);
                item = itemExistente;
                _pedidoItems.Remove(itemExistente);
            }
        }

        item.CalcularValor();
        _pedidoItems.Add(item);
        CalcularValorPedido();
    }
    
    public void RemoverItem(PedidoItem item)
    {
        if (!item.EhValido()) return;
        
        var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
        
        if (itemExistente == null) throw new DomainException("O item não pertence ao pedido");
        
        _pedidoItems.Remove(itemExistente);
        CalcularValorPedido();
    }
    
    public void AtualizarItem(PedidoItem item)
    {
        if (!item.EhValido()) return;
        
        item.AssociarPedido(Id);
        
        var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
        
        if (itemExistente == null) throw new DomainException("O item não pertence ao pedido");
        
        _pedidoItems.Remove(itemExistente);
        _pedidoItems.Add(item);
        
        CalcularValorPedido();
    }
    
    public void AtualizarUnidades(PedidoItem item, int unidades)
    {
        item.AtualizarUnidades(unidades);
        AtualizarItem(item);
    }
    
    public void TornarRascunho()
    {
        Status = EPedidoStatus.Rascunho;
    }
    
    public void IniciarPedido()
    {
        Status = EPedidoStatus.Iniciado;
    }
    
    public void FinalizarPedido()
    {
        Status = EPedidoStatus.Pago;
    }
    
    public void CancelarPedido()
    {
        Status = EPedidoStatus.Cancelado;
    }
    public override bool EhValido()
    {
        return true;
    }
}