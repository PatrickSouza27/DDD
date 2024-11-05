using NerdStore.Catalogo.Application.DTOs;

namespace NerdStore.Catalogo.Application.Services.Interfaces;

public interface IProdutoAppService : IDisposable
{
    Task<IEnumerable<ProdutoDTO>> ObterTodos();
    Task<ProdutoDTO?> ObterPorId(Guid id);
    Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo);
    Task<IEnumerable<CategoriaDTO>> ObterCategorias();
    Task AdicionarProduto(ProdutoDTO produtoDTO);
    Task AtualizarProduto(ProdutoDTO produtoDTO);
    Task<ProdutoDTO> DebitarEstoque(Guid Id, int qtd);
    Task<ProdutoDTO> ReporEstoque(Guid Id, int qtd);
}