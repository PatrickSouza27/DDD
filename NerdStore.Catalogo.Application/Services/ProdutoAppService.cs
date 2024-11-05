using AutoMapper;
using NerdStore.Catalogo.Application.DTOs;
using NerdStore.Catalogo.Application.Services.Interfaces;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Interfaces;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Application.Services;

public class ProdutoAppService : IProdutoAppService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;
    private readonly IEstoqueService _estoqueService;
    
    public ProdutoAppService(IProdutoRepository produtoRepository, IMapper mapper, IEstoqueService estoqueService)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
        _estoqueService = estoqueService;
    }

    public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
    {
        return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterTodos());
    }

    public async Task<ProdutoDTO?> ObterPorId(Guid id)
    {
        return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
    }

    public async Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo)
    {
        return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterPorCategoria(codigo));
    }

    public async Task<IEnumerable<CategoriaDTO>> ObterCategorias()
    {
        return _mapper.Map<IEnumerable<CategoriaDTO>>(await _produtoRepository.ObterCategorias());
    }

    public async Task AdicionarProduto(ProdutoDTO produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        _produtoRepository.Adicionar(produto);
        
        await _produtoRepository.UnitOfWork.Commit();
    }

    public async Task AtualizarProduto(ProdutoDTO produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        _produtoRepository.Atualizar(produto);
        
        await _produtoRepository.UnitOfWork.Commit();
    }

    public async Task<ProdutoDTO> DebitarEstoque(Guid Id, int qtd)
    {
        if(!_estoqueService.DebitarEstoque(Id, qtd).Result)
        {
            throw new DomainException("Falha ao debitar estoque");
        }
        
        return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(Id));
    }

    public async Task<ProdutoDTO> ReporEstoque(Guid Id, int qtd)
    {
        if(!_estoqueService.ReporEstoque(Id, qtd).Result)
        {
            throw new DomainException("Falha ao repor estoque");
        }
        
        return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(Id));
    }
    
    public void Dispose()
    {
        _produtoRepository?.Dispose();
        _estoqueService?.Dispose();
    }
}