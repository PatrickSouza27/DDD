using NerdStore.Core;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain;

public class Categoria : Entity
{
    public string Nome { get; private set; }
    public int Codigo { get; private set; }
    public IList<Produto> Produtos { get; set; }
    
    protected Categoria() { }

    public Categoria(string nome, int codigo)
    {
        Nome = nome;
        Codigo = codigo;

        Validar();
    }

    public override string ToString()
    {
        return $"{Nome} - {Codigo}";
    }

    private void Validar()
    {
        // aqui coloca as validações do produto do AssertionConcern ou FluentValidation
        AssertionConcern.AssertArgumentNotEmpty(Nome, "O nome da categoria não pode ser vazio");
    }
}