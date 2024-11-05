using MediatR;
using NerdStore.Core.Commands;
using NerdStore.Core.DomainObjects;
using NerdStore.Core.Handlers.Interfaces;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Domain.Entities;
using NerdStore.Vendas.Domain.Factories.ConcretFactories;
using NerdStore.Vendas.Domain.Factories.CreatorFactoriesAbstract;
using NerdStore.Vendas.Domain.Repositories.Interfaces;

namespace NerdStore.Vendas.Application.Events.Handlers;

public class PedidoCommandHandler
    : IRequestHandler<AdicionarItemPedidoCommand, bool>,
      IRequestHandler<AtualizarItemCommand, bool>,
      IRequestHandler<RemoverItemCommand, bool>,
      IRequestHandler<AplicarVoucherPedidoCommand, bool>
{
    
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IMediatrHandler _mediatorHandler;
    
    public PedidoCommandHandler(IPedidoRepository pedidoRepository, IMediatrHandler mediatorHandler)
    {
        _pedidoRepository = pedidoRepository;
        _mediatorHandler = mediatorHandler;
    }
    
    public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
    {
        if (!ValidarComando(message)) return false;
        
        var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(message.ClienteId);
        var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);


        if (pedido is null)
        {
            pedido = CriarNovoPedidoComItem(message.ClienteId, pedidoItem);
            _pedidoRepository.Adicionar(pedido);
            pedido.AdicionarEvento(new PedidoRascunhoIniciadoEvent(message.ClienteId, message.ProdutoId));
        }
        else
        {
            AdicionarOuAtualizarItemNoPedido(pedido, pedidoItem);
        }
        
        pedido.AdicionarEvento(new PedidoItemAdicionadoEvent(message.ClienteId, message.ProdutoId, pedido.Id, message.Nome, message.ValorUnitario, message.Quantidade));
        
        return await _pedidoRepository.UnitOfWork.Commit();
    }

    private void AdicionarOuAtualizarItemNoPedido(Pedido pedido, PedidoItem pedidoItem)
    {
        var pedidoExist = pedido.PedidoItemExistente(pedidoItem);
        pedido.AdicionarItem(pedidoItem);

        if (pedidoExist)
        {
            var existingItem = pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);
            if (existingItem != null)
                _pedidoRepository.AtualizarItem(existingItem);
        }
        else
            _pedidoRepository.AdicionarItem(pedidoItem);
        
        pedido.AdicionarEvento(new PedidoAtualizadoEvent(pedido.ClienteId, pedido.Id, pedido.ValorTotal));
        
    }
    private Pedido CriarNovoPedidoComItem(Guid clienteId, PedidoItem pedidoItem)
    {
        IPedidoAbstractFactory pedidoFactory = new PedidoConcretFactory();
        var pedido = pedidoFactory.CriarPedidoRascunho(clienteId);
        pedido.AdicionarItem(pedidoItem);
        return pedido;
    }
    private bool ValidarComando(Command message)
    {
        if(message.EhValido()) return true;
        
        foreach(var error in message.ValidationResult.Errors)
        {
            // lançar um evento de erro
        }
        
        return false;
    }

    public async Task<bool> Handle(AtualizarItemCommand request, CancellationToken cancellationToken)
    {
        if(!ValidarComando(request)) return false;
        
        var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(request.ClienteId);
        
        if (pedido is null)
        {
            await _mediatorHandler.PublicarEvento(new DomainNotification("Pedido", "Pedido não encontrado"));
            return false;
        }
        
        var pedidoItem = await _pedidoRepository.ObterItemPorPedido(pedido.Id, request.ProdutoId);
        
        if (!pedido.PedidoItemExistente(pedidoItem))
        {
            await _mediatorHandler.PublicarEvento(new DomainNotification("Pedido", "Item do pedido não encontrado"));
            return false;
        }
        
        pedido.AtualizarUnidades(pedidoItem, request.Quantidade);
        
        pedido.AdicionarEvento(new PedidoAtualizadoEvent(pedido.ClienteId, pedido.Id, pedido.ValorTotal));
        
        return await _pedidoRepository.UnitOfWork.Commit();
        
    }

    public async Task<bool> Handle(RemoverItemCommand request, CancellationToken cancellationToken)
    {
        if(!ValidarComando(request)) return false;
        
        var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(request.ClienteId);
        
        if (pedido is null)
        {
            await _mediatorHandler.PublicarEvento(new DomainNotification("Pedido", "Pedido não encontrado"));
            return false;
        }
        
        var pedidoItem = await _pedidoRepository.ObterItemPorPedido(pedido.Id, request.ProdutoId);
        
        if (pedidoItem is null)
        {
            await _mediatorHandler.PublicarEvento(new DomainNotification("Pedido", "Item do pedido não encontrado"));
            return false;
        }
        
        pedido.RemoverItem(pedidoItem);
        
        pedido.AdicionarEvento(new PedidoAtualizadoEvent(pedido.ClienteId, pedido.Id, pedido.ValorTotal));
        pedido.AdicionarEvento(new RemoverItemEvent(pedido.ClienteId, pedido.Id, pedidoItem.ProdutoId));
        
        return await _pedidoRepository.UnitOfWork.Commit();
        
        
    }

    public async Task<bool> Handle(AplicarVoucherPedidoCommand request, CancellationToken cancellationToken)
    {
        if(!ValidarComando(request)) return false;
        
        var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(request.ClienteId);
        
        if (pedido is null)
        {
            await _mediatorHandler.PublicarEvento(new DomainNotification("Pedido", "Pedido não encontrado"));
            return false;
        }
        
        var voucher = await _pedidoRepository.ObterVoucherPorCodigo(request.CodigoVoucher);
        
        if (voucher is null)
        {
            await _mediatorHandler.PublicarEvento(new DomainNotification("Pedido", "Voucher não encontrado"));
            return false;
        }
        
        //var voucherAplicacaoValidation = pedido.AplciarVoucher(voucher);
        
        return await _pedidoRepository.UnitOfWork.Commit();
    }
}