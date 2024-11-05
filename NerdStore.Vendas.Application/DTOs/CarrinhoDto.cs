namespace NerdStore.Vendas.Application.DTOs;

public class CarrinhoDto
{
    public Guid PedidoId { get; set; }
    public Guid ClienteId { get; set; }
    public decimal ValorTotal { get; set; }
    public string VoucherCodigo { get; set; }
    public decimal ValorDesconto { get; set; }
    
    public decimal SubTotal { get; set; }
    public List<CarrinhoItemDto> Itens { get; set; } = [];
    public CarrinhoPagamentoDto Pagamento { get; set; }
}