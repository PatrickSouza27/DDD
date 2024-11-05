using System;
using NerdStore.Catalogo.Domain.Entities.ValuesObjects;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Entities;

public class Produto : Entity, IAggregateRoot
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public bool Ativo { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public string Imagem { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public Guid CategoriaId { get; private set; }
    public Categoria Categoria { get; private set; }
    public Dimensoes Dimensoes { get; set; }

    protected Produto() { }
    public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, int quantidadeEstoque, Dimensoes dimensoes)
    {
        Nome = nome;
        Descricao = descricao;
        Ativo = ativo;
        Valor = valor;
        CategoriaId = categoriaId;
        DataCadastro = dataCadastro;
        Imagem = imagem;
        QuantidadeEstoque = quantidadeEstoque;
        Dimensoes = dimensoes;

        Validar();
    }
    
    public void Ativar() => Ativo = true;
    
    public void Desativar() => Ativo = false;
    
    public void AlterarCategoria(Categoria categoria)
    {
        Categoria = categoria;
        CategoriaId = categoria.Id;
    }
    
    public void AlterarDescricao(string descricao) => Descricao = descricao;
    
    public void DebitarEstoque(int quantidade)
    {
        if(quantidade < 0) 
            quantidade *= -1;
        if(!PossuiEstoque(quantidade)) 
            throw new DomainException("Estoque insuficiente");
        QuantidadeEstoque -= quantidade;
    }
    
    public void ReporEstoque(int quantidade)
    {
        QuantidadeEstoque += quantidade;
    }
    
    public bool PossuiEstoque(int quantidade)
    {
        return QuantidadeEstoque >= quantidade;
    }

    public void Validar()
    {
        // aqui coloca as validações do produto do AssertionConcern ou FluentValidation
        
        AssertionConcern.AssertArgumentNotEmpty(Nome, "O nome do produto não pode ser vazio");
    }

}