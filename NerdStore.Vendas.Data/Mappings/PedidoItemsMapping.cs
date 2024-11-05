using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Vendas.Domain.Entities;

namespace NerdStore.Vendas.Data.Mappings;

public class PedidoItemsMapping : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProdutoNome)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(p => p.ProdutoId)
            .IsRequired()
            .HasColumnType("uniqueidentifier");

        builder.Property(p => p.Quantidade)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.ValorUnitario)
            .IsRequired()
            .HasColumnType("decimal");

        builder.Property(p => p.PedidoId)
            .IsRequired()
            .HasColumnType("uniqueidentifier");

        builder.HasOne(p => p.Pedido)
            .WithMany(p => p.PedidoItems)
            .HasForeignKey(p => p.PedidoId);

        builder.ToTable("PedidoItems");
    }
}