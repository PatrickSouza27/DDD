using FluentValidation;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.Vendas.Application.Validations;

public class AtualizarItensPedidoValidation : AbstractValidator<AtualizarItemCommand>
{
    public AtualizarItensPedidoValidation()
    {
        RuleFor(c => c.ClienteId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do cliente inválido");

        RuleFor(c => c.ProdutoId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do produto inválido");

        RuleFor(c => c.Quantidade)
            .GreaterThan(0)
            .WithMessage("A quantidade mínima de um item é 1");

        RuleFor(c => c.PedidoId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do pedido inválido");
    }
}