using FluentValidation.Results;
using MediatR;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Commands;

public class Command : Message, IRequest<bool>
{
    public DateTime TimesTamp { get; private set; }

    public ValidationResult ValidationResult { get; set; }
    
    protected Command()
    {
        TimesTamp = DateTime.Now;
    }
    public virtual bool EhValido() => ValidationResult.IsValid;

}