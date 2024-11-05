using FluentValidation;
using NerdStore.Core.Commands;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.Vendas.Application.Validations;

public class RemoverItemValidation : AbstractValidator<RemoverItemCommand>
{
    public RemoverItemValidation()
    {
        RuleFor(c => c.ClienteId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do cliente inválido");

        RuleFor(c => c.ProdutoId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do produto inválido");
    }
}