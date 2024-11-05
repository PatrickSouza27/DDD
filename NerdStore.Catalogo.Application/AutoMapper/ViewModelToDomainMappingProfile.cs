using AutoMapper;
using NerdStore.Catalogo.Application.DTOs;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Entities.ValuesObjects;

namespace NerdStore.Catalogo.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        // Aqui vou pegar uma super classe e transformar em uma subclasse, no caso Dimensao dentro de Produto
        CreateMap<ProdutoDTO, Produto>()
            .ConstructUsing(p =>
                new Produto(p.Nome, p.Descricao, p.Ativo, p.Valor, p.CategoriaId, p.DataCadastro, p.Imagem, p.QuantidadeEstoque, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

        CreateMap<CategoriaDTO, Categoria>()
            .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
    }
}