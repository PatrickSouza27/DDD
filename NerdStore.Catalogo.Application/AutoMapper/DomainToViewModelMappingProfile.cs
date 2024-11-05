using AutoMapper;
using NerdStore.Catalogo.Application.DTOs;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Entities;

namespace NerdStore.Catalogo.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        // criando uma classe filha direto para a Domain Exemplo subclasse Dimensao direto para Produto
        CreateMap<Produto, ProdutoDTO>()
            .ForMember(d=> d.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
            .ForMember(d=> d.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
            .ForMember(d=> d.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));
        CreateMap<Categoria, CategoriaDTO>();
    }
    
    
}