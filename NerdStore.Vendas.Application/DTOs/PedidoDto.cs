namespace NerdStore.Vendas.Application.DTOs;

public class PedidoDto
{
    public int Codigo { get; set; }
    public decimal Valor { get; set; }
    public int Status { get; set; }
    public DateTime DataCadastro { get; set; }
}

