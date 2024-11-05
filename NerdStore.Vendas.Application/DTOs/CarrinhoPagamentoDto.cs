namespace NerdStore.Vendas.Application.DTOs;

public class CarrinhoPagamentoDto
{
    public string NomeCartao { get; set; }
    public string NumeroCartao { get; set; }
    public string MesAnoVencimento { get; set; }
    public string CVV { get; set; }
}