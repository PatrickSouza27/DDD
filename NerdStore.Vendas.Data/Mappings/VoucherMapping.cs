using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Vendas.Domain.Entities;

namespace NerdStore.Vendas.Data.Mappings;

public class VoucherMapping : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Codigo)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Percentual)
            .HasColumnType("decimal");

        builder.Property(p => p.ValorDesconto)
            .HasColumnType("decimal");

        builder.Property(p => p.Quantidade)
            .HasColumnType("int");

        builder.Property(p => p.TipoDescontoVoucher)
            .HasConversion<string>()
            .HasColumnType("varchar(32)");

        builder.Property(p => p.DataValidade)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(p => p.Ativo)
            .IsRequired()
            .HasColumnType("bit");

        builder.ToTable("Vouchers");
    }
}