using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Events;

public class ProdutoAbaixoEstoqueEvent : DomainEvent
{
    public int QuantidadeRestante { get; private set; }
    
    public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int qtdRestante) : base(aggregateId)
    {
        QuantidadeRestante = qtdRestante;
    }
    
    
}