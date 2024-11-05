using NerdStore.Core.Commands;
using NerdStore.Vendas.Application.Validations;

namespace NerdStore.Vendas.Application.Commands;

public class AtualizarItemCommand : Command
{
    public Guid ClienteId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public Guid PedidoId { get; private set; }

    public AtualizarItemCommand(Guid clienteId, Guid produtoId, int quantidade, Guid pedidoId)
    {
        ClienteId = clienteId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        PedidoId = pedidoId;
    }

    public override bool EhValido()
    {
        ValidationResult = new AtualizarItensPedidoValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}