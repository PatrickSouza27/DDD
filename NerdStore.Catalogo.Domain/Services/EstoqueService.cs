﻿using NerdStore.Catalogo.Domain.Events;
using NerdStore.Catalogo.Domain.Interfaces;
using NerdStore.Core.Handlers.Interfaces;

namespace NerdStore.Catalogo.Domain;

public class EstoqueService : IEstoqueService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMediatrHandler _mediatrHandler;

    public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler mediatrHandler)
    {
        _produtoRepository = produtoRepository;
        _mediatrHandler = mediatrHandler;
    }
    public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null) return false;

        if (!produto.PossuiEstoque(quantidade)) return false;

        produto.DebitarEstoque(quantidade);
        
        if(produto.QuantidadeEstoque < 10)  
            await _mediatrHandler.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));

        _produtoRepository.Atualizar(produto);

        return await _produtoRepository.UnitOfWork.Commit();
    }

    public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null) return false;

        produto.ReporEstoque(quantidade);

        _produtoRepository.Atualizar(produto);

        return await _produtoRepository.UnitOfWork.Commit();
    }

    public void Dispose()
    {
        _produtoRepository?.Dispose();
    }
}