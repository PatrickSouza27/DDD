﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace NerdStore.Catalogo.Domain.Events.Handlers;

public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
{
    private readonly IProdutoRepository _produtoRepository;
    
    public ProdutoEventHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }   
    public async Task Handle(ProdutoAbaixoEstoqueEvent notification, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.ObterPorId(notification.AggregateId);
        
        // Enviar um e-mail para aquisição de mais produtos.
        
    }
}