using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Core.Handlers.Interfaces;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Domain.Entities;

namespace NerdStore.Vendas.Data;

public class VendasContext : DbContext, IUnitOfWork
{
    private readonly IMediatrHandler _mediatrHandler;
    
    public VendasContext(DbContextOptions<VendasContext> options, IMediatrHandler mediatrHandler) : base(options)
    {
        _mediatrHandler = mediatrHandler;
    }
    public DbSet<Pedido> Pedidos { get; set; }
    
    public DbSet<PedidoItem> PedidoItems { get; set; }
    
    public DbSet<Voucher> Vouchers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendasContext).Assembly);
        modelBuilder.Ignore<Event>();
        modelBuilder.HasSequence<int>("MinhaSequencia").StartsAt(1).IncrementsBy(1);
        base.OnModelCreating(modelBuilder);
    }
    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}