
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Core.Data;
using NerdStore.Core.Handlers.Interfaces;
using NerdStore.Core.Messages;

namespace NerdStore.Catalogo.Data;

public class CatalogoContext : DbContext, IUnitOfWork
{
    private readonly IMediatrHandler _mediatrHandler;
    public CatalogoContext(DbContextOptions<CatalogoContext> options, IMediatrHandler mediatrHandler) : base(options)
    {
        _mediatrHandler = mediatrHandler;
    }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}