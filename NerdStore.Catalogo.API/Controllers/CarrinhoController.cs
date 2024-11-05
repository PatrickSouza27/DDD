using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services.Interfaces;
using NerdStore.Core.Handlers.Interfaces;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.Catalogo.API.Controllers;

[ApiController]
public class CarrinhoController : ControllerBase
{
    private readonly IProdutoAppService _produtoRepository;
    private readonly IMediatrHandler _mediatrHandler;

    public CarrinhoController(IProdutoAppService produtoRepository, IMediatrHandler mediatrHandler)
    {
        _mediatrHandler = mediatrHandler;
        _produtoRepository = produtoRepository;
    }

    // [HttpPost]
    // [Route("meu-carrinho")]
    // public async Task<IActionResult> AdicionarItem(Guid id, int qtd)
    // {
    //     var produto = await _produtoRepository.ObterPorId(id);
    //     
    //     if (produto == null) 
    //         return BadRequest();
    //     
    //     if(produto.QuantidadeEstoque < qtd) return BadRequest("Produto com Estoque insuficiente");
    //     
    //     var command = new AdicionarItemPedidoCommand(id, produto.Id, produto.Nome, qtd, produto.Valor);
    //     await _mediatrHandler.EnviarComando(command);
    //     
    //     
    // }
}