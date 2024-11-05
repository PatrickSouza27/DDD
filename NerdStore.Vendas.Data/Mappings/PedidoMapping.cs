using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Vendas.Domain.Entities;

namespace NerdStore.Vendas.Data.Mappings;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Codigo)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.ClienteId)
            .IsRequired()
            .HasColumnType("uniqueidentifier");

        builder.Property(p => p.ValorTotal)
            .HasColumnType("decimal");

        builder.Property(p => p.Desconto)
            .HasColumnType("decimal");

        builder.Property(p => p.VoucherId)
            .HasColumnType("uniqueidentifier");

        builder.Property(p => p.VoucherUtilizado)
            .HasColumnType("bit");

        builder.Property(p => p.ValorTotal)
            .HasColumnType("decimal");

        builder.Property(p => p.Status)
            .HasConversion<string>()
            .IsRequired()
            .HasColumnType("varchar(32)");

        builder.HasMany(p => p.PedidoItems)
            .WithOne(i => i.Pedido)
            .HasForeignKey(i => i.PedidoId);

        builder.HasOne(p => p.Vouchers)
            .WithOne()
            .HasForeignKey<Pedido>(p => p.VoucherId);

        builder.ToTable("Pedidos");
    }
}