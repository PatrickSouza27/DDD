using NerdStore.Catalogo.Application.AutoMapper;

namespace NerdStore.Catalogo.API.Setup;

public static class AutoMapperExtension
{
    public static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
    }
}