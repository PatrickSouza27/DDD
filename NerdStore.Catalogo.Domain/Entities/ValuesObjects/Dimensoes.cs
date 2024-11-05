using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Entities.ValuesObjects;

//value object
public class Dimensoes : ValueObject
{
    public decimal Altura { get; private set; }
    public decimal Largura { get; private set; }
    public decimal Profundidade { get; private set; }

    public Dimensoes(decimal altura, decimal largura, decimal profundidade)
    {
        //valida valores min e max
        Altura = altura;
        Largura = largura;
        Profundidade = profundidade;
    }
    
    public string DescricaoFormatada()
    {
        return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
    }
    
    public override string ToString()
    {
        return DescricaoFormatada();
    }
}