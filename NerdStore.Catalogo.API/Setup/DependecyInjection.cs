using System.ComponentModel.DataAnnotations;
using MediatR;
using NerdStore.Catalogo.Application.AutoMapper;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Application.Services.Interfaces;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Data.Repositories;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Interfaces;
using NerdStore.Core.Handlers;
using NerdStore.Core.Handlers.Interfaces;

namespace NerdStore.Catalogo.API.Setup;

public static class DependecyInjection
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.RegisterData(configuration);
        services.RegisterMediatr();
        services.RegisterAutoMapper();
    }
}