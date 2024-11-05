using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalogo.Application.DTOs;

public class CategoriaDTO
{
    [Key]
    public Guid Id { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; private set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int Codigo { get; private set; }
    
}