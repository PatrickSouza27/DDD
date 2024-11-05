using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Application.Services.Interfaces;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Data.Repositories;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Interfaces;
using NerdStore.Vendas.Data;

namespace NerdStore.Catalogo.API.Setup;

public static class DataExtension
{
    public static void RegisterData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CatalogoContext>(options => options.UseSqlServer(connectionString));
        services.AddDbContext<VendasContext>(options => options.UseSqlServer(connectionString));
        
        //colocar todos os contextos
        //services.AddDbContext<CatalogoContext>(options => options.UseSqlServer(connectionString));
        //services.AddDbContext<CatalogoContext>(options => options.UseSqlServer(connectionString));

        services.RegisterRepository();
    }

    private static void RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
    }
}