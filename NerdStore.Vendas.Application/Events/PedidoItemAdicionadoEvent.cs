using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events;

public class PedidoItemAdicionadoEvent : Event
{
    public Guid ClienteId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public Guid PedidoId { get; private set; }
    public string ProdutoNome { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public int Quantidade { get; private set; }

    public PedidoItemAdicionadoEvent(Guid clienteId, Guid produtoId, Guid pedidoId, string nome, decimal valorUnitario, int quantidade)
    {
        ClienteId = clienteId;
        ProdutoId = produtoId;
        PedidoId = pedidoId;
        ProdutoNome = nome;
        ValorUnitario = valorUnitario;
        Quantidade = quantidade;
    }
}