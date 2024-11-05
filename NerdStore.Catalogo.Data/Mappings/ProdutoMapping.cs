using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Entities;

namespace NerdStore.Catalogo.Data.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder.Property(p => p.Imagem)
            .IsRequired()
            .HasColumnType("varchar(250)");
        
        builder.Property(p => p.Valor)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.OwnsOne(p => p.Dimensoes, dm =>
        {
            dm.Property(d => d.Altura)
                .HasColumnName("Altura")
                .HasColumnType("decimal(18,2)");

            dm.Property(d => d.Largura)
                .HasColumnName("Largura")
                .HasColumnType("decimal(18,2)");

            dm.Property(d => d.Profundidade)
                .HasColumnName("Profundidade")
                .HasColumnType("decimal(18,2)");
        });

        builder.ToTable("Produtos");
    }
}