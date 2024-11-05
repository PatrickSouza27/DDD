using NerdStore.Core.Commands;
using NerdStore.Vendas.Application.Validations;

namespace NerdStore.Vendas.Application.Commands;

public class RemoverItemCommand : Command
{
    public Guid ClienteId { get; set; }
    public Guid ProdutoId { get; set; }

    public RemoverItemCommand(Guid clienteId, Guid produtoId)
    {
        ClienteId = clienteId;
        ProdutoId = produtoId;
    }

    public override bool EhValido()
    {
        ValidationResult = new RemoverItemValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}