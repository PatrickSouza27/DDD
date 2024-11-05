using System.ComponentModel.DataAnnotations;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Entities.ValuesObjects;

namespace NerdStore.Catalogo.Application.DTOs;

public class ProdutoDTO
{
    [Key]
    public Guid Id { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Descricao { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public bool Ativo { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal Valor { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime DataCadastro { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Imagem { get; private set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor maior que 0")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int QuantidadeEstoque { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid CategoriaId { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public IEnumerable<CategoriaDTO> Categoria { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Dimensoes Dimensoes { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor maior que 0")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal Altura { get; private set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor maior que 0")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal Largura { get; private set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor maior que 0")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal Profundidade { get; private set; }
}