using FluentValidation.Results;
using NerdStore.Core.DomainObjects;
using NerdStore.Vendas.Domain.Entities.Enums;

namespace NerdStore.Vendas.Domain.Entities;

public class Voucher : Entity
{
    public string Codigo { get; private set; }
    public decimal? Percentual { get; private set; }
    public decimal? ValorDesconto { get; private set; }
    
    public int Quantidade { get; private set; }
    public ETipoDescontoVoucher TipoDescontoVoucher { get; private set; }

    public DateTime DataCriacao { get; private set; }
    
    public DateTime? DataUtilizacao { get; private set; }
    
    public DateTime DataValidade { get; private set; }
    
    public bool Ativo { get; private set; }
    
    public bool Utilizado { get; private set; }
    
    // EF Relation
    public ICollection<Pedido> Pedido { get; private set; }
    
    
    // public ValidationResult ValidarSeAplicavel()
    // {
    //     VoucherPedidoValidation voucherValidation = new();
    // }
}